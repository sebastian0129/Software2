using Software2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Script.Serialization;

namespace Software2.Controllers
{
    public class ReportesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult MascotasAtendidas()
        {

           
            return View();
        }
        [HttpPost]
        
        public JsonResult MascotasAtendidas(modelo model)
        {
            var json="{}";
            try
            {
                DateTime inicio = DateTime.ParseExact(model.fechaInicio, "yyyy-MM-dd",
                                           System.Globalization.CultureInfo.InvariantCulture);

                DateTime fin = DateTime.ParseExact(model.fechaFin, "yyyy-MM-dd",
                                           System.Globalization.CultureInfo.InvariantCulture);
                var query = "select * from veterinarios  inner join Controls on  veterinarios.id=controls.veterinarioFK where  fecha>='" + inicio + "' and fecha<='" + fin + "'";

                List<Veterinario> consultas = db.Veterinarios.SqlQuery(query).ToList();

                List<Veterinario> salida=new List<Veterinario>();
                foreach (var item in consultas)
                {
                    Veterinario  vet= db.Veterinarios.Include(xx => xx.controles).FirstOrDefault(xx => xx.ID == item.ID);

                    foreach (var item2 in vet.controles)
                    {
                        item2.veterinario = null;
                    }
                    salida.Add(vet);
                }

                var jsonSerialiser = new JavaScriptSerializer();
                 json = jsonSerialiser.Serialize(salida);
            }
            catch(Exception ex)
            {

            }
           

            return Json(json);
        }


    }
        public  class modelo
        {
            public string fechaInicio { get; set; }
            public string fechaFin { get; set; }
        }
    
    }