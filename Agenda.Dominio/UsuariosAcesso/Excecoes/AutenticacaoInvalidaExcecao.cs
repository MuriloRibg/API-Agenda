using Libraries.Dominio.Excecoes;

namespace Agenda.Dominio.UsuariosAcesso.Excecoes
{
    public class AutenticacaoInvalidaExcecao : RegraDeNegocioExcecao
    {
        public AutenticacaoInvalidaExcecao() : base("Autenticação inválida")
        {

        }
    }
}