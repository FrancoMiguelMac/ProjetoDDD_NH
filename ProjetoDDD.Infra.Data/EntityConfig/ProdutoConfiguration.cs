using FluentNHibernate.Mapping;
using ProjetoDDD.Domain.Entities;


namespace ProjetoDDD.Infra.Data.EntityConfig
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.ProdutoId);
            Map(x => x.Nome);
            Map(x => x.Valor);

            References(m => m.Cliente, "ClienteId")
                .Not.Nullable()
                .NotFound.Exception();

            Table("Produto");
        }
    }
}
