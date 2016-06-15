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
    [Authorize]
    public class AlunoRespostaPerguntasController : Controller
    {
        private dbSistemasEducacionaisEntities db = new dbSistemasEducacionaisEntities();

        // GET: AlunoRespostaPerguntas
        public ActionResult Index()
        {
            var alunoRespostaPergunta = db.AlunoRespostaPergunta.Include(a => a.Aluno).Include(a => a.Pergunta);
            return View(alunoRespostaPergunta.ToList());
        }

        // GET: AlunoRespostaPerguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoRespostaPergunta alunoRespostaPergunta = db.AlunoRespostaPergunta.Find(id);
            if (alunoRespostaPergunta == null)
            {
                return HttpNotFound();
            }
            return View(alunoRespostaPergunta);
        }

        // GET: AlunoRespostaPerguntas/Create
        public ActionResult Create()
        {
            ViewBag.IdAluno = new SelectList(db.Aluno, "Id", "Nome");
            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado");
            return View();
        }

        // POST: AlunoRespostaPerguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdAluno,IdPergunta,Acerto,DataHora")] AlunoRespostaPergunta alunoRespostaPergunta)
        {
            if (ModelState.IsValid)
            {
                db.AlunoRespostaPergunta.Add(alunoRespostaPergunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAluno = new SelectList(db.Aluno, "Id", "Nome", alunoRespostaPergunta.IdAluno);
            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado", alunoRespostaPergunta.IdPergunta);
            return View(alunoRespostaPergunta);
        }

        // GET: AlunoRespostaPerguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoRespostaPergunta alunoRespostaPergunta = db.AlunoRespostaPergunta.Find(id);
            if (alunoRespostaPergunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAluno = new SelectList(db.Aluno, "Id", "Nome", alunoRespostaPergunta.IdAluno);
            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado", alunoRespostaPergunta.IdPergunta);
            return View(alunoRespostaPergunta);
        }

        // POST: AlunoRespostaPerguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdAluno,IdPergunta,Acerto,DataHora")] AlunoRespostaPergunta alunoRespostaPergunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunoRespostaPergunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAluno = new SelectList(db.Aluno, "Id", "Nome", alunoRespostaPergunta.IdAluno);
            ViewBag.IdPergunta = new SelectList(db.Pergunta, "Id", "Enunciado", alunoRespostaPergunta.IdPergunta);
            return View(alunoRespostaPergunta);
        }

        // GET: AlunoRespostaPerguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoRespostaPergunta alunoRespostaPergunta = db.AlunoRespostaPergunta.Find(id);
            if (alunoRespostaPergunta == null)
            {
                return HttpNotFound();
            }
            return View(alunoRespostaPergunta);
        }

        // POST: AlunoRespostaPerguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoRespostaPergunta alunoRespostaPergunta = db.AlunoRespostaPergunta.Find(id);
            db.AlunoRespostaPergunta.Remove(alunoRespostaPergunta);
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
