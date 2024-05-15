namespace DoctorClinicAPI.Exceptions;



    public class NoSuchDoctorException : Exception
    {
        string msg;
        public NoSuchDoctorException()
        {
            msg = "No Doctor Found in this data";
        }
        public override string Message => msg;
    }
