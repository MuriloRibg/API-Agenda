using NHibernate.Dialect;

namespace Agenda.DataTransfer.Turmas.Requests
{
    public class TurmaInserirRequest
    {
        public string Nome { get; set; }
        public int QuantidadeAlunos { get; set; }
        public int IdCategoria { get; set; }
    }
}