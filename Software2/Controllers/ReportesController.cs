using Software2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Software2.Controllers
{
    public class ReportesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult MascotasAtendidas()
        {

            List<Veterinario> veterinarios = db.Veterinarios.Include(xx => xx.controles).ToList();
            return View(veterinarios);
        }
    }
}