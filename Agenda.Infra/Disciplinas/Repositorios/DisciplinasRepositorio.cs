using Agenda.Dominio.Disciplinas.Entidades;
using Agenda.Dominio.Disciplinas.Repositorios;
using Libraries.NHibernate.Repositorios;
using NHibernate;

namespace Agenda.Infra.Disciplinas.Repositorios
{
    public class DisciplinasRepositorio : RepositorioNHibernate<Disciplina>, IDisciplinasRepositorio
    {
        public DisciplinasRepositorio(ISession session) : base(session) { }
    }
}