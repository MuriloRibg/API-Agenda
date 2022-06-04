using Agenda.Dominio.Instrutores.Enumeradores;
using System;

namespace Agenda.DataTransfer.Instrutores.Requests
{
    public class InstrutorInserirRequest
    {
        public string Nome { get; set; }
        public string Abreviacao { get; set; }
        public string Email { get; set; }
        public DisponibilidadeEnum Disponibilidade { get; set; }
        public string Pilar { get; set; }
    }
}