using AutoMapper;
using store.Dtos.Request;
using store.Dtos.Responce;
using store.Models;

namespace store.Helper.Mapping
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<ProductRequestDto, Product>()
                .ForMember(dest => dest.Description, opt=>opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.QteStock, opt => opt.MapFrom(src => src.QuantiteProduitStock))
                .ForMember(dest => dest.PPs, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Image)
                    ? new List<PhotoProduit>()
                    : new List<PhotoProduit> { new PhotoProduit { UrlImage = src.Image } }));

            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.PPs.FirstOrDefault() != null ? src.PPs.FirstOrDefault().UrlImage : string.Empty))
                .ForMember(dest => dest.QuantiteProduitStock, opt => opt.MapFrom(src => src.QteStock));


            CreateMap<Att_ProduitRequestDto, Att_Produit>()
              .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Produit))
              .ForMember(dest => dest.Produit, opt => opt.Ignore());

            CreateMap<Att_Produit, Att_ProduitResponseDto>()
                .ForMember(dest => dest.Produit, opt => opt.MapFrom(src => src.ProductId));



            CreateMap<ClientRequestdto, Client>();

            CreateMap<Client, ClientResponsedto>();

            CreateMap<PhotoProduitRequestDto, PhotoProduit>();

            CreateMap<PhotoProduit, PhotoProduitResponseDto>();


        }
    }
}
