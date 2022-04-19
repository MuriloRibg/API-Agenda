using Libraries.Dominio.Excecoes;

namespace Agenda.Dominio.Instrutores.Entidades
{
    public class Instrutor
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; set; }
        public virtual string Abreviacao { get; set; }
        public virtual string Email { get; set; }
        public virtual bool Disponibilidade { get; set; }
        public virtual string Pilar { get; set; }
       
        public Instrutor() { }
        public Instrutor(string nome, string abreviacao, string email, bool disponibilidade, string pilar)
        {
            SetNome(nome);
            SetAbreviacao(abreviacao);
            SetEmail(email);
            SetDisponibilidade(disponibilidade);
            SetPilar(pilar);
        }

        public virtual void SetNome(string nome) 
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new AtributoObrigatorioExcecao("Nome");

            this.Nome = nome;
        }

        public virtual void SetAbreviacao(string abreviacao) 
        {
            if (string.IsNullOrWhiteSpace(abreviacao))
                throw new AtributoObrigatorioExcecao("Abreviação");

            this.Abreviacao = abreviacao;
        }

        public virtual void SetEmail(string email) 
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new AtributoObrigatorioExcecao("E-mail");

            this.Email = email;
        }

        public virtual void SetDisponibilidade(bool disponibilidade) 
        {
            if (disponibilidade == false)
                throw new AtributoObrigatorioExcecao("Disponibilidade");

            this.Disponibilidade = disponibilidade;
        }

        public virtual void SetPilar(string pilar) 
        {
            if (string.IsNullOrWhiteSpace(pilar))
                throw new AtributoObrigatorioExcecao("Pilar");

            this.Pilar = pilar;
        }
    }
}