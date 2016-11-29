using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.Persistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Fiap.Exemplo02.Persistencia.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected PortalContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(PortalContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Atualizar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).ToList();
        }

        public virtual T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public virtual ICollection<T> Listar()
        {
            return _dbSet.ToList();
        }

        public virtual void Remover(int id)
        {
            var Entity = BuscarPorId(id);
            _dbSet.Remove(Entity);
        }
    }
}