using Agenda.Dominio.Categorias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Categorias.Servicos.Interfaces
{
    public interface ICategoriaServico
    {
        Categoria Atualizar(int id, string pilar, string nomeCategoria, string cor);
        Categoria Instanciar(string pilar, string nomeCategoria, string cor);
        Categoria Validar(int id);
    }
}
