using sisteducAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace sisteducAPI.Controllers
{
    public class AlunoController : ApiController
    {
        private dbSistemasEducacionaisEntities1 db = new dbSistemasEducacionaisEntities1();

        public int GetIdAluno(string username)
        {
            Aluno entity = new Aluno();

            var aluno = db.Aluno.Where(x => x.Username == username);

            if(aluno == null)
            {
                return -1;
            }

            int idAluno = aluno.FirstOrDefault().Id;

            return idAluno;
        }
    }
}
