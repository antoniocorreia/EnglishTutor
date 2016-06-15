using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisteducAPI.Models
{
    public class PerguntaModel
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public string Tema { get; set; }
        public List<AlternativaModel> Alternativas { get; set; }
    }
}