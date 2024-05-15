using DoctorClinicAPI.Exceptions;
using DoctorClinicAPI.Interfaces;
using DoctorClinicAPI.Models;
using DoctorClinicAPI.Services;


namespace DoctorClinicAPI.Services
{
    public class DoctorService : IDoctorServices
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _doctorRepository.GetDoctors();
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int experience)
        {
            var doctor = await _doctorRepository.GetDoctorById(id);
            if (doctor == null)
                throw new NoSuchDoctorException();

            doctor.Experience = experience;
            return await _doctorRepository.UpdateDoctor(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialty(string specialty)
        {
            return await _doctorRepository.GetDoctorsBySpecialty(specialty);
        }
    }
}