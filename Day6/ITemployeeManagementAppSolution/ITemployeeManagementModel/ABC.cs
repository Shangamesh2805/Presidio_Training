using System;

namespace ITemployeeManagementModel
{
    public class ABC : GovRUles
    {
        
        public int EmpId { get; }
        public string Name { get; }
        public string Dept { get; }
        public string Desg { get; }
        public double BasicSalary { get; }

        
        public ABC(int empId, string name, string dept, string desg, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Dept = dept;
            Desg = desg;
            BasicSalary = basicSalary;
        }

        public double EmployeePF(double basicSalary)
        {
            return 0.12 * basicSalary; 
        }

        public string LeaveDetails()
        {
            return "Leave Details for ABC is: \n1 day of Casual Leave per month\n12 days of Sick Leave per year\n10 days of Privilege Leave per year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            
            if (serviceCompleted > 5)
            {
                return basicSalary; 
            }
            return 0;
        }
    }
}