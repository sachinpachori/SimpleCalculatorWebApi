using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleCalculator.DomainEntities;
using System;
using System.Linq;

namespace SimpleCalculator.DataAccess
{
    public class Repository<T, TId> : IRepository<T, TId> where T : class, IEntity<TId> where TId : IEquatable<TId>
    {
        private readonly SimpleCalculatorAppContext _context;
        private readonly DbSet<T> _entities;
        string errorMessage = string.Empty;

        public Repository(SimpleCalculatorAppContext Context)
        {
            _context = Context;
            _entities = _context.Set<T>();
        } 

        public T GetSingle(TId id)
        {
            return _entities.FirstOrDefault(x => x.Id.Equals(id));
        }
       
        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Added;
            _entities.Add(entity);
        }
      
        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }       

        private void SaveChanges()
        {
            var addedAuditedEntities = _context.ChangeTracker.Entries()
              .Where(p => p.State == EntityState.Added)
              .Select(p => p.Entity);

            var modifiedAuditedEntities = _context.ChangeTracker.Entries()
              .Where(p => p.State == EntityState.Modified)
              .Select(p => p.Entity);

            var deletedAuditedEntries = _context.ChangeTracker.Entries()
              .Where(p => p.State == EntityState.Deleted)
              .Select(p => p);

            var iSupportSoftDeleteEntries = _context.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Deleted)
                .Select(p => p);


            _context.SaveChanges();
        }

        public virtual void Commit()
        {
            SaveChanges();
        }
    }
}
