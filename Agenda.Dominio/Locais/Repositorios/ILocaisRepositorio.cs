using Agenda.Dominio.Locais.Entidades;
using Libraries.Dominio.Repositorios.Interfaces;

namespace Agenda.Dominio.Locais.Repositorios
{
    public interface ILocaisRepositorio : IRepositorioNHibernate<Local> { }
}