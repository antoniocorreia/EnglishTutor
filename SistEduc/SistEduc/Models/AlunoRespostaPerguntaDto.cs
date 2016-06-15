using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistEduc.Models
{
    public class AlunoRespostaPerguntaDto
    {
        public int Id { get; set; }
        public Nullable<int> IdAluno { get; set; }
        public Nullable<int> IdPergunta { get; set; }
        public Nullable<bool> Acerto { get; set; }
        public Nullable<System.DateTime> DataHora { get; set; }
    }
}