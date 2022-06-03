using System.Collections.Generic;
using Agenda.DataTransfer.Instrutores.Requests;
using Agenda.DataTransfer.Instrutores.Responses;
using Libraries.Dominio.Consultas;

namespace Agenda.Aplicacao.Instrutores.Servicos.Interfaces
{
    public interface IInstrutorAppServico
    {
        PaginacaoConsulta<InstrutorResponse> Listar(InstrutorListarRequest request);
        InstrutorResponse Recuperar(int id);
        InstrutorResponse Inserir(InstrutorInserirRequest request);
        InstrutorResponse Atualizar(int id, InstrutorInserirRequest request);
    }
}