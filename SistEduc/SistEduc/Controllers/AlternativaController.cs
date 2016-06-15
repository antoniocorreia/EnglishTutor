using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistEduc.Models;

namespace SistEduc.Controllers
{
    public class AlternativaController : Controller
    {
        private dbSistemasEducacionaisEntities db = new dbSistemasEducacionaisEntities();

        // GET: Alternativa
        public ActionResult Index()
        {
            var alternativa = db.Alternativa.Include(a => a.Pergunta);
            return View(alternativa.ToList());
        }

        // GET: Alternativa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativa = db.Alternativa.Find(id);
            if (alternativa == null)
            {
                return HttpNotFound();
            }
            return View(alternativa);
        }

        // GET: Alternativa/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado");
        //    return View();
        //}

        public ActionResult Create(int id)
        {
            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado",id);
            ViewBag.IdPerguntaModel = id;
            return View();
        }

        // POST: Alternativa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Texto,IdPergunta,RespostaCorreta")] Alternativa alternativa)
        {
            if (ModelState.IsValid)
            {
                db.Alternativa.Add(alternativa);
                db.SaveChanges();
                return RedirectToAction("Edit", "Pergunta", new { id = alternativa.IdPergunta });
            }

            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado", alternativa.IdPergunta);
            ViewBag.IdPerguntaModel = alternativa.IdPergunta;
            return View(alternativa);
        }

        // GET: Alternativa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativa = db.Alternativa.Find(id);
            if (alternativa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado", alternativa.IdPergunta);
            return View(alternativa);
        }

        // POST: Alternativa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Texto,IdPergunta,RespostaCorreta")] Alternativa alternativa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alternativa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Pergunta", new { id = alternativa.IdPergunta });
            }
            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado", alternativa.IdPergunta);
            ViewBag.IdPerguntaModel = alternativa.IdPergunta;
            return View(alternativa);
        }

        // GET: Alternativa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativa = db.Alternativa.Find(id);
            if (alternativa == null)
            {
                return HttpNotFound();
            }
            return View(alternativa);
        }

        // POST: Alternativa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alternativa alternativa = db.Alternativa.Find(id);
            int idPergunta = alternativa.IdPergunta.Value;
            db.Alternativa.Remove(alternativa);
            db.SaveChanges();
            return RedirectToAction("Edit", "Pergunta", new { id = idPergunta });
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
