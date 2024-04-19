using RequestTrackerDALLibrary;
using RequestTrackerModel;
namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        private readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL(IRepository<int, Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public int AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var result = _employeeRepository.Add(employee);
            if (result != null)
            {
                return result.Id;
            }
            throw new Exception("Failed to add employee.");
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return employee;
            }
            throw new KeyNotFoundException($"Employee with ID '{id}' not found.");
        }

        public List<Employee> GetEmployeeByName(string name)
        {
            var employees = _employeeRepository.GetAll().FindAll(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (employees.Count > 0)
            {
                return employees;
            }
            throw new KeyNotFoundException($"Employee with name '{name}' not found.");
        }

        public List<Employee> GetEmployeeByType(string type)
        {
            var employees = _employeeRepository.GetAll().FindAll(e => e.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
            if (employees.Count > 0)
            {
                return employees;
            }
            throw new KeyNotFoundException($"Employee with type '{type}' not found.");
        }

        public List<Employee> GetEmployeeByRole(string role)
        {
            var employees = _employeeRepository.GetAll().FindAll(e => e.Role.Equals(role, StringComparison.OrdinalIgnoreCase));
            if (employees.Count > 0)
            {
                return employees;
            }
            throw new KeyNotFoundException($"Employee with role '{role}' not found.");
        }

        public List<Employee> GetEmployeeInSalaryRange(double minSalary, double maxSalary)
        {
            var employees = _employeeRepository.GetAll().FindAll(e => e.Salary >= minSalary && e.Salary <= maxSalary);
            if (employees.Count > 0)
            {
                return employees;
            }
            throw new KeyNotFoundException($"No employees found within the salary range of {minSalary} to {maxSalary}.");
        }

        public Employee ChangeEmployeeName(int employeeId, string newEmployeeName)
        {
            var employee = GetEmployeeById(employeeId);
            employee.Name = newEmployeeName;
            var updatedEmployee = _employeeRepository.Update(employee);
            if (updatedEmployee != null)
            {
                return updatedEmployee;
            }
            throw new Exception($"Failed to change name for employee with ID '{employeeId}'.");
        }

        public Employee ChangeEmployeeType(int employeeId, string newType)
        {
            var employee = GetEmployeeById(employeeId);
            employee.Type = newType;
            var updatedEmployee = _employeeRepository.Update(employee);
            if (updatedEmployee != null)
            {
                return updatedEmployee;
            }
            throw new Exception($"Failed to change type for employee with ID '{employeeId}'.");
        }

        public Employee ChangeEmployeeRole(int employeeId, string newRole)
        {
            var employee = GetEmployeeById(employeeId);
            employee.Role = newRole;
            var updatedEmployee = _employeeRepository.Update(employee);
            if (updatedEmployee != null)
            {
                return updatedEmployee;
            }
            throw new Exception($"Failed to change role for employee with ID '{employeeId}'.");
        }

        public Employee ChangeSalary(int employeeId, double updatedSalary)
        {
            var employee = GetEmployeeById(employeeId);
            employee.Salary = updatedSalary;
            var updatedEmployee = _employeeRepository.Update(employee);
            if (updatedEmployee != null)
            {
                return updatedEmployee;
            }
            throw new Exception($"Failed to change salary for employee with ID '{employeeId}'.");
        }
    }
}
