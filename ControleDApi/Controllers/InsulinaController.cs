using ControleDApi.DAL;
using ControleDApi.Models.Auth;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ControleDApi.Models;

namespace ControleDApi.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Insulina")]
    public class InsulinaController : ApiController
    {

        private Context db = new Context();

        // GET: api/Alimento 18
        [HttpGet]
        [Route("")]
        public List<Insulina> Get()
        {

            var roles = db.Insulina.ToList();
            return roles;
        }

    }
}