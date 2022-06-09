using System;
using Agenda.DataTransfer.Categorias.Responses;
using Agenda.Dominio.Categorias.Entidades;
using Libraries.Dominio.Filtros;
using Libraries.Dominio.Filtros.Enumeradores;

namespace Agenda.DataTransfer.Turmas.Requests
{
    public class TurmaListarRequest : PaginacaoFiltro
    {
        public string Nome { get; set; }
        public int QuantidadeAlunos { get; protected set; }
        public int IdCategoria { get; protected set; }
        public DateTime DeleteAt { get; set; }
        public TurmaListarRequest() : base(cpOrd: "Nome", tpOrd: TipoOrdenacaoEnum.Asc) { }
    }
}