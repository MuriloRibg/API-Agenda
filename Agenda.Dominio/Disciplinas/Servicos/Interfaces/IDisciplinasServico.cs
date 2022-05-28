using Agenda.Dominio.Disciplinas.Entidades;

namespace Agenda.Dominio.Disciplinas.Servicos.Interfaces
{
    public interface IDisciplinasServico
    {
        Disciplina Validar(int id);
    }
}