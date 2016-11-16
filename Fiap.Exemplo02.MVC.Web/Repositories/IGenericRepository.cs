using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IGenericRepository<T>
    {
        void Cadastrar(T entidade);
        ICollection<T> Listar();
        T BuscarPorId(int id);
        void Atualizar(T entidade);
        void Remover(int id);
        ICollection<T> BuscarPor(Expression<Func<T,bool>>filtro);

    }
}
