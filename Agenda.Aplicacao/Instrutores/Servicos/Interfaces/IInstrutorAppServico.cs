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
<<<<<<< HEAD
        InstrutorResponse Inserir(InstrutorRequest request);
        InstrutorResponse Atualizar(int id, InstrutorRequest request);
        InstrutorResponse Deletar(int id);
=======
        InstrutorResponse Inserir(InstrutorInserirRequest request);
        InstrutorResponse Atualizar(int id, InstrutorInserirRequest request);
>>>>>>> 4028d23cfa0ea3d739b7d969d1a135902f36288c
    }
}