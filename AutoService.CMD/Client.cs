using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.CMD
{
    public class Client : Person //Пример наследования
    {
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }

        public Client(string name, string lastName) : base(name, lastName) { }

        public Client(string name, string lastName, string phoneNumber, string eMail) : base(name, lastName)
        {
            PhoneNumber = phoneNumber;
            EMail = eMail;
        }


        public override string GetInfo() //Полиморфизм
        {
            return $"{base.GetInfo()}\nPhone: {PhoneNumber}\nEMail: {EMail}"; 
        }
    }
}
