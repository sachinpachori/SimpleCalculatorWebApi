using SimpleCalculator.DomainEntities;
using System;

namespace SimpleCalculator.DataAccess
{
    public interface IRepository<T, TId> where T : class, IEntity<TId> where TId : IEquatable<TId>
    {
        T GetSingle(TId id);       
        void Add(T entity);  
        void Update(T entity);
        void Delete(T entity);       
        void Commit();
    }
}
