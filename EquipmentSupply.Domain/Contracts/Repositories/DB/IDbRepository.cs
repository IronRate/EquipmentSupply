using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface IDbRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {

        //Синхронные запросы
        TEntity Get(TKey id);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Modify(TEntity entity);


        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRange(ICollection<TEntity> entities);
        void Remove(TKey id);

        //Асинхронные запросы


        Task<TEntity> GetAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        //Task AddAsync(TEntity entity);
        //Task AddRangeAsync(IEnumerable<TEntity> entity);

        //Task RemoveAsync(TEntity entity);
        //Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        //Task RemoveRangeAsync(ICollection<TEntity> entities);

        //Task RemoveAsync(TKey id);

        /// <summary>
        /// Количество записией
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();

    }
}
