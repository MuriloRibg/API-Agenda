using Agenda.Dominio.Turmas.Entidades;
using Libraries.Dominio.Repositorios.Interfaces;

namespace Agenda.Dominio.Turmas.Repositorios
{
    public interface ITurmasRepositorio : IRepositorioNHibernate<Turma> { }
}