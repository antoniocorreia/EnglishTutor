using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistEduc.Models
{
    public class HomeIndexViewModel
    {
        public List<Aluno> Alunos { get; set; }
        public List<Tema> Temas { get; set; }
        public List<Pergunta> Perguntas { get; set; }
        public List<AlunoRespostaPergunta> Respostas { get; set; }
    }
}