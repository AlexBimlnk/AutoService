using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.CMD.CarBL
{
    public class Car
    {
        public string Firm { get; private set; }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }
        public Wheels Wheels { get; private set; }
        public Transmission Transmission { get; private set; }

        public Car(Engine engine, Wheels wheels, Transmission transmission, 
                   string firmName, string model)
        {
            Engine = engine;
            Wheels = wheels;
            Transmission = transmission;
            Firm = firmName;
            Model = model;
        }

        public string GetInfo()
        {
            return $"Engine status: {Engine.Status}\n" +
                    $"Wheels status: {Wheels.Status}\n" +
                    $"Transmission status: {Transmission.Status}";
        }
    }
}
