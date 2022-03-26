using AutoMapper;
using Poc_GraphQL.Application.Models.Request;
using Poc_GraphQL.Application.Models.Response;
using Poc_GraphQL.Domain.Entities;

namespace Poc_GraphQL.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerRequest, CustomerEntity>().ReverseMap();
            CreateMap<CustomerEntity, CustomerResponse>().ReverseMap();


            CreateMap<CustomerRequest, CustomerEntity>().ReverseMap();
            CreateMap<CustomerEntity, CustomerResponse>().ReverseMap();
        }

    }

}
