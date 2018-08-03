using AutoMapper;
using ProjetoDDD.Domain.Entities;
using ProjetoMVC.ViewModels;

namespace ProjetoMVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}