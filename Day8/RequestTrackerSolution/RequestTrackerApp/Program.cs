using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModel;
using RequestTrakerModel;
using System;

namespace RequestTrackerApp
{
    internal class Program
    {
        void AddDepartments()
        {
            DepartmentBL departmentBL = new DepartmentBL();

            try
            {
                Console.WriteLine("Enter the department name:");
                string name1 = Console.ReadLine();
                Department department1 = new Department() { Name = name1 };
                int id1 = departmentBL.AddDepartment(department1);
                Console.WriteLine($"Department added successfully. ID: {id1}");

                Console.WriteLine("Enter another department name:");
                string name2 = Console.ReadLine();
                Department department2 = new Department() { Name = name2 };
                int id2 = departmentBL.AddDepartment(department2);
                Console.WriteLine($"Department added successfully. ID: {id2}");
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }

        void AddEmployees()
        {
            // Create an instance of EmployeeRepository
            IRepository<int, Employee> employeeRepository = new EmployeeRepository();
            // Pass it to EmployeeBL constructor
            EmployeeBL employeeBL = new EmployeeBL(employeeRepository);

            try
            {
                Console.WriteLine("Enter the employee name:");
                string name1 = Console.ReadLine();
                Employee employee1 = new Employee() { Name = name1 };
                int id1 = employeeBL.AddEmployee(employee1);
                Console.WriteLine($"Employee added successfully. ID: {id1}");

                Console.WriteLine("Enter another employee name:");
                string name2 = Console.ReadLine();
                Employee employee2 = new Employee() { Name = name2 };
                int id2 = employeeBL.AddEmployee(employee2);
                Console.WriteLine($"Employee added successfully. ID: {id2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddDepartments();
            program.AddEmployees();
        }
    }
}
