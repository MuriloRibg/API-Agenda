using System.Collections.Generic;

namespace Libraries.Dominio.Consultas
{
    public class PaginacaoConsulta<T> where T : class
    {
        public long Total { get; set; }
        public IEnumerable<T> Registros { get; set; }
    }
}