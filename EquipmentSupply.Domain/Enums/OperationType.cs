using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Enums
{
    /// <summary>
    /// Тип операции
    /// </summary>
    public enum OperationType
    {

        Undefined=0,

        /// <summary>
        /// Создание
        /// </summary>
        Create=1,

        /// <summary>
        /// Создание
        /// </summary>
        Modify=2,

        /// <summary>
        /// Удаление
        /// </summary>
        Delete=3


    }
}
