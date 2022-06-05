using Agenda.DataTransfer.Locais.Requests;
using Agenda.DataTransfer.Locais.Responses;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Locais.Servicos.Interfaces
{
    public interface ILocaisAppServico
    {
        LocalResponse Recuperar(int id);
        PaginacaoConsulta<LocalResponse> Listar(LocalListarRequest request);
        LocalResponse Inserir(LocalInserirRequest request);
        LocalResponse Editar(int id, LocalEditarRequest request);
        void Excluir(int id);
    }
}