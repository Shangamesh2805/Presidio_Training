using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
