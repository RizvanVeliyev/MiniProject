using AutoMapper;
using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.ProductImageViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.BLL.ViewModels.SettingViewModels;
using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.BLL.ViewModels.SubscribeViewModels;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductImage, ProductImageViewModel>().ReverseMap();
            CreateMap<ProductImage, ProductImageCreateViewModel>().ReverseMap();
            CreateMap<ProductImage, ProductImageUpdateViewModel>().ReverseMap();

            CreateMap<BasketItem, BasketItemViewModel>().ReverseMap();
            CreateMap<BasketItem, BasketItemCreateViewModel>().ReverseMap();
            CreateMap<BasketItem, BasketItemUpdateViewModel>().ReverseMap();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryCreateViewModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateViewModel>().ReverseMap();

            CreateMap<Service, ServiceViewModel>().ReverseMap();
            CreateMap<Service, ServiceCreateViewModel>().ReverseMap();
            CreateMap<Service, ServiceUpdateViewModel>().ReverseMap();

            CreateMap<Setting, SettingViewModel>().ReverseMap();
            CreateMap<Setting, SettingCreateViewModel>().ReverseMap();
            CreateMap<Setting, SettingUpdateViewModel>().ReverseMap();

            CreateMap<Slider, SliderViewModel>().ReverseMap();
            CreateMap<Slider, SliderCreateViewModel>().ReverseMap();
            CreateMap<Slider, SliderUpdateViewModel>().ReverseMap();

            CreateMap<Subscribe, SubscribeViewModel>().ReverseMap();
            CreateMap<Subscribe, SubscribeCreateViewModel>().ReverseMap();
            CreateMap<Subscribe, SubscribeUpdateViewModel>().ReverseMap();

            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<Tag, TagCreateViewModel>().ReverseMap();
            CreateMap<Tag, TagUpdateViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductCreateViewModel>().ReverseMap();
            CreateMap<Product, ProductUpdateViewModel>().ReverseMap();
        }
    }
}
