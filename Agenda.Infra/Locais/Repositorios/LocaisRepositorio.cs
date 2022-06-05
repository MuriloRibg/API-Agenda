using Agenda.Dominio.Locais.Entidades;
using Agenda.Dominio.Locais.Repositorios;
using Libraries.NHibernate.Repositorios;
using NHibernate;

namespace Agenda.Infra.Locais.Repositorios
{
    public class LocaisRepositorio : RepositorioNHibernate<Local>, ILocaisRepositorio
    {
        public LocaisRepositorio(ISession session) : base(session) { }
    }
}