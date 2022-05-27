using Agenda.Dominio.Categorias.Entidades;
using Libraries.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Categorias.Repositorios
{
    public interface ICategoriasRepositorio : IRepositorioNHibernate<Categoria>
    {
    }
}
