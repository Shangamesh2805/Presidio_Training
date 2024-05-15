using DoctorClinicAPI.Models;

namespace DoctorClinicAPI.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialty(string specialty);
        Task<Doctor> GetDoctorById(int id);
    }
}
