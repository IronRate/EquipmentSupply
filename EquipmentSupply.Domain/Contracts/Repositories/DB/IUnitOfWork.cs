using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns></returns>
        bool Commit();

        /// <summary>
        /// Сохранение изменений с поддержкой асинхронности
        /// </summary>
        /// <returns></returns>
        Task<bool> CommitAsync();

        /// <summary>
        /// Откат изменений
        /// </summary>
        void Rollback();
    }
}
