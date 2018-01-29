using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Software2.Controllers
{
    public class MedicosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicos
        public ActionResult Index()
        {
            return View(db.Medicos.ToList());
        }

      
        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {

                if (existeMedico(medico.correo))
                {
                    ModelState.AddModelError("", "Este correo ya se encuentra registrado");
                    return View();
                }

                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    var UserManager = new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(db));

                    var user = new ApplicationUser()
                    {
                        Email = medico.correo,
                        UserName = medico.correo
                    };
                    var resultado = UserManager.Create(user, medico.password);
                    var result1 = UserManager.AddToRole(user.Id, "Medico");

                    medico.medicoID = user.Id;


                }

                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medico);
        }




        private bool existeMedico(String correo)
        {
            return db.Users.Count(x => x.Email== correo) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
