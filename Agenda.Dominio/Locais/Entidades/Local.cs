using System;
using Libraries.Dominio.Excecoes;
using Libraries.Util.Extensoes;

namespace Agenda.Dominio.Locais.Entidades
{
    public class Local
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual int Capacidade { get; protected set; }
        public virtual int Sistemas { get; protected set; }
        public virtual DateTime DeleteAt { get; protected set; }

        protected Local() { }

        public Local(string nome, int capacidade, int sistemas)
        {
            SetNome(nome);
            SetCapacidade(capacidade);
            SetSistemas(sistemas);
        }
        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new AtributoObrigatorioExcecao("Nome do local");
            Nome = nome;
        }
        public virtual void SetCapacidade(int capacidade)
        {
            if(capacidade <= 0)
                throw new AtributoObrigatorioExcecao("Capacidade do local");
            Capacidade = capacidade;
        }

        public virtual void SetSistemas(int sistemas)
        {
            if (sistemas < 0)
                throw new AtributoObrigatorioExcecao("Sistemas do local");
            Sistemas = sistemas;
        }

        public virtual void SetDeleteAt(DateTime deleteAt)
        {
            DeleteAt = deleteAt;
        }
    }
}