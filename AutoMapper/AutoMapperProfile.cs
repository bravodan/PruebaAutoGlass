using Domain.Entities;
using Domain.Pagination;
using Models.DTO;

namespace AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            configure();
        }

        private void configure()
        {
            //Supplier
            CreateMap<Supplier, SupplierView>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
            CreateMap<SupplierView, Supplier>()
                .ForMember(dest => dest.ProductItemList, opt => opt.Ignore());

            //ProductItemCreateView
            CreateMap<ProductItem, ProductItemCreateView>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate));
            CreateMap<ProductItemCreateView, ProductItem>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate))
                .ForMember(dest => dest.Supplier, opt => opt.Ignore());

            //ProductItemCreateResponse
            CreateMap<ProductItem, ProductItemCreateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => src.ProductStatus))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate))
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SuppId));
            CreateMap<ProductItemCreateResponse, ProductItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => src.ProductStatus))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate))
                .ForMember(dest => dest.Supplier, opt => opt.Ignore());

            //ProductItemGet
            CreateMap<ProductItem, ProductItemGetResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => src.ProductStatus))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier));
        }
    }
}

