using System;

namespace Agenda.DataTransfer.Disciplinas.Responses
{
    public class DisciplinaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pilar { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}