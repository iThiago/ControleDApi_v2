namespace ControleDApi.Migrations
{
    using ControleDApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Script.Serialization;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleDApi.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ControleDApi.DAL.Context db)
        {

            var caminho = "C:/projetos/Backend/C#/ControleDApi_v2/ControleDApi/AlimentosBD/categoryList.json";
            string text = System.IO.File.ReadAllText(caminho);

            using (var file =
             new System.IO.StreamReader(caminho))
            {
                var line = "";


                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                List<Categoria> alimentos = jsonSerializer.Deserialize<List<Categoria>>(text);


                db.Categoria.AddRange(alimentos);

                db.SaveChanges();


            }
            //
        }
    }
}
