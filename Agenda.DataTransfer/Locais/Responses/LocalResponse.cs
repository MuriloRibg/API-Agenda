using System;

namespace Agenda.DataTransfer.Locais.Responses
{
    public class LocalResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public int Sistemas { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}