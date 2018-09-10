using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.DAL.Repositories
{
    public class DbRepository<TEntity, TKey> : Domain.Contracts.Repositories.DB.IDbRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {
        protected readonly Contexts.DbSuppliesContext context;

        #region Constructor

        public DbRepository(
            Contexts.DbSuppliesContext context
            )
        {
            this.context = context;
        }

        #endregion

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                context.Set<TEntity>().Add(entity);
            });
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() =>
            {
                context.Set<TEntity>().AddRange(entities);
            });
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return context.Set<TEntity>().Where(predicate);
            });
        }

        public TEntity Get(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Modify(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            if (entity != null)
                context.Set<TEntity>().Remove(entity);
        }

        public void Remove(TKey id)
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
            }
        }

        public async Task RemoveAsync(TEntity entity)
        {
            if (entity != null)
            {
                await Task.Run(() =>
                {
                    context.Set<TEntity>().Remove(entity);
                });
            }
        }

        public async Task RemoveAsync(TKey id)
        {
            TEntity entity = await context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
            }

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                context.Set<TEntity>().RemoveRange(entities);
            }
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            if (entities != null)
            {
                this.context.Set<TEntity>().RemoveRange(entities);
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                await Task.Run(() =>
                {
                    context.Set<TEntity>().RemoveRange(entities);
                });
            }
        }

        public async Task RemoveRangeAsync(ICollection<TEntity> entities)
        {
            if (entities != null)
            {
                await Task.Run(() =>
                {
                    this.context.Set<TEntity>().RemoveRange(entities);
                });
            }
        }

        

        public async Task<int> CountAsync()
        {
            return await context.Set<TEntity>().CountAsync();
        }
    }
}
