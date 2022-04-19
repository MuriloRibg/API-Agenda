using System.Collections.Generic;
using Agenda.DataTransfer.Instrutores.Requests;
using Agenda.DataTransfer.Instrutores.Responses;

namespace Agenda.Aplicacao.Instrutores.Servicos.Interfaces
{
    public interface IInstrutorAppServico
    {
        IEnumerable<InstrutorResponse> Listar();
        InstrutorResponse Recuperar(int id);
        InstrutorResponse Inserir(InstrutorRequest request);
        InstrutorResponse Atualizar(int id, InstrutorRequest request);
    }
}