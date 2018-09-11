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

        private readonly DateTimeOffset _dateFrom;
        private readonly DateTimeOffset _dateTo;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dateTimeFrom">дата с</param>
        /// <param name="dateTimeTo">дата по (если не указать то берется текущее время)</param>
        public DatePeriod(DateTimeOffset dateTimeFrom, DateTimeOffset? dateTimeTo = null)
        {
            if (dateTimeTo==null)
            {
                dateTimeTo = DateTimeOffset.Now;
            }

            /*
             Защита от дурака, на случай, если да С будет больше даты ПО
             */ 
            if (dateTimeTo < dateTimeFrom)
            {
                this._dateFrom = dateTimeTo.Value;
                this._dateTo = dateTimeFrom;
            }
            else
            {
                this._dateFrom = dateTimeFrom;
                this._dateTo = dateTimeTo.Value;
            }
            ////////////////////////////////////////////////////////////////


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
        public DateTimeOffset DateTimeFrom { get => _dateFrom; }

        //Дата по
        public DateTimeOffset DateTimeTo { get => _dateTo; }

        #endregion
    }
}
