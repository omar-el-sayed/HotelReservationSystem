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
            return mapper.Map<TResult>(source);
        }    
    }
}
