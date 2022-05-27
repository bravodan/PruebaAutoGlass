using Domain.Entities;
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
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.phoneNumber, opt => opt.MapFrom(src => src.phoneNumber));
            CreateMap<SupplierView, Supplier>()
                .ForMember(dest => dest.ProductSupplierList, opt => opt.Ignore());

            //ProductItemCreateView
            CreateMap<ProductItem, ProductItemCreateView>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate));
            CreateMap<ProductItemCreateView, ProductItem>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate))
                .ForMember(dest => dest.ProductSupplierList, opt => opt.Ignore());

            //ProductItemCreateResponse
            CreateMap<ProductItem, ProductItemCreateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => src.ProductStatus))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate))
                .ForMember(dest => dest.CurrentSupplierId, opt => opt.MapFrom(src => src.getCurrentSupplierId()));
            CreateMap<ProductItemCreateResponse, ProductItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => src.ProductStatus))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ValidityDate, opt => opt.MapFrom(src => src.ValidityDate))
                .ForMember(dest => dest.ProductSupplierList, opt => opt.Ignore());
        }
    }
}

