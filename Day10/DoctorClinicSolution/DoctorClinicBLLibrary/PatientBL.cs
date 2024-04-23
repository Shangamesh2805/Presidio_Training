using DoctorClinicModel;
using DoctorClinicDALLibrary;
using System;
using System.Collections.Generic;

namespace DoctorClinicBLLibrary
{
    public class PatientBL : IPatientService
    {
        private readonly PatientRepository _patientRepository;

        public PatientBL(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient AddPatient(Patient patient)
        {
            try
            {
                return _patientRepository.Add(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the patient: {ex.Message}");
                return null;
            }
        }

        public Patient DeletePatient(int id)
        {
            try
            {
                return _patientRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the patient: {ex.Message}");
                return null;
            }
        }

        public Patient GetPatient(int id)
        {
            try
            {
                return _patientRepository.Get(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the patient: {ex.Message}");
                return null;
            }
        }

        public List<Patient> GetAllPatients()
        {
            try
            {
                return _patientRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all patients: {ex.Message}");
                return null;
            }
        }

        public Patient UpdatePatient(Patient patient)
        {
            try
            {
                return _patientRepository.Update(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the patient: {ex.Message}");
                return null;
            }
        }
    }
}
