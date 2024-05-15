using DoctorClinicAPI.Models;

namespace DoctorClinicAPI.Interfaces
{
    public class IDoctorServices
    {
        internal Task Doctors;

        public Task<IEnumerable<Doctor>> GetDoctors();
        public  Task<Doctor> UpdateDoctorExperience(int id, int experience);
        public Task<IEnumerable<Doctor>> GetDoctorsBySpecialty(string specialty);
    }
}
