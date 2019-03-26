using AutoMapper;
using AgnusCrm.Application.ViewModels;
using AgnusCrm.Domain.Models;

namespace AgnusCrm.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
