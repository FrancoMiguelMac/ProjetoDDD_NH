using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoDDD.Application.Interfaces
{
    public interface IProdutoAppService 
    {
        IEnumerable<Produto> GetAllByClienteId(int clienteId);

        Produto GetById(int id);

        void Add(Produto produto, int clienteId);

        void Update(Produto produto);

        void Remove(Produto produto);
    }
}
