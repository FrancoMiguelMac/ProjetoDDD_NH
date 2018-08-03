using System.Collections.Generic;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;

namespace ProjetoDDD.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteAppService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public void Add(Cliente cliente)
        {
            try
            {
                clienteRepository.Add(cliente);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            return clienteRepository.GetAll();
        }

        public Cliente GetById(int id)
        {
            return clienteRepository.GetById(id);
        }

        public void Update(Cliente cliente)
        {
            try
            {
                clienteRepository.Update(cliente);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Cliente cliente)
        {
            try
            {
                clienteRepository.Remove(cliente);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
