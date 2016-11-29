using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.Persistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        #region FIELD
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GET
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.GrupoRepository.Listar();

            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var Grupo = _unit.GrupoRepository.BuscarPorId(id);

            return View(Grupo);
        }



        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(Grupo g)
        {
            _unit.GrupoRepository.Cadastrar(g);
            _unit.Salvar();

            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public ActionResult Editar(Grupo g)
        {
            _unit.GrupoRepository.Atualizar(g);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int grupoId)
        {
            try
            {
                _unit.GrupoRepository.Remover(grupoId);
                _unit.Salvar();
                TempData["mensagem"] = "Grupo e Projeto removidos com sucesso!";
            }
            catch (Exception)
            {
                TempData["mensagem"] = "Grupo e Projeto não podem ser excluidos pois possuem aluno(s) relacionados";
            }
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