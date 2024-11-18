using AutoMapper;
using Pustok.Core.Paging;

namespace Pustok.BLL.AutoMapper
{


    public class PaginateConverter<TSource, TDestination> : ITypeConverter<Paginate<TSource>, Paginate<TDestination>>
    {
        public Paginate<TDestination> Convert(Paginate<TSource> source, Paginate<TDestination> destination, ResolutionContext context)
        {
            return new Paginate<TDestination>
            {
                Index = source.Index,
                Size = source.Size,
                Count = source.Count,
                Pages = source.Pages,
                Items = context.Mapper.Map<IList<TDestination>>(source.Items)
            };
        }
    }

}
