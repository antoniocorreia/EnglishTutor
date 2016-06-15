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
    public class PerguntaController : Controller
    {
        private dbSistemasEducacionaisEntities db = new dbSistemasEducacionaisEntities();

        // GET: Pergunta
        public ActionResult Index()
        {
            var pergunta = db.Pergunta.Include(p => p.Tema);
            return View(pergunta.ToList());
        }

        // GET: Pergunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // GET: Pergunta/Create
        public ActionResult Create()
        {
            ViewBag.IdTema = new SelectList(db.Tema, "Id", "Nome");
            return View();
        }

        // POST: Pergunta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Enunciado,IdTema")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                db.Pergunta.Add(pergunta);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = pergunta.Id});
            }

            ViewBag.IdTema = new SelectList(db.Tema, "Id", "Nome", pergunta.IdTema);
            return View(pergunta);
        }

        // GET: Pergunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Include(p => p.Alternativa).Where(x => x.Id == id).FirstOrDefault();
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTema = new SelectList(db.Tema, "Id", "Nome", pergunta.IdTema);
            
            return View(pergunta);
        }

        // POST: Pergunta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Enunciado,IdTema")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pergunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTema = new SelectList(db.Tema, "Id", "Nome", pergunta.IdTema);
            return View(pergunta);
        }

        // GET: Pergunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // POST: Pergunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pergunta pergunta = db.Pergunta.Find(id);
            db.Pergunta.Remove(pergunta);
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
