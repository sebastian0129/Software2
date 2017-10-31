﻿using System;
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
    public class MedicamentosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicamentos
        public ActionResult Index()
        {
            return View(db.Medicamentoes.ToList());
        }

        // GET: Medicamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicamentoID,nombre,expresion,lote,viaSuministro")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Medicamentoes.Add(medicamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicamentoID,nombre,expresion,lote,viaSuministro")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicamento medicamento = db.Medicamentoes.Find(id);
            db.Medicamentoes.Remove(medicamento);
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
