using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DocId { get; set; }
        public string Name { get; set; } = null!;
        public string Specialization { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
