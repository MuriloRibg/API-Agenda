using Agenda.Dominio.Instrutores.Enumeradores;

namespace Agenda.DataTransfer.Instrutores.Responses
{
    public class InstrutorResponse
    {
        public int Id { get; protected set; }
        public string Nome { get; set; }
        public string Abreviacao { get; set; }
        public string Email { get; set; }
        public DisponibilidadeEnum Disponibilidade { get; set; }
        public string Pilar { get; set; }
    }
}