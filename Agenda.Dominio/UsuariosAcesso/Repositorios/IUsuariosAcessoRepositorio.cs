using Agenda.Dominio.UsuariosAcesso.Entidades;
using Libraries.Dominio.Repositorios.Interfaces;

namespace Agenda.Dominio.UsuariosAcesso.Repositorios
{
    public interface IUsuariosAcessoRepositorio : IRepositorioNHibernate<UsuarioAcesso>
    {
        string CriptografarSenhaAcesso(string login, string senha);
        string GerarTokenJwt(SessaoAcesso sessao);
    }
}