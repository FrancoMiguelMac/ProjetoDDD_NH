using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoDDD.Application.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<Cliente> GetAll();

        Cliente GetById(int id);

        void Add(Cliente cliente);

        void Update(Cliente cliente);

        void Remove(Cliente cliente);
    }
}
