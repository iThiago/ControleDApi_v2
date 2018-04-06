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

namespace ControleDApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Usuario")]
    public class UsuarioController : ApiController
    {
        private Context db = new Context();

        // GET: api/Usuario
        [HttpGet]
        [Route("GetUsuario")]
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
        public HttpResponseMessage PostPessoa(Usuario usuario)
        {

            HttpResponseMessage response;
            string resultado = string.Empty;

            try
            {
                usuario.UserName = "tnsthiago";

                var userManager = Request.GetOwinContext().GetUserManager<AppUserManager>();

                usuario.UserName = usuario.Email;
                usuario.PasswordHash = usuario.Senha;

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