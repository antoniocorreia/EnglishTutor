﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sisteducAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbSistemasEducacionaisEntities1 : DbContext
    {
        public dbSistemasEducacionaisEntities1()
            : base("name=dbSistemasEducacionaisEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alternativa> Alternativa { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AlunoRespostaPergunta> AlunoRespostaPergunta { get; set; }
        public virtual DbSet<Pergunta> Pergunta { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
    }
}
