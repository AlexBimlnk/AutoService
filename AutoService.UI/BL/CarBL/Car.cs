using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.UI.CarBL
{
    public class Car
    {
        public string Firm { get; private set; }

        public string Model { get; private set; }

        public Engine Engine { get; set; }
        public Wheels Wheels { get; set; }
        public Transmission Transmission { get; set; }

        public Car(string firmName, string model)
        {
            Firm = firmName;
            Model = model;
        }

        public Car(Engine engine, Wheels wheels, Transmission transmission, 
                   string firmName, string model)
        {
            Engine = engine;
            Wheels = wheels;
            Transmission = transmission;
            Firm = firmName;
            Model = model;
        }

        public List<IMechanism> GetComponents()
        {
            return new List<IMechanism>() { Engine, Wheels, Transmission };
        }

        public string GetInfo()
        {
            return  $"Firm: {Firm}\n" +
                    $"Model: {Model}\n" +
                    $"Engine status: {Engine.Status}\n" +
                    $"Wheels status: {Wheels.Status}\n" +
                    $"Transmission status: {Transmission.Status}";
        }
    }
}
