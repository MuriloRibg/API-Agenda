using System;
using Agenda.Dominio.Categorias.Entidades;
using Libraries.Dominio.Excecoes;
using Libraries.Util.Extensoes;

namespace Agenda.Dominio.Turmas.Entidades
{
    public class Turma
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual int QuantidadeAlunos { get; protected set; }
        public virtual Categoria Categoria { get; protected set; }
        public virtual DateTime DeleteAt { get; protected set; }

        protected Turma() { }

        public Turma(string nome, int quantidadeAlunos, Categoria categoria)
        {
            SetNome(nome);
            SetQuantidadeAlunos(quantidadeAlunos);
            SetCategoria(categoria);
        }
        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new AtributoObrigatorioExcecao("Nome da Turma");
            Nome = nome;
        }
        public virtual void SetQuantidadeAlunos(int quantidadeAlunos)
        {
            if (quantidadeAlunos <= 0)
                throw new AtributoObrigatorioExcecao("Quantidade de alunos");
            QuantidadeAlunos = quantidadeAlunos;
        }
        public virtual void SetCategoria(Categoria categoria)
        {
            if (categoria.IsNull())
                throw new AtributoObrigatorioExcecao("Categoria");
            Categoria = categoria;
        }
        public virtual void SetDeleteAt(DateTime deleteAt)
        {
            DeleteAt = deleteAt;
        }

    }
}