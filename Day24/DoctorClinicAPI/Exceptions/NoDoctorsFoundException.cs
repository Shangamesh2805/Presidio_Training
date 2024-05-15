namespace DoctorClinicAPI.Exceptions
{
    public class NoDoctorsFoundException: Exception
    {
        public NoDoctorsFoundException() : base("No doctors found.") { }
    }
}
