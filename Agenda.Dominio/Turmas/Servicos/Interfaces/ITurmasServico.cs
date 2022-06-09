using Agenda.Dominio.Turmas.Entidades;

namespace Agenda.Dominio.Turmas.Servicos.Interfaces
{
    public interface ITurmasServico
    {
        Turma Validar(int id);
    }
}