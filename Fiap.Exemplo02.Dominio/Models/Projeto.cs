//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fiap.Exemplo02.Dominio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.DateTime DataInicio { get; set; }
        public Nullable<System.DateTime> DataTermino { get; set; }
        public bool Entregue { get; set; }
    
        public virtual Grupo Grupo1 { get; set; }
    }
}