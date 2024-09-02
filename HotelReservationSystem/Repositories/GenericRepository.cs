using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelReservationSystem.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;


    public GenericRepository(ApplicationDbContext _context)
    {
        this._context = _context;
     }
    public IQueryable<T> GetAll()
        => _context.Set<T>().Where(e => !e.IsDeleted);

    public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        => GetAll().Where(predicate);

    public IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        => Get(predicate).Select(selector);

    public T? GetById(int id)
        => GetAll().FirstOrDefault(e => e.Id == id);

    public T? GetByIdWithTracking(int id)
    {
        return _context.Set<T>().Where(x=>!x.IsDeleted &&x.Id==id).AsTracking().FirstOrDefault();
    }

    public void HardDelete(int id)
        => _context.Set<T>().Where(x => x.Id == id).ExecuteDelete();

    public T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    public void Update(T entity)
    {
        //_context.Entry<T>(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
        Update(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.AddRange(entities);
    }
}
