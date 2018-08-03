using FluentNHibernate.Mapping;
using ProjetoDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace ProjetoDDD.Infra.Data.EntityConfig
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.ClienteId);
            Map(x => x.Nome);
            Map(x => x.Cpf);
            Map(x => x.DataCadastro);

            HasMany(x => x.Produtos).KeyColumn("ClienteId").Cascade.AllDeleteOrphan().Access.Property().Inverse();

            Table("Cliente");
        }
    }
}
