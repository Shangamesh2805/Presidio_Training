using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorClinicModel;

namespace DoctorClinicDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>

    {
        private readonly Dictionary<int, Patient> _patients;

        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }

        public Patient Add(Patient patient)
        {
            if (_patients.ContainsValue(patient))
            {
                return null;
            }
            patient.Id = GenerateId();
            _patients.Add(patient.Id, patient);
            return patient;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var patient = _patients[key];
                _patients.Remove(key);
                return patient;
            }
            return null;
        }

        public Patient Get(int key)
        {
            return _patients.ContainsKey(key) ? _patients[key] : null;
        }

        public List<Patient> GetAll()
        {
            return _patients.Values.ToList();
        }

        public Patient Update(Patient patient)
        {
            if (_patients.ContainsKey(patient.Id))
            {
                _patients[patient.Id] = patient;
                return patient;
            }
            return null;
        }

        private int GenerateId()
        {
            return _patients.Count == 0 ? 1 : _patients.Keys.Max() + 1;
        }
    }

}

