using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Instrutores.Enumeradores;
using FluentNHibernate.Mapping;

namespace Agenda.Infra.Instrutores.Mapeamentos
{
    public class InstrutorMap : ClassMap<Instrutor>
    {
        public InstrutorMap()
        {
            Table("INSTRUTORES");
            Id(p => p.Id).Column("ID");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Abreviacao).Column("ABREVIACAO");
            Map(x => x.Email).Column("EMAIL");
            Map(x => x.Disponibilidade).Column("DISPONIBILIDADE").CustomType(typeof(DisponibilidadeEnum));
            Map(x => x.Pilar).Column("PILAR");
            Map(x => x.DeleteAt).Column("DELETEAT");
        }
    }
}