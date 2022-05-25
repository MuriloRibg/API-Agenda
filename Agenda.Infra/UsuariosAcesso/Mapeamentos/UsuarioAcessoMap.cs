using Agenda.Dominio.UsuariosAcesso.Entidades;
using FluentNHibernate.Mapping;

namespace Agenda.Infra.UsuariosAcesso.Mapeamentos
{
    public class UsuarioAcessoMap : ClassMap<UsuarioAcesso>
    {
        public UsuarioAcessoMap()
        {
            Table("USUARIOACESSO");
            Id(p => p.Id).Column("ID");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Email).Column("EMAIL");
            Map(x => x.Login).Column("LOGIN");
            Map(x => x.Senha).Column("SENHA");
            Map(x => x.DataCadastro).Column("DataCadastro");
        }
    }
}