using AutoMapper;
using ERP_API.DTOs;
using ERP_API.Models;

namespace ERP_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.CustomerName, s => s.MapFrom(x => x.CustomerName))
                .ForMember(d => d.CustomerType, s => s.MapFrom(x => x.CustomerType));

            CreateMap<CustomerDTO, Customer>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.CustomerName, s => s.MapFrom(x => x.CustomerName))
                .ForMember(d => d.CustomerType, s => s.MapFrom(x => x.CustomerType));

            CreateMap<Subscription, SubscriptionDTO>()
              .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
              .ForMember(d => d.SubscriptionName, s => s.MapFrom(x => x.SubscriptionName))
              .ForMember(d => d.SubscriptionPrice, s => s.MapFrom(x => x.SubscriptionPrice));

            CreateMap<SubscriptionDTO, Subscription>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.SubscriptionName, s => s.MapFrom(x => x.SubscriptionName))
                .ForMember(d => d.SubscriptionPrice, s => s.MapFrom(x => x.SubscriptionPrice));

            CreateMap<Discount, DiscountDTO>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.DiscountName, s => s.MapFrom(x => x.DiscountName))
                .ForMember(d => d.DiscountType, s => s.MapFrom(x => x.DiscountType))
                .ForMember(d => d.DiscountValue, s => s.MapFrom(x => x.DiscountValue));

            CreateMap<DiscountDTO, Discount>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.DiscountName, s => s.MapFrom(x => x.DiscountName))
                .ForMember(d => d.DiscountType, s => s.MapFrom(x => x.DiscountType))
                .ForMember(d => d.DiscountValue, s => s.MapFrom(x => x.DiscountValue));
        }
    }
}