using Agenda.Dominio.Aulas.Entidades;
using Agenda.Dominio.Aulas.Repositorios;
using Libraries.NHibernate.Repositorios;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infra.Aulas.Repositorios
{
    public class AulaRepositorio : RepositorioNHibernate<Aula>, IAulaRepositorio
    {
        public AulaRepositorio(ISession session) : base(session)
        {
        }
    }
}
