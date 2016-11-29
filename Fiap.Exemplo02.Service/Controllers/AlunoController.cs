using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.Persistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fiap.Exemplo02.Service.Controllers
{
    public class AlunoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ICollection<Aluno> Get()
        {
            return _unit.AlunoRepository.Listar();
        }
        
        public Aluno Get(int id)
        {
            return _unit.AlunoRepository.BuscarPorId(id);
        } 
    }
}
