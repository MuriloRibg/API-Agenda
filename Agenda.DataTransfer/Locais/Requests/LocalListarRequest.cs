using System;
using Libraries.Dominio.Filtros;
using Libraries.Dominio.Filtros.Enumeradores;

namespace Agenda.DataTransfer.Locais.Requests
{
    public class LocalListarRequest : PaginacaoFiltro
    {
        public string Nome { get; set; }

        public int Capacidade { get; set; }

        public int Sistemas { get; set; }

        public LocalListarRequest() : base(cpOrd: "Nome", tpOrd: TipoOrdenacaoEnum.Asc)
        {
        }
    }
}