namespace Agenda.DataTransfer.UsuariosAcesso.Responses
{
    public class UsuarioAcessoSessaoResponse
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Jwt { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}