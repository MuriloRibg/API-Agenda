using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DataTransfer.Categorias.Responses
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Pilar { get; set; }
        public string NomeCategoria { get; set; }
        public string Cor { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}
