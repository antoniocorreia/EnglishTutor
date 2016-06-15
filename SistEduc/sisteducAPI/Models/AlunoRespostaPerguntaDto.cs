using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisteducAPI.Models
{
    public class AlunoRespostaPerguntaDto
    {
        public int IdAluno { get; set; }
        public int IdPergunta { get; set; }
        public bool Acerto { get; set; }
    }
}