namespace Agenda.Dominio.UsuariosAcesso.Entidades
{
    public class SessaoAcesso
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Jwt { get; set; }
        public bool DoisFatores { get; set; }
    }
}