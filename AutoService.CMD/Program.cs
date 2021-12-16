using System;
using System.Collections.Generic;
using AutoService.CMD.CarBL;

namespace AutoService.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoService.RecruiteEmployee(new Employee("name1", "lastname1"));
            //AutoService.RecruiteEmployee(new Employee("name2", "lastname2"));
            AutoService.StartWork();
        }
    }
}
