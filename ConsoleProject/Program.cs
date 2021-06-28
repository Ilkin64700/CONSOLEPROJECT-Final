using ConsoleProject.Models;
using ConsoleProject.Services;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanresourcemanager = new HumanResourceManager();


            do
            {
                Console.WriteLine("Etmek istedyiniz emeliyyati secin");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1.1 Departament siyahisini gosterir");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1.2 Departament yaradir");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1.3 Departamentde deyisiklik edir");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.1 Iscilerin siyahisini gosterir");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.2 Departamentdeki iscilerin siyahisini gosterir");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.3 Isci elave edir");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.4 Isci uzerinde deyisiklik edir");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.5 Departmentden isci silir");
                Console.WriteLine("---------------------------------");

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1.1":
                        GetDepartment(humanresourcemanager);
                        break;
                    case "1.2":
                        AddDepartment(humanresourcemanager);
                        break;
                    case "1.3":
                        EditDepartment(humanresourcemanager);
                        break;
                    case "2.1":
                        ShowEmployees(humanresourcemanager);
                        break;
                    case "2.2":
                        ShowDepartmentEmployees(humanresourcemanager);
                        break;
                    case "2.3":
                        AddEmployee(humanresourcemanager);
                        break;
                    case "2.4":
                        EditEmployee(humanresourcemanager);
                        break;
                    case "2.5":
                        RemoveEmployee(humanresourcemanager);
                        break;
                    default:
                        break;
                }
            } while (true);


        }

        //Sistemdeki departamentler siyahisini gosterir
        public static void GetDepartment(HumanResourceManager humanresourcemanager)
        {
            foreach (Department item in humanresourcemanager.Departments)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Employees.Count);
                Console.WriteLine(item.CalcSalarayAverage(item.Employees));
            }
        }
        //Uygun parametrleri qebul edib, departament yaradir
        public static void AddDepartment(HumanResourceManager humanresourcemanager)
        {
            bool nameloop = true;
            bool workerlimitloop = true;
            bool salarylimitloop = true;
            string departmentname = "";
            int departmentworkerlimit = 0;
            double departmentsalarylimit = 0;
            Console.WriteLine("Departamentin adini daxil edin");
            while (nameloop)
            {
                try
                {
                    departmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(departmentname) == false && departmentname.Length >= 2)
                    {
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun ad daxil et");
                }
            }
            Console.WriteLine("Departamentin Workerlimitini daxil edin");
            while (workerlimitloop)
            {
                try
                {
                    departmentworkerlimit = int.Parse(Console.ReadLine());
                    if (departmentworkerlimit >= 1)
                    {
                        workerlimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun Workerlimit daxil edin");
                }
            }
            Console.WriteLine("Departamentin Salarylimitini daxil edin");
            while (salarylimitloop)
                try
                {
                    departmentsalarylimit = double.Parse(Console.ReadLine());
                    if (departmentsalarylimit >= 250)
                    {
                        salarylimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun Salarylimit daxil edin");
                }


            Department department = new Department(departmentname, departmentworkerlimit, departmentsalarylimit);
            humanresourcemanager.AddDepartment(department);
        }
        //Departamentin butun parametrlerini deyisdirib, uygun yeni parametrler yaradir
        public static void EditDepartment(HumanResourceManager humanresourcemanager)
        {

            string olddepartmentname = "";
            string newdepartmentname = "";
            int newworkerlimit = 0;
            double newsalarylimit = 0;
            bool oldloop = true;
            bool loop1 = true;
            bool loop2 = true;
            bool loop3 = true;
            Console.WriteLine("Deyisdirmek istediyiniz Departmentin adini daxil edin");
            while (oldloop)
            {
                try
                {
                    olddepartmentname = Console.ReadLine();
                    Department department1 = humanresourcemanager.Departments.Find(x => x.Name == olddepartmentname);

                    if (department1 != null)
                    {
                        Console.WriteLine($"{department1.Name} {department1.WorkerLimit} {department1.SalaryLimit}");
                        Console.WriteLine("Departmentin yeni adini daxil edin");
                        while (loop1)
                        {
                            try
                            {
                                newdepartmentname = Console.ReadLine();
                                if (string.IsNullOrEmpty(newdepartmentname) == false && newdepartmentname.Length >= 2)
                                {
                                    department1.Name = newdepartmentname;
                                    loop1 = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun yeni ad daxil edin");
                            }

                        }
                        Console.WriteLine("Departmentin yeni workerlimitini daxil edin");
                        while (loop2)
                        {
                            try
                            {
                                newworkerlimit = int.Parse(Console.ReadLine());
                                if (newworkerlimit >= 2)
                                {
                                    department1.WorkerLimit = newworkerlimit;
                                    loop2 = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun yeni workerlimit daxil edin");
                            }
                        }
                        Console.WriteLine("Yeni SalaryLimit daxil edin");
                        while (loop3)
                        {
                            try
                            {
                                newsalarylimit = double.Parse(Console.ReadLine());
                                if (newsalarylimit >= 250)
                                {
                                    department1.SalaryLimit = newsalarylimit;
                                    loop3 = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun Yeni salarylimit daxil edin");
                            }
                        }
                        oldloop = false;

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun Departmentin adin daxil edin");
                }

            }


        }
        //Isci siyahisni gosterir
        public static void ShowEmployees(HumanResourceManager humanresourcemanager)
        {
            foreach (Department item in humanresourcemanager.Departments)
            {
                foreach (Employee employee in item.Employees)
                {
                    Console.WriteLine(employee.Id, employee.FullName, employee.DepartamentName, employee.Salary);
                }
            }
        }
        //Departamentdeki iscilerin siyahisini gosterir
        public static void ShowDepartmentEmployees(HumanResourceManager humanresourcemanager)
        {
            Console.WriteLine("Isci siyahisini gormek ucun departament adini yazin");
            string departmentname = Console.ReadLine();
            Department department = humanresourcemanager.Departments.Find(s => s.Name == departmentname);
            foreach (Employee item in department.Employees)
            {
                Console.WriteLine(item.Id, item.Name, item.Position, item.Salary);
            }
        }
        //Isci elave edir
        public static void AddEmployee(HumanResourceManager humanresourcemanager)


        {
            Console.WriteLine("Yeni iscinin adini elave edin");
            string newemployeename = Console.ReadLine();
            Console.WriteLine("Yeni iscinin soyadini elave edin");
            string newemployeesurname = Console.ReadLine();
            string newemployeeposition = "";
            double newemployyesalary = 0;
            string newemployeedepartmentname = "";
            bool positionloop = true;
            bool departmentloop = true;
            bool salaryloop = true;
            Console.WriteLine("Yeni iscinin vezifesini daxil edin");
            while (positionloop)
            {
                try
                {
                    newemployeeposition = Console.ReadLine();
                    if (string.IsNullOrEmpty(newemployeeposition) == false && newemployeeposition.Length >= 2)
                    {
                        positionloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun yeni isci vezifesi daxil edin ");
                }
                Console.WriteLine("Yeni isci maasi daxil edin");
                while (salaryloop)
                {
                    try
                    {
                        newemployyesalary = Convert.ToDouble(Console.ReadLine());
                        if (newemployyesalary >= 250)
                        {
                            salaryloop = false;
                        }
                        else
                        {
                            throw new Exception();
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Duzgun yeni maas daxil edin");
                    }
                }
                Console.WriteLine("Yeni iscinin departament adini daxil edin");
                while (departmentloop)
                {
                    try
                    {
                        newemployeedepartmentname = Console.ReadLine();
                        if (string.IsNullOrEmpty(newemployeedepartmentname) == false && newemployeedepartmentname.Length >= 2)
                        {
                            departmentloop = false;

                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Duzgun yeni departament adi daxil edin");
                    }
                }
                Department department = humanresourcemanager.Departments.Find(a => a.Name == newemployeename);
                Employee newemployee = new Employee(newemployeename, newemployeesurname, newemployeeposition, newemployyesalary, newemployeedepartmentname);
                department.Employees.Add(newemployee);

            }



        }
        //Iscinin paramterleri uzerinde deyisiklik edir
        public static void EditEmployee(HumanResourceManager humanresourcemanager)
        {

           
                bool noloop = true;
                bool editsalary = true;
                bool newsalaryloop = true;
                bool newpositionloop = false;
                string editid = "";
                double newsalary = 0;
                string newposition = "";

                Console.WriteLine("Deyishmek istediyiniz iscinin nomresini yazin");
                while (noloop)
                {
                    try
                    {
                        editid = Console.ReadLine();
                        foreach (Department item in humanresourcemanager.Departments)
                        {
                            Employee currentempoyee = item.Employees.Find(a => a.Id == editid);
                            if (currentempoyee != null)
                            {
                                Console.WriteLine($"{currentempoyee.FullName} {currentempoyee.Salary} {currentempoyee.Position}");
                                Console.WriteLine("Iscinin yeni maasini daxil edin ");
                                while (editsalary)
                                {
                                    try
                                    {
                                        newsalary = double.Parse(Console.ReadLine());
                                        if (newsalary >= 250)
                                        {
                                            currentempoyee.Salary = newsalary;
                                            newsalaryloop = false;
                                        }
                                        else
                                        {
                                            throw new Exception();
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        Console.WriteLine("Duzgun iscinin maasini daxil edin");
                                    }
                                }
                                Console.WriteLine("Iscinin yeni vezifesini daxil edin");
                                while (newpositionloop)
                                {
                                    try
                                    {
                                        newposition = Console.ReadLine();
                                        if (string.IsNullOrEmpty(newposition) == false && newposition.Length >= 2)
                                        {
                                            currentempoyee.Position = newposition;
                                            newpositionloop = false;
                                        }
                                        else
                                        {
                                            throw new Exception();
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        Console.WriteLine("Iscinin yeni vezifesini daxil edin");
                                    }
                                }
                            }
                            else
                            {
                                noloop = false;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Iscinin duzgun nomresini daxil edin");
                    }
                }
            }
        //Departamentden isci silir
        public static void RemoveEmployee(HumanResourceManager humanResourceManager)
        {
            string departmentname = "";
            string employeeid = "";
            bool nameloop = true;
            bool idloop = true;
            Console.WriteLine("Departamentin adini daxil edin");
            while (nameloop)
            {
                try
                {
                    departmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(departmentname)==false && departmentname.Length>=2)
                    {
                        Department removedepartmentname = humanResourceManager.Departments.Find(x => x.Name == departmentname);
                        while (idloop)
                        {
                            try
                            {
                                employeeid = Console.ReadLine();
                                foreach (Department item in humanResourceManager.Departments)
                                {
                                    Employee removeemployee = item.Employees.Find(x => x.Id == employeeid);
                                    if (removeemployee!=null)
                                    {
                                        removedepartmentname.Employees.Remove(removeemployee);
                                        idloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Isci nomresini duzgun daxil edin ");
                            }
                        }
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {

                    Console.WriteLine("Departamemnt adini duzugn daxil edin");
                }
            }
        }

        }
    }

