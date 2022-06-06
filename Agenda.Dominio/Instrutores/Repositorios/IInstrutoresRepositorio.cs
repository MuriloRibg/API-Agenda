using Agenda.Dominio.Instrutores.Entidades;
using Libraries.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;

namespace Agenda.Dominio.Instrutores.Repositorios
{
    public interface IInstrutoresRepositorio : IRepositorioNHibernate<Instrutor>
    {
        IList<Instrutor> InstrutorEmAula();
    }
}