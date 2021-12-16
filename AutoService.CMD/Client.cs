using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoService.CMD.CarBL;

namespace AutoService.CMD
{
    public class Client : Person //Пример наследования
    {
        public Car Car { get; private set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }

        public Client(string name, string lastName, Car car) : base(name, lastName)
        {
            Car = car;
        }

        public Client(string name, string lastName, 
                      string phoneNumber, string eMail, Car car) : base(name, lastName)
        {
            PhoneNumber = phoneNumber;
            EMail = eMail;
            Car = car;
        }


        public override string GetInfo() //Полиморфизм
        {
            return $"{base.GetInfo()}\nPhone: {PhoneNumber}\nEMail: {EMail}"; 
        }
    }
}
