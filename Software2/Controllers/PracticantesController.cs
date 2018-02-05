using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;

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
        public ActionResult Create([Bind(Include = "practicanteID,nombre,apellido,correo,password,repetirPassword")] Practicante practicante)
        {
            if (existeIDPracticante(practicante.practicanteID))
            {
                ModelState.AddModelError("", "Ya existe este ID por favor use uno nuevo");
                return View();
            }
            if (ModelState.IsValid)
            {
                db.Practicantes.Add(practicante);
                db.SaveChanges();                
                return RedirectToAction("Index");                
            }
            

            return View(practicante);
        }

        // GET: Practicantes/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Practicantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "practicanteID,nombre,apellido,correo,password,repetirPassword")] Practicante practicante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practicante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practicante);
        }

        // GET: Practicantes/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Practicantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Practicante practicante = db.Practicantes.Find(id);
            db.Practicantes.Remove(practicante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool existeIDPracticante(int practicanteID)
        {
            return db.Practicantes.Count(x => x.practicanteID == practicanteID) > 0;
        }
    }
}
