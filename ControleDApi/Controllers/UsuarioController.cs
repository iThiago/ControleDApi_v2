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

namespace ControleDApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("/Usuario")]
    public class UsuarioController : ApiController
    {
        private Context db = new Context();

        // GET: api/Usuario
        [HttpGet]
        [Route("/GetUsuario")]
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Pessoa;
        }

        // GET: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        [HttpGet]
        [Route("/GetUsuario")]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario pessoa = db.Pessoa.Find(id);
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
        public IHttpActionResult PostPessoa(Usuario usuario)
        {
            try
            {

                //pessoa.Cpf = (long)Convert.ToInt64(pessoa.Cpf.ToString().Replace(".", "").Replace("-", ""));

                //if(pessoa.Cpf.ToString().Length != 11)
                //{
                //    throw new Exception("Cpf Inválido!");
                //}

                if (!ModelState.IsValid)
                {
                    var x = BadRequest(ModelState);
                    return x;
                }

                db.Pessoa.Add(usuario);
                db.SaveChanges();


            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok(usuario);
        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeletePessoa(int id)
        {
            Usuario pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            db.Pessoa.Remove(pessoa);
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
            return db.Pessoa.Count(e => e.Id == id) > 0;
        }
    }
}