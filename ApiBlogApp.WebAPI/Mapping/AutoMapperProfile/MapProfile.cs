using ApiBlogApp.DataTransformationObjects.DTOs.AppUser;
using ApiBlogApp.DataTransformationObjects.DTOs.Blog;
using ApiBlogApp.DataTransformationObjects.DTOs.Category;
using ApiBlogApp.Entities.Concrete;
using ApiBlogApp.WebAPI.Models.Blog;
using AutoMapper;

namespace ApiBlogApp.WebAPI.Mapping.AutoMapperProfile
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, Blog>().ReverseMap();
            CreateMap<BlogUpdateModel, Blog>().ReverseMap();
            CreateMap<BlogAddModel, Blog>().ReverseMap();
            
            CreateMap<CategoryListDto, Category>().ReverseMap();
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
        }
    }
}