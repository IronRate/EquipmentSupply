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

        /// <summary>
        /// Вернет сущность по идентификатору
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Вернет список всех сущностей из хранилища
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Произведет поиск сущностей в хранилище по критерию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Добавит новую сущность в хранилище
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Добавит несколько сущностей в хранилище
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Помещает сущность как измененую
        /// </summary>
        /// <param name="entity"></param>
        void Modify(TEntity entity);

        /// <summary>
        /// Помечает сущность как удаленную
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Помечает список сущностей как удаленные
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Помечает список сущностей как удаленные
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(ICollection<TEntity> entities);

        /// <summary>
        /// Помечает сущность как удаленную, находя ее в хранилище по ключу
        /// </summary>
        /// <param name="id"></param>
        void Remove(TKey id);

        //Асинхронные запросы

        /// <summary>
        /// Вернет сущность по идентификатору
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Вернте все сущности из хранилища
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Произведет поиск сущностей по критерию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        //Task AddAsync(TEntity entity);
        //Task AddRangeAsync(IEnumerable<TEntity> entity);

        //Task RemoveAsync(TEntity entity);
        //Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        //Task RemoveRangeAsync(ICollection<TEntity> entities);

        //Task RemoveAsync(TKey id);

        /// <summary>
        /// Вернет количество записией
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();

        /// <summary>
        /// Вернет наличие элементов в хранилище по условию, переданому в предикате
        /// </summary>
        /// <param name="predicate">условие поиска элементов</param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Вернет наличие элементов в хранилище по условию, переданому в предикате
        /// </summary>
        /// <param name="predicate">условие поиска элементов</param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

    }
}
