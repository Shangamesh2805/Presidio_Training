using RequestTrackerModel;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployeeByName(string name);
        List<Employee> GetEmployeeByType(string type);
        List<Employee> GetEmployeeByRole(string role);
        List<Employee> GetEmployeeInSalaryRange(double minSalary, double maxSalary);
        Employee ChangeEmployeeName(int employeeId, string newEmployeeName);
        Employee ChangeEmployeeType(int employeeId, string newType);
        Employee ChangeEmployeeRole(int employeeId, string newRole);
        Employee ChangeSalary(int employeeId, double updatedSalary);
    }
}