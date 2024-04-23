using DoctorClinicModel;
using System.Collections.Generic;

namespace DoctorClinicBLLibrary
{
    public interface IPatientService
    {
        Patient AddPatient(Patient patient);
        Patient DeletePatient(int id);
        Patient GetPatient(int id);
        List<Patient> GetAllPatients();
        Patient UpdatePatient(Patient patient);
    }
}
