using Agenda.Dominio.Disciplinas.Entidades;
using FluentNHibernate.Mapping;

namespace Agenda.Infra.Disciplinas.Mapeamentos
{
    public class DisciplinaMap : ClassMap<Disciplina>
    {
        public DisciplinaMap()
        {
            Table("DISCIPLINAS");
            Id(d => d.Id).Column("ID");
            Map(d => d.Nome).Column("NOME");
            Map(d => d.Pilar).Column("PILAR");
            Map(d => d.DeleteAt).Column("DELETEAT");
        }
    }
}