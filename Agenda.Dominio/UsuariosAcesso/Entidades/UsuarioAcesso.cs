using Libraries.Dominio.Excecoes;

namespace Agenda.Dominio.UsuariosAcesso.Entidades
{
    public class UsuarioAcesso
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Login { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Senha { get; protected set; }
        
        protected UsuarioAcesso() { }


        public UsuarioAcesso(string nome, string login, string email)
        {
            SetNome(nome);
            SetLogin(login);
            SetEmail(email);
        }

        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new AtributoObrigatorioExcecao("Nome");
            
            this.Nome = nome;
        }

        public virtual void SetLogin(string login)
        {
            if(string.IsNullOrWhiteSpace(login))
                throw new AtributoObrigatorioExcecao("Login");
            
            this.Login = login;
        }

        public virtual void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new AtributoObrigatorioExcecao("Email");

            this.Email = email;
        }

        public virtual void SetSenha(string senha)
        {
            if(string.IsNullOrWhiteSpace(senha))
                throw new AtributoObrigatorioExcecao("Senha");
            
            this.Senha = senha;
        }
    }

}