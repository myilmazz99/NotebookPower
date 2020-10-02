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
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Specifications, s => s.MapFrom(i => i.ProductSpecifications.Select(i => i.Specification)))
                .ForMember(i => i.CategoryName, j => j.MapFrom(k => k.Category.CategoryName));
            CreateMap<ProductDto, Product>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageDto, ProductImage>();

            CreateMap<Specification, SpecificationDto>();
            CreateMap<SpecificationDto, Specification>();

            CreateMap<Order, OrderDto>().ForMember(x => x.ShortDate, y => y.MapFrom(i => i.OrderDate.ToShortDateString()));
            CreateMap<OrderDto, Order>();

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();

            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();

            CreateMap<Feedback, FeedbackDto>();
            CreateMap<FeedbackDto, Feedback>();

            CreateMap<EmailList, EmailListDto>();
            CreateMap<EmailListDto, EmailList>();

            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();

            CreateMap<Favorite, FavoriteDto>().ForMember(i => i.ProductImage, j => j.MapFrom(k => k.Product.ProductImages[0].ImageUrl));
            CreateMap<FavoriteDto, Favorite>();
        }
    }
}
