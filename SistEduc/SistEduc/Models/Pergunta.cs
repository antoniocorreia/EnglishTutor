//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistEduc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pergunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pergunta()
        {
            this.Alternativa = new HashSet<Alternativa>();
            this.AlunoRespostaPergunta = new HashSet<AlunoRespostaPergunta>();
        }
    
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public Nullable<int> IdTema { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alternativa> Alternativa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlunoRespostaPergunta> AlunoRespostaPergunta { get; set; }
        public virtual Tema Tema { get; set; }
    }
}
