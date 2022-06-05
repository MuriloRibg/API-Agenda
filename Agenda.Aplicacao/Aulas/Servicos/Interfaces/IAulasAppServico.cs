using Agenda.Dominio.Aulas.Entidades;
using Agenda.DataTransfer.Aulas.Requests;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Dominio.Excecoes;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Aulas.Servicos.Interfaces
{
    public interface IAulasAppServico
    {
        PaginacaoConsulta<Aula> Listar(AulaListarRequest request);
    }
}
