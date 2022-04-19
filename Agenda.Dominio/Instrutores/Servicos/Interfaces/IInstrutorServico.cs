using Agenda.Dominio.Instrutores.Entidades;

namespace Agenda.Dominio.Instrutores.Servicos.Interfaces
{
    public interface IInstrutorServico
    {
        Instrutor Validar(int idInstrutor);
        Instrutor Atualizar(int id, string nome, string abreviacao, string email, bool disponibilidade, string pilar);
        Instrutor Instanciar(string nome, string abreviacao, string email, bool disponibilidade, string pilar);
    }
}