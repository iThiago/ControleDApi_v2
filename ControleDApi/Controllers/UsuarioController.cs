using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ControleDApi.DAL;
using ControleDApi.Models;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ControleDApi.Util;
using System.Net.Mail;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ControleDApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private Context db = new Context();

        // GET: api/Usuario
        [HttpGet]
        [Route("Get")]
        [Route("")]
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Users;
        }

        // GET: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        [HttpGet]
        [Route("GetUsuario")]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario pessoa = db.Users.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPessoa(int id, Usuario pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            db.Entry(pessoa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuario
        [ResponseType(typeof(Usuario))]
        [HttpPost]
        [Route("PostPessoa")]
        public HttpResponseMessage PostPessoa(Usuario usuario)
        {

            HttpResponseMessage response;
            string resultado = string.Empty;

            try
            {
                usuario.UserName = usuario.Email;

                var userManager = Request.GetOwinContext().GetUserManager<AppUserManager>();

                usuario.UserName = usuario.Email;
                usuario.PasswordHash = usuario.Senha;

                var listPerfisValidos = new Context().Roles.Where(x => !x.Name.ToUpper().Contains("ADMINISTRADOR")).Select(x => x.Id).ToList();

                if (!listPerfisValidos.Contains(usuario.IdPerfil.ToString()))
                {
                    throw new Exception("Perfil Inválido!!");
                }

                if (usuario.IdPerfil == EnumRole.Medico.GetHashCode())
                {
                    if (string.IsNullOrEmpty(Convert.ToString(usuario.Crm)))
                        throw new Exception("Crm Obrigatório!");
                }
                if (usuario.IdPerfil == EnumRole.Paciente.GetHashCode())
                {
                    if (string.IsNullOrEmpty(Convert.ToString(usuario.Cpf)) || usuario.Cpf == 0)
                        throw new Exception("Cpf Obrigatório!");
                }

                //var usuarioRole = new IdentityUserRole();
                //usuarioRole.
                

                IdentityResult result = userManager.Create(usuario, usuario.Senha);

                if (result.Succeeded)
                    resultado = "Usuario Criado com sucesso";
                else
                    resultado = string.Join(",", result.Errors);

                response = Request.CreateResponse(HttpStatusCode.OK, resultado);
                return response;

                if (!ModelState.IsValid)
                {
                    var x = BadRequest(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, x);
                }

                db.Users.Add(usuario);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        [ResponseType(typeof(Usuario))]
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Medico")]
        [HttpPost]
        [Route("CadastrarPaciente")]
        public HttpResponseMessage CadastrarPaciente(Usuario usuario)
        {

            HttpResponseMessage response;
            string resultado = string.Empty;

            try
            {
                usuario.UserName = usuario.Email;

                var userManager = Request.GetOwinContext().GetUserManager<AppUserManager>();

                usuario.UserName = usuario.Email;

                usuario.PasswordHash = Guid.NewGuid().ToString().Substring(0, 6).Replace("-", "1");
                usuario.senhaTemporaria = true;

                var listPerfisValidos = new Context().Roles.Where(x => !x.Name.ToUpper().Contains("ADMINISTRADOR")).Select(x => x.Id).ToList();

                if (!listPerfisValidos.Contains(usuario.IdPerfil.ToString()))
                {
                    throw new Exception("Perfil Inválido!!");
                }


                if (string.IsNullOrEmpty(Convert.ToString(usuario.Cpf)) || usuario.Cpf == 0)
                    throw new Exception("Cpf Obrigatório!");


                IdentityResult result = userManager.Create(usuario, usuario.Senha);


                //cria uma mensagem
                MailMessage mail = new MailMessage();

                //define os endereços
                mail.From = new MailAddress("thiagoacao@gmail.com");
                mail.To.Add(usuario.Email);

                //define o conteúdo
                mail.Subject = "Controle D - Senha temporária.";
                mail.Body = " Olá! Parece que o(a) Dr(a) cadastrou você no Controle D!";
                mail.Body += " Seja bem vindo! Para acessar o site entre na seguinte Url: www.ControleD.com.br";
                mail.Body += " Para fazer login, utilize o e-mail: " + usuario.Email + " e a senha temporária: " + usuario.PasswordHash;
                mail.Body += " No seu primeiro acesso sera você podera cadastrar uma nova senha. Obrigado!";

                //envia a mensagem
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Send(mail);

                if (result.Succeeded)
                    resultado = "Paciente Criado com sucesso";
                else
                    resultado = string.Join(",", result.Errors);

                response = Request.CreateResponse(HttpStatusCode.OK, resultado);
                return response;

                if (!ModelState.IsValid)
                {
                    var x = BadRequest(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, x);
                }

                db.Users.Add(usuario);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeletePessoa(int id)
        {
            Usuario pessoa = db.Users.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            db.Users.Remove(pessoa);
            db.SaveChanges();

            return Ok(pessoa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}