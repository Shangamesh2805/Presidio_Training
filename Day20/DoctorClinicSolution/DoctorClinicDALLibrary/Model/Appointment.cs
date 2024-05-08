using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? Date { get; set; }
        public int? DocId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor? Doc { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
