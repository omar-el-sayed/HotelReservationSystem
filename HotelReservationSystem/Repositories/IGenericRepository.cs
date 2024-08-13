using System.Linq.Expressions;

namespace HotelReservationSystem.Repositories
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T? GetById(int id);
        T? GetByIdWithTracking(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
