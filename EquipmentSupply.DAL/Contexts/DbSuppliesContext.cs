using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Contexts
{
    /// <summary>
    /// Контекст доступа к хранилищу
    /// </summary>
    public class DbSuppliesContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="options">опции контекста</param>
        public DbSuppliesContext(DbContextOptions<DbSuppliesContext> options) : base(options)
        {

        }

        #endregion

        #region Repositories

        /// <summary>
        /// Поставки
        /// </summary>
        public DbSet<Domain.Models.DB.Supply> Supplies { get; set; }

        /// <summary>
        /// Поставщики
        /// </summary>
        public DbSet<Domain.Models.DB.Provider> Providers { get; set; }

        /// <summary>
        /// Типы оборудования
        /// </summary>
        public DbSet<Domain.Models.DB.EquipmentType> EquipmentTypes { get; set; }

        #endregion
    }
}
