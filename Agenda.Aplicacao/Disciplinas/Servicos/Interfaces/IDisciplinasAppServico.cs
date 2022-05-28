using Agenda.DataTransfer.Disciplinas.Requests;
using Agenda.DataTransfer.Disciplinas.Responses;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Disciplinas.Servicos.Interfaces
{
    public interface IDisciplinasAppServico
    {
        DisciplinaResponse Recuperar(int id);
        PaginacaoConsulta<DisciplinaResponse> Listar(DisciplinaListarRequest request);
        DisciplinaResponse Inserir(DisciplinaInserirRequest request);
        DisciplinaResponse Editar(int id, DisciplinaEditarRequest request);
        void Excluir(int id);
    }
}