using Agenda.Dominio.UsuariosAcesso.Entidades;

namespace Agenda.Dominio.UsuariosAcesso.Servicos.Interfaces
{
    public interface IUsuariosAcessoServico
    {
        UsuarioAcesso Instanciar(string nome, string login, string email, string senha);
        UsuarioAcesso Validar(int id);
    }
}