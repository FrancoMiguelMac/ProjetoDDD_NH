using AutoMapper;
using ProjetoDDD.Domain.Entities;
using ProjetoMVC.ViewModels;

namespace ProjetoMVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}