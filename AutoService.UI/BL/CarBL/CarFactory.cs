using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.UI.CarBL
{
    public delegate void ReplaceHandler(Car car);
    public class CarFactory
    {
        private static ReplaceHandler replaceTheCar;

        static CarFactory()
        {
            replaceTheCar += ReplaceEngine;
            replaceTheCar += ReplaceTransmission;
            replaceTheCar += ReplaceWheels;
        }

        public static void ReplaceCar(Car car, ReplaceHandler replaceHandler)
        {
            replaceTheCar(car);
            replaceHandler(car);
        }

        private static void ReplaceEngine(Car car)
        {
            car.Engine = new Engine();
        }
        private static void ReplaceTransmission(Car car)
        {
            car.Transmission = new Transmission();
        }
        private static void ReplaceWheels(Car car)
        {
            car.Wheels = new Wheels();
        }
    }
}
