using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.UI.CarBL
{
    public delegate void CreateBrokenCarHandler(Car car);
    public class CarGenerator
    {
        private static CreateBrokenCarHandler createBrokenCar;

        static CarGenerator()
        {
            createBrokenCar += CreateBrokenEngine;
            createBrokenCar += CreateBrokenTransmission;
            createBrokenCar += CreateBrokenWheels;
        }

        public static Car CreateBrokenCar(string firmName, string model)
        {
            Car car = new Car(firmName, model);

            createBrokenCar(car);

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
