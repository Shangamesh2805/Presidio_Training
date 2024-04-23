using DoctorClinicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorClinicBLLibrary
{
    public interface IDoctorServices
    {
        Doctor AddDoctor(Doctor doctor);
        Doctor GetDoctor(int id);
        List<Doctor> GetAllDoctors();
        Doctor UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(int id);
        object AddDoctor();
    }
}
