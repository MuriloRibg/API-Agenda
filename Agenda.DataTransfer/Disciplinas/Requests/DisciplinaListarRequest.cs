using Libraries.Dominio.Filtros;
using Libraries.Dominio.Filtros.Enumeradores;
using System;

namespace Agenda.DataTransfer.Disciplinas.Requests
{
    public class DisciplinaListarRequest : PaginacaoFiltro
    {
        public string Nome { get; set; }
        public string Pilar { get; set; }
        public string Ativo { get; set; }

        public DisciplinaListarRequest() : base(cpOrd: "Nome", tpOrd: TipoOrdenacaoEnum.Asc) { }
    }
}