﻿using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Services
{
    public class IEmployeeLoginBL
    {
        public Task<bool> Login(Employee employee);

        public Task<Employee> Register(Employee employee);
    }
}
