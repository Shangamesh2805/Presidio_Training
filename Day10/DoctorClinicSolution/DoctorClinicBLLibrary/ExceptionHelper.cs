using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace DoctorClinicBLLibrary
{
    public static class ExceptionHelper
    {
        public static void LogAndThrow(Exception ex, string errorMessage)
        {
            Log.Error(ex, errorMessage);
            throw ex;
        }
    }
}
