using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Instrutores.Repositorios;
using Libraries.NHibernate.Repositorios;
using NHibernate;

namespace Agenda.Infra.Instrutores.Repositorios
{
    public class InstrutorRepositorio : RepositorioNHibernate<Instrutor>, IInstrutoresRepositorio
    {
        public InstrutorRepositorio(ISession session) : base(session) { }
    }
}