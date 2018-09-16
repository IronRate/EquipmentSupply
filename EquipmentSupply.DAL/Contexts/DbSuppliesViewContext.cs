using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Contexts
{
    public class DbSuppliesViewContext:DbContext
    {
        #region Constructor

        public DbSuppliesViewContext()
        {

        }

        public DbSuppliesViewContext(DbContextOptions<DbSuppliesViewContext> options):base(options)
        {

        }

        #endregion

        #region Repositories

        /// <summary>
        /// Поставки
        /// </summary>
        public DbQuery<Domain.Models.DB.Supply> Supplies { get; set; }

        /// <summary>
        /// Поставщики
        /// </summary>
        public DbQuery<Domain.Models.DB.Provider> Providers { get; set; }

        /// <summary>
        /// Типы оборудования
        /// </summary>
        public DbQuery<Domain.Models.DB.EquipmentType> EquipmentTypes { get; set; }


        /// <summary>
        /// Очереь нотификаций
        /// </summary>
        public DbQuery<Domain.Models.DB.NotificationQueue> NotificationQueues { get; set; }

        #endregion
    }
}
