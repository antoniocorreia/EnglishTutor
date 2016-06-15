using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistEduc.Models
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Idade { get; set; }
        public Nullable<int> Level { get; set; }
    }
}