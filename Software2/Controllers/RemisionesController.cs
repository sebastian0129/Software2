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
    public class RemisionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Remisiones
        public ActionResult Index()
        {
            var remisions = db.Remisions.Include(r => r.Mascota);
            return View(remisions.ToList());
        }

        // GET: Remisiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remision remision = db.Remisions.Find(id);
            if (remision == null)
            {
                return HttpNotFound();
            }
            return View(remision);
        }

        // GET: Remisiones/Create
        public ActionResult Create()
        {
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre");
            return View();
        }

        // POST: Remisiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "remisionID,mascotaID,region,vista,diagnostico,ecografia,evaluacion,resultado,observacion")] Remision remision)
        {
            if (ModelState.IsValid)
            {
                remision.fechaRemision = DateTime.Now.Date;
                db.Remisions.Add(remision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", remision.mascotaID);
            return View(remision);
        }

        // GET: Remisiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remision remision = db.Remisions.Find(id);
            if (remision == null)
            {
                return HttpNotFound();
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", remision.mascotaID);
            return View(remision);
        }

        // POST: Remisiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "remisionID,fechaRemision,mascotaID,region,vista,diagnostico,ecografia,evaluacion,resultado,observacion")] Remision remision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", remision.mascotaID);
            return View(remision);
        }

        // GET: Remisiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remision remision = db.Remisions.Find(id);
            if (remision == null)
            {
                return HttpNotFound();
            }
            return View(remision);
        }

        // POST: Remisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Remision remision = db.Remisions.Find(id);
            db.Remisions.Remove(remision);
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
