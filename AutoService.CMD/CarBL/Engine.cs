using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.CMD.CarBL
{
    public class Engine
    {
        /// <summary>
        /// Лошадиные силы.
        /// </summary>
        public int HorsePower { get; private set; }

        /// <summary>
        /// Объем.
        /// </summary>
        public int Volume { get; private set; }

        public MechanismStatuses Status { get; set; }

        //Мы будем рандомно генерировать характеристики для упрощения реализации
        public Engine(MechanismStatuses status = MechanismStatuses.Work)
        {
            //Это только потому что я генерирую,
            //включаться сюда не должно в нормальном проекте
            Random rnd = new Random();

            if (status == MechanismStatuses.Work)
                Status = (MechanismStatuses)rnd.Next(0, 2);
            else
                Status = status;

            HorsePower = rnd.Next(100, 500);
            Volume = rnd.Next(1000, 2500);
        }
    }
}
