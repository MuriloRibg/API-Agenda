using Libraries.Dominio.Consultas;
using Libraries.Dominio.Filtros.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Dominio.Repositorios.Interfaces
{
    public interface IRepositorioNHibernate<T> where T : class
    {

        void Inserir(T entidade);
        void Inserir(IEnumerable<T> entidades);
        void Editar(T entidade);
        void Excluir(T entidade);
        void Excluir(IEnumerable<T> entidades);
        T Recuperar(int id);
        T Recuperar(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
        PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd);
        void Refresh(T entidade);
    }
}