using AutoMapper;
using ProductAppSuitableForMyRouting.Helpers;
using ProductAppSuitableForMyRouting.Models.ViewModels;


namespace ProductAppSuitableForMyRouting.Models.AutoMappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<ProductAddViewModel, Product>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => UploadFileHelper.UploadFile(src.ImageUrl).Result));
            CreateMap<ProductUpdateViewModel, Product>();
            CreateMap<AddCategoryViewModel, Category>().ForMember(dest => dest.ImageUrlCategory, opt => opt.MapFrom(src => UploadFileHelper.UploadFile(src.ImageUrlCategory).Result));
        }
    }
}
