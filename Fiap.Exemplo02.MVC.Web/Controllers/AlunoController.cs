using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
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
        public ActionResult Cadastrar()
        {
            //buscar Todos grupos casdastrados
            var lista = _unit.GrupoRepository.Listar();
            var lista2 = _unit.ProfessorRepository.Listar();

            ViewBag.professores = new SelectList(lista2, "Id", "Nome");
            ViewBag.grupos = new SelectList(lista, "Id", "Nome");

            return View("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //Include -> busca o relacionamento (preenche o grupo que o aluno não possui), faz o join.
            var lista = _unit.AlunoRepository.Listar();
            CarregarComboGrupo();

            return View(lista);
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
            if (idGrupo == null)
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));
            }
            else
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && a.GrupoId == idGrupo);
            }

            CarregarComboGrupo();


            return View("Listar", lista);
        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(Aluno a)
        {
            _unit.AlunoRepository.Cadastrar(a);
            _unit.Salvar();

            TempData["msg"] = "Cadastrado com sucesso";

            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public ActionResult Editar(Aluno a)
        {
            _unit.AlunoRepository.Atualizar(a);
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