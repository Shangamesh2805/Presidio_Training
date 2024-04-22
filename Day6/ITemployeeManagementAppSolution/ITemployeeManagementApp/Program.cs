using ITemployeeManagementModel;

namespace ITemployeeManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter ABC Employee Details:");
            Console.Write("Employee ID: ");
            int abcEmpId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string abcName = Console.ReadLine();
            Console.Write("Department: ");
            string abcDept = Console.ReadLine();
            Console.Write("Designation: ");
            string abcDesg = Console.ReadLine();
            Console.Write("Basic Salary: ");
            double abcBasicSalary = Convert.ToDouble(Console.ReadLine());

           
            ABC abcEmp = new ABC(abcEmpId, abcName, abcDept, abcDesg, abcBasicSalary);

           
            Console.WriteLine("\nEnter XYZ Employee Details:");
            Console.Write("Employee ID: ");
            int xyzEmpId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string xyzName = Console.ReadLine();
            Console.Write("Department: ");
            string xyzDept = Console.ReadLine();
            Console.Write("Designation: ");
            string xyzDesg = Console.ReadLine();
            Console.Write("Basic Salary: ");
            double xyzBasicSalary = Convert.ToDouble(Console.ReadLine());

            
            XYZ xyzEmp = new XYZ(xyzEmpId, xyzName, xyzDept, xyzDesg, xyzBasicSalary);

        
            Console.WriteLine("\nABC Employee Details:");
            Console.WriteLine($"Employee ID: {abcEmp.EmpId}");
            Console.WriteLine($"Name: {abcEmp.Name}");
            Console.WriteLine($"Department: {abcEmp.Dept}");
            Console.WriteLine($"Designation: {abcEmp.Desg}");
            Console.WriteLine($"Basic Salary: {abcEmp.BasicSalary}");
            Console.WriteLine($"Employee PF: {abcEmp.EmployeePF(abcEmp.BasicSalary)}");
            Console.WriteLine($"Leave Details: {abcEmp.LeaveDetails()}");
            Console.WriteLine($"Gratuity Amount: {abcEmp.GratuityAmount(6, abcEmp.BasicSalary)}");

            Console.WriteLine("\nXYZ Employee Details:");
            Console.WriteLine($"Employee ID: {xyzEmp.EmpId}");
            Console.WriteLine($"Name: {xyzEmp.Name}");
            Console.WriteLine($"Department: {xyzEmp.Dept}");
            Console.WriteLine($"Designation: {xyzEmp.Desg}");
            Console.WriteLine($"Basic Salary: {xyzEmp.BasicSalary}");
            Console.WriteLine($"Employee PF: {xyzEmp.EmployeePF(xyzEmp.BasicSalary)}");
            Console.WriteLine($"Leave Details: {xyzEmp.LeaveDetails()}");
            Console.WriteLine($"Gratuity Amount: {xyzEmp.GratuityAmount(4, xyzEmp.BasicSalary)}");

            Console.ReadLine();
        }
    }
}