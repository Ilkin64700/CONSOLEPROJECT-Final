using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
  class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        List<Employee> Employees { get; set; }

        //List yaraderken onu initialize etmeyimiz mecburidir, eks halda reference etdiyi list uzunlugu null olur.
        public Department()
        {
            Employees = new List<Employee>();
        }

        //Asagida mutleqe listi imitialize etmeliyik ki daha sonradan instance alib obyekt yaradanda bu liste reference etsin
        //eks halda nullreference olur, runtime error cixir.
        public Department(string name,int workerlimit,double salarylimit)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;

        }

        //Asagida Employee tipinden olan Employees listinde olan iscilerin ortalamna maasini tapiriq.
        public double CalcSalarayAverage(List<Employee> Employees)
        {
            double sum = 0;
            double result = 0;
            foreach (Employee item in Employees)
            {
                sum += item.Salary;
                
            }
            result = sum / Employees.Count;
            return result;

        }
       
        }


    }

