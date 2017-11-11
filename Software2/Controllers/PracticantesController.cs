using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Software2.Controllers
{
    public class PracticantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Practicantes
        public ActionResult Index()
        {
            return View(db.Practicantes.ToList());
        }

        // GET: Practicantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practicante practicante = db.Practicantes.Find(id);
            if (practicante == null)
            {
                return HttpNotFound();
            }
            return View(practicante);
        }

        // GET: Practicantes/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: Practicantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Practicante practicante)
        {
            if (existePracticante(practicante.correo))
            {
                ModelState.AddModelError("", "Este correo ya se encuentra registrado");
                return View();
            }
            if (ModelState.IsValid)
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    var UserManager = new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(db));

                    var user = new ApplicationUser()
                    {
                        Email = practicante.correo,
                        UserName = practicante.correo
                    };
                    var resultado = UserManager.Create(user, practicante.password);
                    var result1 = UserManager.AddToRole(user.Id, "Practicante");

                    practicante.practicanteID = user.Id;


                }

                db.Practicantes.Add(practicante);
                db.SaveChanges();                
                return RedirectToAction("Index");                
            }
            

            return View(practicante);
        }


  
    

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool existePracticante(String correo)
        {
            return db.Users.Count(x => x.Email == correo) > 0;
        }
    }
}
