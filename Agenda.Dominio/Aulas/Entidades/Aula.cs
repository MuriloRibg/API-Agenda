using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Reservas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Aulas.Entidades
{
    public class Aula : Reserva
    {
        public virtual Instrutor Instrutor { get; protected set; }
        public virtual int IdTurma{ get; protected set; }
        public virtual int IdDisciplina { get; protected set; }

        public Aula(){  }

        public Aula(Instrutor instrutor, int idTurma, int idDisciplina){
            SetInstrutor(instrutor);
            SetTurma(idTurma);
            SetDisciplina(idDisciplina);
        }

        public virtual void SetInstrutor(Instrutor instrutor)
        {
            this.Instrutor = instrutor;
        }

        public virtual void SetTurma(int turma)
        {
            this.IdTurma = turma;
        }

        public virtual void SetDisciplina(int disciplina)
        {
            this.IdDisciplina = disciplina;
        }
    }
}
