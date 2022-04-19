namespace Agenda.DataTransfer.Instrutores.Responses
{
    public class InstrutorResponse
    {
        public int Id { get; protected set; }
        public string Nome { get; set; }
        public string Abreviacao { get; set; }
        public string Email { get; set; }
        public bool Disponibilidade { get; set; }
        public string Pilar { get; set; }
    }
}