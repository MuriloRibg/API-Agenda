using Agenda.DataTransfer.UsuariosAcesso.Requests;
using Agenda.DataTransfer.UsuariosAcesso.Responses;

namespace Agenda.Aplicacao.UsuariosAcesso.Servicos.Interfaces
{
    public interface IUsuariosAcessoAppServico
    {
        UsuarioAcessoResponse Inserir(UsuarioAcessoRequest request);
    }
}