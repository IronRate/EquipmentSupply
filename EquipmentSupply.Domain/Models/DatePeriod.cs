using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models
{
    /// <summary>
    /// Временной период
    /// </summary>
    public class DatePeriod
    {

        #region Fields

        private readonly DateTimeOffset? _dateFrom;
        private readonly DateTimeOffset? _dateTo;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dateFrom">дата с</param>
        /// <param name="dateTo">дата по (если не указать то берется текущее время)</param>
        public DatePeriod(DateTimeOffset? dateFrom, DateTimeOffset? dateTo = null)
        {
            if(dateFrom.HasValue || dateTo.HasValue)
            {
                if (dateFrom == null)
                {
                    dateFrom = DateTimeOffset.MinValue;
                }

                if (dateTo == null)
                {
                    dateTo = DateTimeOffset.Now;
                }
                dateTo = dateTo.Value.AddDays(1);

                if (dateFrom > dateTo)
                {
                    var a = dateTo;
                    dateTo = dateFrom;
                    dateFrom = a;
                }
            }
            ////////////////////////////////////////////////////////////////
            this._dateFrom = dateFrom;
            this._dateTo = dateTo;

        }

        /// <summary>
        /// Вернетв ременной период - сегодняшний день
        /// </summary>
        /// <returns></returns>
        public static DatePeriod ToDay() {
            var now = DateTimeOffset.Now;
            DateTimeOffset a = new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0,0,new TimeSpan());
            DateTimeOffset b = a.AddHours(24);/*Для того чтобы учесть перход на другой месяц/год  просто добавим 24 часа - пусть система поработает за нас при расчете даты*/
            return new DatePeriod(a, b);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Дата с
        /// </summary>
        public DateTimeOffset? DateTimeFrom { get => _dateFrom; }

        //Дата по
        public DateTimeOffset? DateTimeTo { get => _dateTo; }

        /// <summary>
        /// Признак того, что значения пустые
        /// </summary>
        public bool IsEmpty { get => !(_dateTo.HasValue && _dateTo.HasValue); }

        #endregion
    }
}
