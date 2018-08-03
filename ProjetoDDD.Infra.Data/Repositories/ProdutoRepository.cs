using NHibernate;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> GetAllByClienteId(int clienteId)
        {
            var produtos = GetAll();
            return produtos.Where(x => x.Cliente.ClienteId == clienteId).ToList();
        }
    }
}
