using Agenda.Dominio.Categorias.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infra.Categorias.Mapeamentos
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Table("CATEGORIAS");
            Id(p => p.Id).Column("ID");
            Map(x => x.Pilar).Column("PILAR");
            Map(x => x.NomeCategoria).Column("CATEGORIA");
            Map(x => x.Cor).Column("COR");
            Map(x => x.DeleteAt).Column("DELETEAT");
        }
    }
}
