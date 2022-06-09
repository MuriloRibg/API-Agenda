using System;
using Agenda.DataTransfer.Categorias.Responses;

namespace Agenda.DataTransfer.Turmas.Responses
{
    public class TurmaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeAlunos { get; set; }
        public CategoriaResponse Categoria { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}