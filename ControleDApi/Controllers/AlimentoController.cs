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
using System.Web.Script.Serialization;
using ControleDApi.App_Start;
using ControleDApi.ViewModel;

namespace ControleDApi.Controllers
{

    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Alimento")]
    public class AlimentoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Alimento 18
        [HttpGet]
        //[Authorize(Roles = "Medico")]
        //[Route("GetAlimentos")]
        [Route("")]
        public PaginaDTO<Alimento> GetAlimentos(string descricao = "", long qtdPorPagina = 10, long pagina = 1)
        {


            //var caminho = "C:/projetos/Backend/C#/ControleDApi_v2/ControleDApi/AlimentosBD/foodList.json";
            ////var caminho = "C:/projetos/Backend/C#/ControleDApi_v2/ControleDApi/AlimentosBD/categoryList.json";
            //string text = System.IO.File.ReadAllText(caminho);

            //using (var file =
            // new System.IO.StreamReader(caminho))
            //{
            //    //var line = "";


            //    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            //    List<Alimento> itens = jsonSerializer.Deserialize<List<Alimento>>(text);
            //    //List<Categoria> itens = jsonSerializer.Deserialize<List<Categoria>>(text);

            //    itens = itens.Take(300).ToList();
            //    //itens.AddRange(itens.Skip(150).Take(50).ToList());
        //TODO: INCLUIR DATA DE ATUALIZACAO E CADASTRADO POR QD FOR ALIMENTO
            //    itens.ForEach(x => x.Carboidrato = x.Carboidrato == null ? new AtributoAlimento { Qtd = 0, Unidade = EnumUnidade.G } : x.Carboidrato);
            //    db.Alimento.AddRange(itens);
            //    //db.Categoria.AddRange(itens);

            //    db.SaveChanges();

            //}

            var retorno = db.Alimento.AsQueryable();

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                retorno = db.Alimento.Where(al => al.Descricao.Contains(descricao));
            }

            pagina -= 1;
            var skip = pagina * qtdPorPagina;

            var retornoAgrupado = retorno
                    .Include(x => x.Unidades)
                    .Include(x => x.Carboidrato)
                    .Include(x => x.Proteina)
                    .Include(x => x.Categoria)
                    .Include(x => x.FibraAlimentar)
                    .Include(x => x.Sodio)
                    .Include(x => x.Potassio)
                    .OrderBy(x => x.Descricao)
                    .Skip((int)skip)
                    .Take((int)qtdPorPagina)
                    .AsNoTracking()
                    .ToList()
                    .GroupBy(p => new { Total = retorno.Count() })
                    .FirstOrDefault();


            PaginaDTO<Alimento> retornoPaginado = new PaginaDTO<Alimento>
            {
                Total = retornoAgrupado?.Key.Total ?? 0,
                Itens = retornoAgrupado?.Select(u => u).ToList() ?? new List<Alimento>()
            };

            return retornoPaginado;
        }

        // GET: api/Alimento/5
        [ResponseType(typeof(Alimento))]
        [HttpGet]
        [Authorize(Roles = "Administrador,Medico,Paciente")]
        [Route("{id}")]
        public IHttpActionResult GetAlimento(int id)
        {
            Alimento alimento = db.Alimento.AsQueryable()
                .Include(x => x.Unidades)
                .Include(x => x.Carboidrato)
                .Include(x => x.Proteina)
                .FirstOrDefault(x => x.Id == id);
            if (alimento == null)
            {
                return NotFound();
            }

            return Ok(alimento);
        }

        // PUT: api/Alimento/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "Administrador,Medico")]
        [Route("")]
        public IHttpActionResult PutAlimento(int id, Alimento alimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alimento.Id)
            {
                return BadRequest();
            }

            var alimentoBse = db.Alimento.Include(x => x.Unidades)
                .Include(x => x.Carboidrato)
                .Include(x => x.Proteina)
                .FirstOrDefault(x => x.Id == id);

            alimentoBse.Unidades.RemoveAll(x => true);
            alimentoBse.Descricao = alimento.Descricao;
            alimentoBse.CategoriaId = alimento.CategoriaId;
            alimentoBse.Unidades = alimento.Unidades;
            
            alimentoBse.Carboidrato.Qtd = alimento.Carboidrato.Qtd;
            alimentoBse.Proteina.Qtd = alimento.Proteina.Qtd;

            alimentoBse.DataAtualizacao = alimento.DataAtualizacao;
            alimentoBse.AtualizadoPor = alimento.AtualizadoPor;

            //db.Entry(alimento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlimentoExists(id))
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

        // POST: api/Alimento
        [ResponseType(typeof(Alimento))]
        [Authorize(Roles = "Administrador,Medico")]
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostAlimento(Alimento alimento)
        {
            try
            {
                //if(alimento.Unidades?.Count > 0)
                //{
                //    db.Unidade.AddRange(alimento.Unidades);
                //}
                db.Alimento.Add(alimento);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/Alimento/5
        [ResponseType(typeof(Alimento))]
        //[Authorize(Roles = "Administrador")]
        [Route("")]
        public IHttpActionResult DeleteAlimento(int id)
        {
            Alimento alimento = db.Alimento.Find(id);
            if (alimento == null)
            {
                return NotFound();
            }

            db.Alimento.Remove(alimento);
            db.SaveChanges();

            return Ok(alimento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlimentoExists(int id)
        {
            return db.Alimento.Count(e => e.Id == id) > 0;
        }
    }
}