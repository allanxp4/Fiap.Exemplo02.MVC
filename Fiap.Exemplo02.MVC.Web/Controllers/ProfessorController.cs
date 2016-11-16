using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class ProfessorController : Controller
    {

        #region FIELD

        private UnitOfWork _unit = new UnitOfWork();

        #endregion

        #region GET

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.ProfessorRepository.Listar();

            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var Professor = _unit.ProfessorRepository.BuscarPorId(id);

            return View(Professor);
        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(Professor p)
        {
            _unit.ProfessorRepository.Cadastrar(p);
            _unit.Salvar();

            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public ActionResult Editar(Professor p)
        {
            _unit.ProfessorRepository.Atualizar(p);
            _unit.Salvar();

            return RedirectToAction("listar");
        }

        [HttpPost]
        public ActionResult Remover(int idProfessor)
        {
            _unit.ProfessorRepository.Remover(idProfessor);
            _unit.Salvar();
            TempData["mensagem"] = "Professor removido com sucesso!";

            return RedirectToAction("Listar");
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