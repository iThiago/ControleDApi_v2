using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ControleDApi.DAL;
using ControleDApi.Models;

namespace ControleDApi.Controllers
{
    [RoutePrefix("api/Refeicao")]
    public class RefeicaoController : ApiController
    {
        private Context db = new Context();

        [Route("")]
        // GET: api/Refeicao
        public List<Refeicao> GetRefeicao(int idUsuario = 0,int tipoRefeicao= 0,DateTime? data = null,bool isTemplate = false)
        {
            var retorno = db.Refeicao.Include(x => x.AlimentosConsumo.Select(y => y.Alimento))
                                     .Include(x => x.Usuarios)
                                     .Where(x => x.IsTemplate == isTemplate
                                     ).AsQueryable();

            if(tipoRefeicao > 0)
            {
                retorno = retorno.Where(x => x.TipoRefeicao == tipoRefeicao);
            }

            //if (data != null && data != default(DateTime))
            //{
            //    retorno =  retorno.Where(x => DbFunctions.TruncateTime(x.Data) == data);
            //}


            if (idUsuario > 0)
            {
                retorno = retorno.Where(x => x.Usuarios.Select(u => u.Id).Contains(idUsuario));
            }

            var list = retorno.AsNoTracking().ToList();

            if (data != null && data != default(DateTime))
            {
                list = list.Where(x => x.Data == data).ToList();
            }

            return list;
        }

        // GET: api/Refeicao/5
        [ResponseType(typeof(Refeicao))]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetRefeicao(int id)
        {
            Refeicao refeicao = await db.Refeicao.FindAsync(id);
            if (refeicao == null)
            {
                return NotFound();
            }

            return Ok(refeicao);
        }

        // PUT: api/Refeicao/5
        [ResponseType(typeof(void))]
        [Route("")]
        public async Task<IHttpActionResult> PutRefeicao(int id, Refeicao refeicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != refeicao.Id)
            {
                return BadRequest();
            }

            db.Entry(refeicao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefeicaoExists(id))
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

        // POST: api/Refeicao
        [ResponseType(typeof(Refeicao))]
        [Route("")]
        public async Task<IHttpActionResult> PostRefeicao(Refeicao refeicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var refeicaoToSave = new Refeicao
                {
                    AlimentosConsumo = refeicao.AlimentosConsumo,
                    Usuarios = new List<Usuario>(),
                    InsulinaId = 1,
                    QtdCarboidrato = refeicao.QtdCarboidrato,
                    QtdInsulina = refeicao.QtdInsulina,
                    TipoRefeicao = refeicao.TipoRefeicao,
                    Data = refeicao.Data
                };

                foreach (var item in refeicao.Usuarios)
                {
                    refeicaoToSave.Usuarios.Add(db.Users.First(x => x.Id == item.Id));
                }
                refeicaoToSave.AlimentosConsumo.ForEach(x =>
                {
                    x.AlimentoId = x.Alimento?.Id ?? x.AlimentoId;
                    x.Alimento = null;
                });
                
                db.Refeicao.Add(refeicaoToSave);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
            

            return Created<int>("", refeicao.Id);
        }

        // DELETE: api/Refeicao/5
        [ResponseType(typeof(Refeicao))]
        [Route("")]
        public async Task<IHttpActionResult> DeleteRefeicao(int id)
        {
            Refeicao refeicao = await db.Refeicao.FindAsync(id);
            if (refeicao == null)
            {
                return NotFound();
            }

            db.Refeicao.Remove(refeicao);
            await db.SaveChangesAsync();

            return Ok(refeicao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RefeicaoExists(int id)
        {
            return db.Refeicao.Count(e => e.Id == id) > 0;
        }
    }
}