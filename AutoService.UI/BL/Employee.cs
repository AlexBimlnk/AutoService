using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.UI
{
    public class Employee : Person, IGetInformation //Пример наследования
    {
        public string Qualification { get; set; }
        public int Salary { get; set; }
        public int WorkExperience { get; set; }

        public Employee(string name, string lastName) : base(name, lastName) { }
        public Employee(string name, string lastName, 
                        int salary, string qualification, int workExperience) : 
                        base(name, lastName)
        {
            Salary = salary;
            Qualification = qualification;
            WorkExperience = workExperience;
        }

        public override string GetInfo() //Полиморфизм
        {
            return $"{base.GetInfo()}\nQualification: {Qualification}\n" +
                   $"Salary: {Salary}\nWorkExperience: {WorkExperience}";
        }
    }
}
