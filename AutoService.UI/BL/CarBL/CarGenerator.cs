using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.UI.CarBL
{
    public delegate void BrokenCarHandler(Car car);
    public class CarGenerator
    {
        public static BrokenCarHandler breakTheCar;

        static CarGenerator()
        {
            breakTheCar += CreateBrokenEngine;
            breakTheCar += CreateBrokenTransmission;
            breakTheCar += CreateBrokenWheels;
        }

        public static Car GetBrokenCar(string firmName, string model)
        {
            Car car = new Car(firmName, model);

            breakTheCar(car);

            return car;
        }

        private static void CreateBrokenEngine(Car car)
        {
            car.Engine = new Engine(MechanismStatuses.Broken);
        }
        private static void CreateBrokenTransmission(Car car)
        {
            car.Transmission = new Transmission(MechanismStatuses.Broken);
        }
        private static void CreateBrokenWheels(Car car)
        {
            car.Wheels = new Wheels(MechanismStatuses.Broken);
        }
    }
}
