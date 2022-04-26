using Libraries.Dominio.Excecoes;

namespace Agenda.Dominio.UsuariosAcesso.Excecoes
{
    public class UsuarioCadastradoExcecao : RegraDeNegocioExcecao
    {
        public UsuarioCadastradoExcecao() : base("Usuário já cadastrado")
        {

        }
    }
}