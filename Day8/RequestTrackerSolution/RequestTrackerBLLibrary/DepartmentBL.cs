using RequestTrackerDALLibrary;
using RequestTrakerModel;


namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var departmentList = _departmentRepository.GetAll();
            Department department = null;
            foreach (var dep in departmentList)
            {
                if (dep.Name == departmentOldName)
                {
                    department = dep;
                    break;
                }
            }

            if (department != null)
            {
                department.Name = departmentNewName;
                var result = _departmentRepository.Update(department);
                if (result != null)
                {
                    return department;
                }
            }

            throw new KeyNotFoundException($"Department with the old name '{departmentOldName}' does not exist.");
        }

        public Department GetDepartmentById(int id)
        {
            var result = _departmentRepository.Get(id);
            if (result != null)
            {
                return result;
            }
            throw new KeyNotFoundException($"Department with the provided ID '{id}' does not exist.");
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var departmentList = _departmentRepository.GetAll();
            foreach (var dep in departmentList)
            {
                if (dep.Name == departmentName)
                {
                    return dep;
                }
            }
            throw new KeyNotFoundException($"Department with the provided name '{departmentName}' does not exist.");
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            if (department != null)
            {
                return department.Department_Head;
            }
            throw new KeyNotFoundException($"Department with the provided ID '{departmentId}' does not exist.");
        }
    }
}