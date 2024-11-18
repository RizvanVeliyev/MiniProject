using AutoMapper;
using Pustok.BLL.ViewModels.AppUserViewModels;
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
using Pustok.Core.Paging;

namespace Pustok.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductImage, ProductImageViewModel>().ReverseMap();
            CreateMap<ProductImage, ProductImageCreateViewModel>().ReverseMap();
            CreateMap<ProductImage, ProductImageUpdateViewModel>().ReverseMap();

            CreateMap<BasketItem, BasketItemViewModel>().ReverseMap();
            CreateMap<BasketItem, BasketItemCreateViewModel>().ReverseMap();
            CreateMap<BasketItem, BasketItemUpdateViewModel>().ReverseMap();
            CreateMap<BasketItemUpdateViewModel, BasketItem>()
           .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.UserId));

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

            CreateMap<Product, ProductViewModel>().ForMember(x => x.MainImagePath, x => x.MapFrom(x => x.ProductImages.FirstOrDefault(x => x.IsMain) != null ? x.ProductImages.FirstOrDefault(x => x.IsMain).Path : string.Empty)).ReverseMap();
            CreateMap<Product, ProductCreateViewModel>().ReverseMap();
            CreateMap<Product, ProductUpdateViewModel>().ReverseMap();

            CreateMap<AppUser, RegisterViewModel>().ReverseMap();
            CreateMap<AppUser, LoginViewModel>().ReverseMap();
            //CreateMap<AppUser,UserViewModel>().ReverseMap();
            CreateMap<AppUser, UserViewModel>().ForMember(dest => dest.Roles, opt => opt.Ignore()).ReverseMap();

            CreateMap<AppUser, ChangeRoleViewModel>().ReverseMap();

            CreateMap(typeof(Paginate<>), typeof(Paginate<>)).ConvertUsing(typeof(PaginateConverter<,>));


        }
    }
}
