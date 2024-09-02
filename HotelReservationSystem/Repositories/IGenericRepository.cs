using System.Linq.Expressions;

namespace HotelReservationSystem.Repositories;

public interface IGenericRepository<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> Get(Expression<Func<T, bool>> predicate);
    IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);
    T? GetById(int id);
    T? GetByIdWithTracking(int id);
    T Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);
    void HardDelete(int id);
    void SaveChanges();
}
