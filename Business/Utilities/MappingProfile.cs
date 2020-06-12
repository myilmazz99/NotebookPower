using AutoMapper;
using Core.Entities.Concrete;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(d => d.Specifications, s => s.MapFrom(i=>i.ProductSpecifications.Select(i=>i.Specification)));
            CreateMap<ProductDto, Product>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageDto, ProductImage>();

            CreateMap<Specification, SpecificationDto>();
            CreateMap<SpecificationDto, Specification>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();

            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();

            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();
        }
    }
}
