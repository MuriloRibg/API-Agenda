using Agenda.Dominio.Locais.Entidades;
using FluentNHibernate.Mapping;

namespace Agenda.Infra.Locais.Mapeamentos
{
    public class LocalMap : ClassMap<Local>
    {
        public LocalMap()
        {
            Table("LOCAIS");
            Id(l => l.Id).Column("ID");
            Map(l => l.Nome).Column("NOME");
            Map(l => l.Capacidade).Column("CAPACIDADE");
            Map(l => l.Sistemas).Column("SISTEMAS");
            Map(l => l.DeleteAt).Column("DELETEAT");
        }
    }
}