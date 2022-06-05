using Agenda.Dominio.Aulas.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infra.Aulas.Mapeamentos
{
    public class AulaMap : ClassMap<Aula>
    {
        public AulaMap()
        {
            Table("AULAS");
            Id(p => p.Id).Column("ID");
            Map(x => x.Titulo).Column("TITULO").Not.Nullable();
            References(x => x.Instrutor).Column("ID_INSTRUTOR").Not.Nullable();
            Map(x => x.IdLocal).Column("ID_LOCAL").Not.Nullable();
            Map(x => x.IdDisciplina).Column("ID_DISCIPLINA").Not.Nullable();
            Map(x => x.IdTurma).Column("ID_TURMA").Not.Nullable();
            Map(x => x.DataInicio).Column("DATAINICIO").Not.Nullable();
            Map(x => x.HoraInicio).Column("HORAINICIO").Not.Nullable();
            Map(x => x.HoraFim).Column("HORAFIM").Not.Nullable();
            Map(x => x.Descricao).Column("DESCRICAO").Nullable();
            Map(x => x.DeleteAt).Column("DELETEAT").Nullable();
        }
    }
}
