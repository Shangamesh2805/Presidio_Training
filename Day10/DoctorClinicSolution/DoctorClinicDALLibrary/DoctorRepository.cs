using System.Numerics;
using DoctorClinicModel;

namespace DoctorClinicDALLibrary
{
    public class DoctorRepository : IRepository <int, Doctor>
    {
        private readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        public Doctor Add(Doctor doctor)
        {
            if (_doctors.ContainsValue(doctor))
            {
                return null;
            }
            doctor.Id = GenerateId();
            _doctors.Add(doctor.Id, doctor);
            return doctor;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var doctor = _doctors[key];
                _doctors.Remove(key);
                return doctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            return _doctors.ContainsKey(key) ? _doctors[key] : null;
        }

        public List<Doctor> GetAll()
        {
            return _doctors.Values.ToList();
        }

        public Doctor Update(Doctor doctor)
        {
            if (_doctors.ContainsKey(doctor.Id))
            {
                _doctors[doctor.Id] = doctor;
                return doctor;
            }
            return null;
        }

        private int GenerateId()
        {
            return _doctors.Count == 0 ? 1 : _doctors.Keys.Max() + 1;
        }
    }

}

