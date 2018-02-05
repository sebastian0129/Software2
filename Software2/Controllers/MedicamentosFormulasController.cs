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
    public class MedicamentosFormulasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicamentosFormulas
        public ActionResult Index()
        {
            var medicamentosFormulas = db.MedicamentosFormulas.Include(m => m.Formula).Include(m => m.Medicamento);
            return View(medicamentosFormulas.ToList());
        }

        // GET: MedicamentosFormulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentosFormula medicamentosFormula = db.MedicamentosFormulas.Find(id);
            if (medicamentosFormula == null)
            {
                return HttpNotFound();
            }
            return View(medicamentosFormula);
        }

        // GET: MedicamentosFormulas/Create
        public ActionResult Create(int ? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formula formula = db.Formulae.Find(id);
            if (formula == null)
            {
                return HttpNotFound();
            }
            ViewBag.formula = formula;
            ViewBag.MedicamentoID = new SelectList(db.Medicamentoes, "medicamentoID", "nombre");
           
            return View();
        }

        // POST: MedicamentosFormulas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "formulaID,MedicamentoID,frecuenciaHora,dosis")] MedicamentosFormula medicamentosFormula)
        {
            if (ModelState.IsValid)
            {
                db.MedicamentosFormulas.Add(medicamentosFormula);
                db.SaveChanges();
                return RedirectToAction("Create", new { id = medicamentosFormula.formulaID});
            }

            ViewBag.formulaID = new SelectList(db.Formulae, "formulaID", "mascotaID", medicamentosFormula.formulaID);
            ViewBag.MedicamentoID = new SelectList(db.Medicamentoes, "medicamentoID", "nombre", medicamentosFormula.MedicamentoID);
            return View(medicamentosFormula);
        }

        // GET: MedicamentosFormulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentosFormula medicamentosFormula = db.MedicamentosFormulas.Find(id);
            if (medicamentosFormula == null)
            {
                return HttpNotFound();
            }
            ViewBag.formulaID = new SelectList(db.Formulae, "formulaID", "mascotaID", medicamentosFormula.formulaID);
            ViewBag.MedicamentoID = new SelectList(db.Medicamentoes, "medicamentoID", "nombre", medicamentosFormula.MedicamentoID);
            return View(medicamentosFormula);
        }

        // POST: MedicamentosFormulas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "formulaID,MedicamentoID,frecuenciaHora,dosis")] MedicamentosFormula medicamentosFormula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamentosFormula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.formulaID = new SelectList(db.Formulae, "formulaID", "mascotaID", medicamentosFormula.formulaID);
            ViewBag.MedicamentoID = new SelectList(db.Medicamentoes, "medicamentoID", "nombre", medicamentosFormula.MedicamentoID);
            return View(medicamentosFormula);
        }

        // GET: MedicamentosFormulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentosFormula medicamentosFormula = db.MedicamentosFormulas.Find(id);
            if (medicamentosFormula == null)
            {
                return HttpNotFound();
            }
            return View(medicamentosFormula);
        }

        // POST: MedicamentosFormulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicamentosFormula medicamentosFormula = db.MedicamentosFormulas.Find(id);
            db.MedicamentosFormulas.Remove(medicamentosFormula);
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
