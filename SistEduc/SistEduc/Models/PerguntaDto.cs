using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistEduc.Models
{
    public class PerguntaDto
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public Nullable<int> IdTema { get; set; }
    }
}