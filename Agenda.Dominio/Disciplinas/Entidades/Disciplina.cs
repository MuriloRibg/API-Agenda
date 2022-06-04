using System;
using Libraries.Dominio.Excecoes;

namespace Agenda.Dominio.Disciplinas.Entidades
{
    public class Disciplina
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Pilar { get; protected set; }
        public virtual DateTime DeleteAt { get; protected set; }

        protected Disciplina()
        {
        }

        public Disciplina(string nome, string pilar)
        {
            SetNome(nome);
            SetPilar(pilar);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new AtributoObrigatorioExcecao("Nome Disciplina");
            Nome = nome;
        }

        public virtual void SetPilar(string pilar)
        {
            if (string.IsNullOrWhiteSpace((pilar)))
                throw new AtributoObrigatorioExcecao("Nome pilar");
            Pilar = pilar;
        }

        public virtual void SetDeleteAt(DateTime data)
        {
            DeleteAt = data;
        }
    }
}