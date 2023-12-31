﻿using AutoMapper;
using Loja.Dtos.CategoryMapper;
using Loja.Dtos.ClientMapper;
using Loja.Dtos.OrderDTOs;
using Loja.Dtos.OrderMapper;
using Loja.Dtos.ProductMapper;

using Loja.Models;
using System.Net.NetworkInformation;

namespace Loja.Dtos.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductOrderDTO>().ReverseMap();
        CreateMap<Product, PostProductDTO>().ReverseMap();

        CreateMap<ProductOrder, ProductsOrderDTO>().ReverseMap();

        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Category, CategoryProductDTO>().ReverseMap();
        CreateMap<Category, PostCategoryDTO>().ReverseMap();

        CreateMap<Customer, CustomerDTO>().ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();
        CreateMap<Customer, PostCustomerDTO>().ReverseMap();
        CreateMap<Customer, CustomerOrderDTO>().ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();
        CreateMap<Customer, CreateCustomerDTO>().ForMember(p => p.Name, opt => opt.MapFrom(p => p.UserName))
            .ForMember(p => p.EmailAdress, opt => opt.MapFrom(p => p.Email)).ReverseMap();


        CreateMap<Order, OrderDTO>().ReverseMap();

    }

}
