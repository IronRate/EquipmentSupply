using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Contracts.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace EquipmentSupply.DAL.UnitOfWorks
{
    public class SuppliesUnitOfWork : Domain.Contracts.Repositories.DB.IDbUnitOfWork
    {
        #region Fields

        private readonly DbContext _context;
        private bool _disposed = false;

        private ISuppliesRepository _supplies;
        private IEqupmentTypesRepository _equpmentTypes;
        private INotificationQueueRepository _notificationQueues;
        private IProvidersRepository _providers;

        #endregion

        #region Constructor

        public SuppliesUnitOfWork(DbContext context)
        {
            this._context = context;
        }

        #endregion

        #region Methods

        public bool Commit()
        {
            return this._context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await this._context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Rollback()
        {
            _context
           .ChangeTracker
           .Entries()
           .ToList()
           .ForEach(x => x.Reload());
        }

        #endregion

        #region Properies

        public ISuppliesRepository Supplies => _supplies = _supplies ?? new Repositories.SuppliesRepository(_context as Contexts.DbSuppliesContext);

        public IEqupmentTypesRepository EqupmentTypes => _equpmentTypes = _equpmentTypes ?? new Repositories.EquipmentTypesRepository(_context as Contexts.DbSuppliesContext);

        public INotificationQueueRepository NotificationQueues => _notificationQueues = _notificationQueues ?? new Repositories.NotificationQueueRepository(_context as Contexts.DbSuppliesContext);

        public IProvidersRepository Providers => _providers = _providers ?? new Repositories.ProvidersRepository(_context as Contexts.DbSuppliesContext);

        #endregion


    }
}
