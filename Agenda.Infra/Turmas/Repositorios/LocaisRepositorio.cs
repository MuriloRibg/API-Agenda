using Agenda.Dominio.Turmas.Entidades;
using Agenda.Dominio.Turmas.Repositorios;
using Libraries.NHibernate.Repositorios;
using NHibernate;

namespace Agenda.Infra.Turmas.Repositorios
{
    public class LocaisRepositorio : RepositorioNHibernate<Turma>, ITurmasRepositorio
    {
        public LocaisRepositorio(ISession session) : base(session) { }
    }
}