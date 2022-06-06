using Agenda.Dominio.Aulas.Entidades;
using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Instrutores.Repositorios;
using Libraries.NHibernate.Repositorios;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Agenda.Infra.Instrutores.Repositorios
{
    public class InstrutorRepositorio : RepositorioNHibernate<Instrutor>, IInstrutoresRepositorio
    {
        public InstrutorRepositorio(ISession session) : base(session) { }

         public IList<Instrutor> InstrutorEmAula(){

            DetachedCriteria CriteriaFilha =
                   DetachedCriteria.For(typeof(Aula))
            .CreateAlias("Instrutor", "instrutor")
            .SetProjection(
                Projections.Property("instrutor.Nome").As("Instrutor")
            )
            .Add(Expression.EqProperty("Instrutor", "inst.Id"));

            ICriteria criteria =
            session.CreateCriteria<Instrutor>("inst");

            criteria.Add(Subqueries.Exists(CriteriaFilha));

            return criteria.List<Instrutor>();
         }
    }
}