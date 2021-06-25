using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
   class Employee
    {
        public string Id;
        private static int _count = 1000;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; } 
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartamentName { get; set; }

        public Employee()
        {

        }

       //Asagidaki constructor-da ilk olaraq field-lere value set edirik. Daha sonra ise her bir isciye unikal ID teyin olunmasi ucun
       //her defesinde countu artiriq. En sonda ise Unikal Countu Departament adinin ilk 2 herfiyle birlesdirib unikal ID-ye set edirik.
        public Employee(string name, string surname, string position, double salary, string departamentname)
        {
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
            DepartamentName = departamentname;
            FullName = name + " " + surname;
            _count++;
            Id = DepartamentName.Trim().ToUpper().Substring(0,2) + _count.ToString();
           

        }
        

        //Field-lere set olunmus deyerleri asagidaki method vasitesiyle program classin-da olan Employee classindan instance alib
        //initialize olan obyekte otururuk.
        public override string ToString()
        {
            return $"{Id} {FullName} {Position} {Salary} {DepartamentName}"; 
            
            
            
        }
    }
}
