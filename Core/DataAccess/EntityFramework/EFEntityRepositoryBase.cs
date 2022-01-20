using Core.DataAccess.EntityFramework.Contexts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : BaseDBContext
    {
        private IConfiguration _configuration;

        public EFEntityRepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Add(TEntity entity)
        {
            using (var context = (TContext)Activator.CreateInstance(typeof(TContext), _configuration))
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = (TContext)Activator.CreateInstance(typeof(TContext), _configuration))
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = (TContext)Activator.CreateInstance(typeof(TContext), _configuration))
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = (TContext)Activator.CreateInstance(typeof(TContext), _configuration))
            {
                var modifiedEntity = context.Entry(entity);
                modifiedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = (TContext)Activator.CreateInstance(typeof(TContext), _configuration))
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
