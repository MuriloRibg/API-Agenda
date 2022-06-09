using Agenda.DataTransfer.Turmas.Requests;
using Agenda.DataTransfer.Turmas.Responses;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Turmas.Servicos.Interfaces
{
    public interface ITurmasAppServico
    {
        TurmaResponse Recuperar(int id);
        PaginacaoConsulta<TurmaResponse> Listar(TurmaListarRequest request);
        TurmaResponse Inserir(TurmaInserirRequest request);
        TurmaResponse Editar(int id, TurmaEditarRequest request);
        void Excluir(int id);
    }
}