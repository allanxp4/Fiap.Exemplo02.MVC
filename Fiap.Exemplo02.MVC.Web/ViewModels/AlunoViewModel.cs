using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.ViewModels
{
    public class AlunoViewModel
    {
        public ICollection<Aluno> Alunos { get; set; }
        public SelectList Grupos { get; set; }
        public SelectList ListaGrupo { get; set; }
        public string Mensagem { get; set; }

        #region Aluno properties
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public Nullable<double> Desconto { get; set; }
        public bool Bolsa { get; set; }
        [Display(Name = "Grupo")]
        public int GrupoId { get; set; }
        #endregion
    }
}