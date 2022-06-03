using Libraries.Dominio.Consultas;
using Libraries.Dominio.Excecoes;
using Libraries.Dominio.Filtros.Enumeradores;
using Libraries.Dominio.Repositorios.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace Libraries.NHibernate.Repositorios
{
    public class RepositorioNHibernate<T> : IRepositorioNHibernate<T> where T : class
    {
        protected readonly ISession session;

        public RepositorioNHibernate(ISession session)
        {
            this.session = session;
        }

        public void Editar(T entidade)
        {
            session.Update(entidade);
        }

        public void Excluir(T entidade)
        {
            session.Delete(entidade);
        }

        public void Excluir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                session.Delete(entidade);
            }
        }

        public void Inserir(T entidade)
        {
            session.Save(entidade);
        }

        public void Inserir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                session.Save(entidade);
            }
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd)
        {
            var resultado = new PaginacaoConsulta<T>();

            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd.ToString());

                resultado.Registros = query.Skip((pg - 1) * qt).Take(qt).ToList();
                resultado.Total = query.Count();

                return resultado;
            }
            catch (ParseException)
            {
                throw new CampoParaOrdernacaoInformadoNaoEValidoExcecao(cpOrd);
            }
        }

        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }

        public T Recuperar(Expression<Func<T, bool>> expression)
        {
            return Query().Where(expression).SingleOrDefault();
        }

        public void Refresh(T entidade)
        {
            session.Refresh(entidade);
        }
    }
}
