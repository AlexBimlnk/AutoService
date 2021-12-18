using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.UI
{
    public enum OrderStatuses
    {
        /// <summary>
        /// Заказ ожидает выполнения.
        /// </summary>
        Wait,
        /// <summary>
        /// Заказ выполняется.
        /// </summary>
        Progress,
        /// <summary>
        /// Заказ выполнен
        /// </summary>
        Finished,
        /// <summary>
        /// Заказ отменен.
        /// </summary>
        Canceled
    }

    public enum MechanismStatuses
    {
        Work,
        Broken
    }
}
