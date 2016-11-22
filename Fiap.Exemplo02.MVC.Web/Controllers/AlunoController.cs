using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using Fiap.Exemplo02.MVC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        #region FIELD

        //private PortalContext _context = new PortalContext();
        private UnitOfWork _unit = new UnitOfWork();

        #endregion

        #region GET

        [HttpGet]
        public ActionResult Cadastrar(string msg) //PORQUE EXISTE A MERDA DO ? ENTÃO????? edit: é pq é string
        {
            //buscar Todos grupos casdastrados
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos()
            };

            return View(viewModel);
        }                 
        

        private SelectList ListarGrupos()
        {
            var lista = _unit.GrupoRepository.Listar();
            return new SelectList(lista, "Id", "Nome");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //Include -> busca o relacionamento (preenche o grupo que o aluno não possui), faz o join.
           
            var lista = _unit.AlunoRepository.Listar();
            var vm = new AlunoViewModel()
            {
                Alunos = lista,
                Grupos = ListarGrupos()
            };
            
            return View(vm);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //buscar o Aluno no banco 
            var Aluno = _unit.AlunoRepository.BuscarPorId(id);
            //Envia o aluno para view
            return View(Aluno);
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca, int? idGrupo)
        {
            ICollection<Aluno> lista;
          
            lista = idGrupo == null ?
                _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca)) :
                _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && a.GrupoId == idGrupo);         
                     
            

            return PartialView("_tabela", lista);
        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel avm)
        {
            var aluno = new Aluno()
            {
                Nome = avm.Nome,
                DataNascimento = avm.DataNascimento,
                Bolsa = avm.Bolsa,
                Desconto = avm.Desconto,
                GrupoId = avm.GrupoId

            };
            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            var viewModel = new AlunoViewModel()
            {
                Mensagem = "Aluno cadastrado!",
                ListaGrupo = ListarGrupos()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Editar(AlunoViewModel a)
        {

            var aluno = new Aluno()
            {
                
                Id = a.Id,
                Nome = a.Nome,
                DataNascimento = a.DataNascimento,
                Desconto = a.Desconto,
                Bolsa = a.Bolsa
            };

            _unit.AlunoRepository.Atualizar(aluno);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Deletar(int alunoId)
        {
            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        #endregion

        #region PRIVATE
        private void CarregarComboGrupo()
        {
            //envia para a tela os 
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }

        #endregion

        #region DISPOSE
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    
        #endregion

    }
}