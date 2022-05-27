using Libraries.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Categorias.Entidades
{
    public class Categoria
    {
        public virtual int Id { get; set; }
        public virtual string Pilar { get; set; }
        public virtual string NomeCategoria { get; set; }
        public virtual string Cor { get; set; }
        public virtual DateTime DeleteAt { get; set; }
    
        public Categoria() { }

        public Categoria(string pilar, string categoria, string cor) 
        {
            SetPilar(pilar);
            SetCategoria(categoria);
            SetCor(cor);
        }

        public virtual void SetPilar(string pilar)
        {
            if (string.IsNullOrWhiteSpace(pilar))
                throw new AtributoObrigatorioExcecao("Pilar");

            this.Pilar = pilar;
        }

        public virtual void SetCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
                throw new AtributoObrigatorioExcecao("Categoria");

            this.NomeCategoria = categoria;
        }

        public virtual void SetCor(string cor)
        {
            if (string.IsNullOrWhiteSpace(cor))
                throw new AtributoObrigatorioExcecao("Cor");

            this.Cor = cor;
        }

        public virtual void SetData(DateTime deleteAt)
        {
            this.DeleteAt = deleteAt;
        }
    }
}
