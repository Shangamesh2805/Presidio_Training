using DoctorClinicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly Dictionary<int, Appointment> _appointment;

        public AppointmentRepository()
        {
            _appointment = new Dictionary<int, Appointment>();
        }
        public Appointment Add(Appointment appointment)
        {
            if (_appointment.ContainsKey(appointment.AppointmentId))
            {
                return null;
            }
            appointment.AppointmentId = GenerateId();
            _appointment.Add(appointment.AppointmentId, appointment);
            return appointment;
        }
        public Appointment Delete(int key)
        {
            if (_appointment.ContainsKey(key))
            {
                var patient = _appointment[key];
                _appointment.Remove(key);
                return patient;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            return _appointment.ContainsKey(key) ? _appointment[key] : null;
        }

        public List<Appointment> GetAll()
        {
            return _appointment.Values.ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            if (_appointment.ContainsKey(appointment.AppointmentId))
            {
                _appointment[appointment.AppointmentId] = appointment;
                return appointment;
            }
            return null;
        }

        private int GenerateId()
        {
            return _appointment.Count == 0 ? 1 : _appointment.Keys.Max() + 1;
        }
    }

}