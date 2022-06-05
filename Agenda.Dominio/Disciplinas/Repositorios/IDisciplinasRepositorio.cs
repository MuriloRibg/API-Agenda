using Agenda.Dominio.Disciplinas.Entidades;
using Libraries.Dominio.Repositorios.Interfaces;

namespace Agenda.Dominio.Disciplinas.Repositorios
{
    public interface IDisciplinasRepositorio : IRepositorioNHibernate<Disciplina> { }
}