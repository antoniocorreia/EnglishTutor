using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistEduc.Models
{
    public class AlternativaDto
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public Nullable<int> IdPergunta { get; set; }
        public Nullable<bool> RespostaCorreta { get; set; }
    }
}