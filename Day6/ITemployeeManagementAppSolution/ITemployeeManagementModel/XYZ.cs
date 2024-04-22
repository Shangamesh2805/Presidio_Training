using System;

namespace ITemployeeManagementModel
{
    public class XYZ : GovRUles
    {
        public int EmpId { get; }
        public string Name { get; }
        public string Dept { get; }
        public string Desg { get; }
        public double BasicSalary { get; }

        
        public XYZ(int empId, string name, string dept, string desg, double basicSalary)
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
            return "Leave Details for XYZ is: \n2 days of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Privilege Leave per year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0; 
        }
    }
}
