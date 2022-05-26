using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Reservas.Entidades
{
    public class Reserva
    {
        public virtual int Id { get; protected set; }
        public virtual int IdLocal { get; protected set; }
        public virtual string Titulo { get; protected set; }
        public virtual DateTime DataInicio { get; protected set; }
        public virtual DateTime HoraInicio { get; protected set; }
        public virtual DateTime HoraFim { get; protected set; }
        public virtual DateTime DeleteAt { get; protected set; }
        public virtual string Descricao { get; protected set; }

    }
}
