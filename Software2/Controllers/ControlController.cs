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
    public class ControlController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Control
        public ActionResult Index()
        {
            var controls = db.Controls.Include(c => c.historiaclinica);
            return View(controls.ToList());
        }

        // GET: Control/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control control = db.Controls.Find(id);
            if (control == null)
            {
                return HttpNotFound();
            }
            return View(control);
        }

        // GET: Control/Create
        public ActionResult Create()
        {
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id");
            return View();
        }

        // POST: Control/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,historia,anamnesis,temperatura,fc,mucosas,fr,tiempo,piel,muscolo,ojos,cardiovascular,respiratorio,digestivo,genito,reproducor,nervioso,linfatico,des_piel,des_muscolo,des_ojos,des_cardiovascular,des_respiratorio,des_digestivo,des_genito,des_reproducor,des_nervioso,des_linfatico,anormalidades,problemas,ayudas,fianl")] Control control)
        {
            if (ModelState.IsValid)
            {
                db.Controls.Add(control);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", control.historia);
            return View(control);
        }

        // GET: Control/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control control = db.Controls.Find(id);
            if (control == null)
            {
                return HttpNotFound();
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", control.historia);
            return View(control);
        }

        // POST: Control/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,historia,anamnesis,temperatura,fc,mucosas,fr,tiempo,piel,muscolo,ojos,cardiovascular,respiratorio,digestivo,genito,reproducor,nervioso,linfatico,des_piel,des_muscolo,des_ojos,des_cardiovascular,des_respiratorio,des_digestivo,des_genito,des_reproducor,des_nervioso,des_linfatico,anormalidades,problemas,ayudas,fianl")] Control control)
        {
            if (ModelState.IsValid)
            {
                db.Entry(control).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", control.historia);
            return View(control);
        }

        // GET: Control/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control control = db.Controls.Find(id);
            if (control == null)
            {
                return HttpNotFound();
            }
            return View(control);
        }

        // POST: Control/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Control control = db.Controls.Find(id);
            db.Controls.Remove(control);
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
