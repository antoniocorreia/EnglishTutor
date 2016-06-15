using SistEduc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistEduc.Controllers
{
    public class RelatorioController : Controller
    {
        private dbSistemasEducacionaisEntities db = new dbSistemasEducacionaisEntities();

        // GET: Relatorio
        public ActionResult Index()
        {
            
            var model = db.Aluno.ToList();
            return View(model);
        }
    }
}