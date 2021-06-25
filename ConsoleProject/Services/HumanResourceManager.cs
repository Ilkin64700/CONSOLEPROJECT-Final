using ConsoleProject.Interfaces;
using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments { get; set; }
        public Department department { get; set; }

        //Asagidaki methodda bize gelen parametrlerle bizde olan departamentleri yoxluyuruq sert odenirse, siyahiya elave edirik
        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            Departments = new List<Department>();
            if (Departments.Any(d=>d.Name==name && d.WorkerLimit==workerlimit && d.SalaryLimit==salarylimit))
            {
                Departments.Add(department);
            }
        }
        //Asagidaki methoddda bize gelen paramterlerle employeeleri yoxlyuruq, sert odenirse, yeni bir Employee obyekti siyahiya elave olunur

        public void AddEmployee(string fullname, string position, double salary, string departmentname, string Id, List<Employee> Employees)
        {
            if (Employees.Any(d=>d.FullName==fullname && d.Position==position && d.Salary==salary && d.DepartamentName==departmentname && d.Id==Id))
            {
                Employee employee = new Employee();
                Employees.Add(employee);
            }
        }

        //Asagidaki method departementin adinin deyisillib deyisilmediyini yoxluyur sert odenmediyi teqdirde departamment adi yeni ada set olunur
        public void EditDepartment(string name, string newname)
        {
            if (Departments.Any(d=>d.Name!=newname))
            {
                department.Name = newname;
            }
            else
            {
                department.Name = name;
            }
        }

        //Asagidaki method bize gelen paramtrlerin listde olub olmadigini yoxluyur, listde oldugu teqdirde bizim
        //Employye listindeki enployyee obyektine set edir.s

        public void EditEmployee(string Id, string fullname, double salary, string position,List<Employee>Employees)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Id != null && employee.FullName != fullname && employee.Position != position)
                {
                    employee.Id = Id;
                    employee.FullName = fullname;
                    employee.Position = position;
                }
            }

        }
        //Asagidaki method Departments listini bize qaytarir.
        public List<Department> GetDepartments()
        {
            return Departments;
        }
        
        // Adagidaki method eyer daxil edilen paramterler bizdeki parmaterlere beraverdise bu halda
        //teyin olunmus employye-ni siyahidan cixaracaq.

        public void RemoveEmployee(string id, string departmmentname, Employee employee, List<Employee> Employees)
        {
            if (Employees.Any(d => d.Id == id && d.DepartamentName == departmmentname))
            {
                Employees.Remove(employee);
            }
        }
    }
}
