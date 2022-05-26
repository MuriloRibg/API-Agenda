using Agenda.Dominio.Aulas.Entidades;
using Libraries.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Aulas.Repositorios
{
    public interface IAulaRepositorio : IRepositorioNHibernate<Aula>
    {
    }
}
