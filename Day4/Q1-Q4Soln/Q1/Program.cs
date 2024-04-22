using System;

namespace DoctorsApp
{
    class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        /// <summary>
        /// Initializes a new instance of the Doctor class.
        /// </summary>
        /// <param name="id">Doctor's ID</param>
        /// <param name="name">Doctor's name</param>
        /// <param name="age">Doctor's age</param>
        /// <param name="experience">Doctor's experience in years</param>
        /// <param name="qualification">Doctor's qualification</param>
        /// <param name="speciality">Doctor's speciality</param>

        public Doctor(int id, string name, int age, int experience, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = experience;
            Qualification = qualification;
            Speciality = speciality;
        }

        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Doctor ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Experience: {Experience} years");
            Console.WriteLine($"Qualification: {Qualification}");
            Console.WriteLine($"Speciality: {Speciality}");
            Console.WriteLine();
        }
    }

    class Hospital
    {
        private Doctor[] doctors;

        public Hospital()
        {
            doctors = new Doctor[]
            {
                new Doctor(101, "Dr. Venkat", 35, 10, "MBBS", "Cardiology"),
                new Doctor(102, "Dr. Kavin", 29, 1, "MD", "Orthopedics"),
                new Doctor(103, "Dr. Shangmesh",29, 1 , "MS", "Cardiology"),
                new Doctor(104, "Dr. Ramu", 38, 7, "MBBS", "Pediatrics"),
                new Doctor(105, "Dr. Abi", 30, 2, "MD", "Orthopedics"),
            };
        }

        public void PrintAllDoctors()
        {
            Console.WriteLine("All Doctors:");
            Console.WriteLine();

            foreach (var doctor in doctors)
            {
                doctor.PrintDoctorDetails();
            }
        }

        public void PrintDoctorsBySpeciality(string speciality)
        {
            Console.WriteLine($"Doctors in {speciality}:");
            Console.WriteLine();

            foreach (var doctor in doctors)
            {
                if (doctor.Speciality == speciality)
                {
                    doctor.PrintDoctorDetails();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            hospital.PrintAllDoctors();

            bool isValidSpeciality = false;
            string specificSpeciality;
            do
            {
                Console.WriteLine("To view Specific Doctors");
                Console.WriteLine();
                Console.WriteLine("Enter the Speciality of Doctor: ");
                Console.WriteLine();
                Console.WriteLine("List of Fields:  Cardiology  Orthopedics   Pediatrics  ");
                Console.WriteLine();
                specificSpeciality = Console.ReadLine();

                foreach (var doctor in hospital.doctors)
                {
                    if (doctor.Speciality == specificSpeciality)
                    {
                        isValidSpeciality = true;
                        break;
                    }
                }

                if (!isValidSpeciality)
                {
                    Console.WriteLine("Invalid input. Please enter a valid specialty.");
                }

            } while (!isValidSpeciality);

            hospital.PrintDoctorsBySpeciality(specificSpeciality);
        }
    }
}
