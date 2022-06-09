using Agenda.Dominio.Turmas.Entidades;
using FluentNHibernate.Mapping;

namespace Agenda.Infra.Turmas.Mapeamentos
{
    public class TurmaMap : ClassMap<Turma>
    {
        public TurmaMap()
        {
            Table("TURMAS");
            Id(t => t.Id).Column("ID");
            Map(t => t.Nome).Column("NOME");
            Map(t => t.QuantidadeAlunos).Column("QUANT_ALUNOS");
            References(t => t.Categoria).Column("ID_CATEGORIA").LazyLoad().NotFound.Ignore();
            Map(x => x.DeleteAt).Column("DELETEAT");
        }
    }
}