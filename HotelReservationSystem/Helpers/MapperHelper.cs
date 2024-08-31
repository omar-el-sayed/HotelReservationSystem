using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace HotelReservationSystem.Helpers
{
    public static class MapperHelper
    {
        public static IMapper mapper { get; set; }

        public static IEnumerable<TResult> Map<TResult>(this IQueryable source)
        {
            return source.ProjectTo<TResult>(mapper.ConfigurationProvider);
        }

        public static TResult MapeOne<TResult>(this object source)
        {
            //mapper.Map(source, object);
            //TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
            return mapper.Map<TResult>(source);
           
        }
        public static TDestination MapOne<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return mapper.Map(source, destination);
        }
    }
}
