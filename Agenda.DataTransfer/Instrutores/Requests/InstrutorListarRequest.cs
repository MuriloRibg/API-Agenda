using Agenda.Dominio.Instrutores.Enumeradores;
using Libraries.Dominio.Filtros;
using Libraries.Dominio.Filtros.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DataTransfer.Instrutores.Requests
{
    public class InstrutorListarRequest : PaginacaoFiltro
    {
        public string Nome { get; set; }
        public string Abreviacao { get; set; }
        public string Email { get; set; }
        public DisponibilidadeEnum Disponibilidade { get; set; }
        public string Pilar { get; set; }

        public InstrutorListarRequest() : base(cpOrd: "Nome", tpOrd: TipoOrdenacaoEnum.Asc) { }
    
    }
}
