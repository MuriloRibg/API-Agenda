using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Dominio.Categorias.Entidades;
using Agenda.Dominio.Categorias.Repositorios;
using Libraries.NHibernate.Repositorios;
using Microsoft.AspNetCore.Http;
using ISession = NHibernate.ISession;

namespace Agenda.Infra.Categorias.Repositorios
{
    public class CategoriaRepositorio : RepositorioNHibernate<Categoria>, ICategoriasRepositorio
    {
        public CategoriaRepositorio(ISession session) : base(session)
        {
        }
    }
}
