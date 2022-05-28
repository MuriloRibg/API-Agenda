using Agenda.Dominio.Disciplinas.Entidades;
using FluentNHibernate.Mapping;

namespace Agenda.Infra.Disciplinas.Mapeamentos
{
    public class DisciplinaMap : ClassMap<Disciplina>
    {
        public DisciplinaMap()
        {
            Table("DISCIPLINAS");
            Id(x => x.Id).Column("ID");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Pilar).Column("PILAR");
            Map(x => x.DeleteAt).Column("DELETEAT");
        }
    }
}