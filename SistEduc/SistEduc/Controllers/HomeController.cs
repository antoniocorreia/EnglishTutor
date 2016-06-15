using SistEduc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistEduc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private dbSistemasEducacionaisEntities db = new dbSistemasEducacionaisEntities();

        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Alunos = db.Aluno.ToList();
            model.Perguntas = db.Pergunta.ToList();
            model.Temas = db.Tema.ToList();
            model.Respostas = db.AlunoRespostaPergunta.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}