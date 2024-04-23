using DoctorClinicModel;
using DoctorClinicDALLibrary;
using System;
using System.Collections.Generic;

namespace DoctorClinicBLLibrary
{
    public class DoctorBL : IDoctorServices
    {
        private readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorBL(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            try
            {
                return _doctorRepository.Add(doctor);
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogAndThrow(ex, "An error occurred while adding the doctor");
                throw; // Add a throw statement here to satisfy all code paths
            }
        }

        public Doctor GetDoctor(int id)
        {
            try
            {
                return _doctorRepository.Get(id);
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogAndThrow(ex, "An error occurred while getting the doctor");
                throw; // Add a throw statement here to satisfy all code paths
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            try
            {
                return _doctorRepository.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogAndThrow(ex, "An error occurred while getting all doctors");
                throw; // Add a throw statement here to satisfy all code paths
            }
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            try
            {
                return _doctorRepository.Update(doctor);
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogAndThrow(ex, "An error occurred while updating the doctor");
                throw; // Add a throw statement here to satisfy all code paths
            }
        }

        public bool DeleteDoctor(int id)
        {
            try
            {
                var deletedDoctor = _doctorRepository.Delete(id);
                return deletedDoctor != null;
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogAndThrow(ex, "An error occurred while deleting the doctor");
                throw; // Add a throw statement here to satisfy all code paths
            }
        }

        public object AddDoctor()
        {
            throw new NotImplementedException();
        }
    }
}
