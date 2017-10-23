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
    public class SoliExamenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SoliExamen
        public ActionResult Index()
        {
            var soliExamen = db.SoliExamen.Include(s => s.mascotaFK).Include(s => s.practicanteFK);
            return View(soliExamen.ToList());
        }

        // GET: SoliExamen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoliExamen soliExamen = db.SoliExamen.Find(id);
            if (soliExamen == null)
            {
                return HttpNotFound();
            }
            return View(soliExamen);
        }

        // GET: SoliExamen/Create
        public ActionResult Create()
        {
            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre");
            ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre");
            return View();
        }

        // POST: SoliExamen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,numeroRecibo,mascota,muestraRemitida,examenSolicitado,diagnosticoPresuntivo,idPracticante")] SoliExamen soliExamen)
        {
            if (ModelState.IsValid)
            {
                db.SoliExamen.Add(soliExamen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre", soliExamen.mascota);
            ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre", soliExamen.idPracticante);
            return View(soliExamen);
        }

        // GET: SoliExamen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoliExamen soliExamen = db.SoliExamen.Find(id);
            if (soliExamen == null)
            {
                return HttpNotFound();
            }
            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre", soliExamen.mascota);
            ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre", soliExamen.idPracticante);
            return View(soliExamen);
        }

        // POST: SoliExamen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,numeroRecibo,mascota,muestraRemitida,examenSolicitado,diagnosticoPresuntivo,idPracticante")] SoliExamen soliExamen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soliExamen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre", soliExamen.mascota);
            ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre", soliExamen.idPracticante);
            return View(soliExamen);
        }

        // GET: SoliExamen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoliExamen soliExamen = db.SoliExamen.Find(id);
            if (soliExamen == null)
            {
                return HttpNotFound();
            }
            return View(soliExamen);
        }

        // POST: SoliExamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoliExamen soliExamen = db.SoliExamen.Find(id);
            db.SoliExamen.Remove(soliExamen);
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
    }
}
