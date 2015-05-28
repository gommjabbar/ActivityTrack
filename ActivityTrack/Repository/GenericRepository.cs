using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext  Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public GenericRepository()
        {
            Context = new ApplicationDbContext();
            DbSet = Context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            Context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}