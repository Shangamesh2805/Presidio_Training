﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITemployeeManagementModel
{
    public interface GovRUles
    {
        public double EmployeePF(double basicSalary);
        public string LeaveDetails();
        public double GratuityAmount(float serviceCompleted, double basicSalary);
    }
}
