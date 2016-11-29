using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.Persistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.Persistencia.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private PortalContext _context = new PortalContext();

        private IGenericRepository<Aluno> _alunoRepository;

        private IProfessorRepository _professorRepository;

        private IGenericRepository<Grupo> _grupoRepository;


        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if(_alunoRepository == null)
                {
                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository;
            }
    
        }

        public IGenericRepository<Grupo> GrupoRepository
        {
            get
            {
                if(_grupoRepository == null)
                {
                    _grupoRepository = new GenericRepository<Grupo>(_context);
                }
                return _grupoRepository;
            }
            
        }

        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if(_professorRepository == null)
                {
                    _professorRepository = new ProfessorRepository(_context);
                }

                return _professorRepository;
            }
            
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
