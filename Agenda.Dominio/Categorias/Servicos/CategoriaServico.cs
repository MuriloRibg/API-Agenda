using Agenda.Dominio.Categorias.Entidades;
using Agenda.Dominio.Categorias.Repositorios;
using Agenda.Dominio.Categorias.Servicos.Interfaces;
using Libraries.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Categorias.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {

        private readonly ICategoriasRepositorio categoriaRepositorio;

        public CategoriaServico(ICategoriasRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public Categoria Atualizar(int id, string pilar, string nomeCategoria, string cor)
        {
            Categoria categoria = this.Validar(id);

            categoria.SetPilar(pilar);
            categoria.SetCategoria(nomeCategoria);
            categoria.SetCor(cor);

            return categoria;
        }

        public Categoria Instanciar(string pilar, string nomeCategoria, string cor)
        {
            Categoria categoria = new Categoria(pilar, nomeCategoria, cor);

            return categoria;
        }

        public Categoria Validar(int id)
        {
            Categoria categoria = categoriaRepositorio.PesquisarPor(id);

            if (categoria == null)
            {
                throw new RegraDeNegocioExcecao("Categoria não encontrada!");
            }

            return categoria;
        }
    }
}
