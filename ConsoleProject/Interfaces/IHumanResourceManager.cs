using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        List<Department> Departments { get; set; }
        void AddDepartment(Department department);
        List<Department> GetDepartments();
        void EditDepartment(string name, string newname);
        void AddEmployee(string fullname, string position, double salary, string departmentname, string Id, List<Employee> Employees);
        void RemoveEmployee(string Id, string departmmentname, Employee employee, List<Employee> Employees);
        void EditEmployee(string Id, string fullname, double salary, string position, List<Employee> Employees);



    }
}
