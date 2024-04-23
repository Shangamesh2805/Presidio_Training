using DoctorClinicBLLibrary;
using DoctorClinicModel;
using DoctorClinicDALLibrary;
using NUnit.Framework;
using System;

namespace DoctorClinicBLTester
{
    public class DoctorClinicBLTest
    {
        IRepository<int, Doctor> _repository;
        IDoctorServices _doctorService;

        [SetUp]
        public void Setup()
        {

            _repository = new DoctorRepository();


            var doctor = new Doctor { Id = 101, Name = "Ram" };
            _repository.Add(doctor);


            _doctorService = new DoctorBL(_repository);
        }

        public void AddDoctor_Pass()
        {
            // Arrange
            var newDoctor = new Doctor { Id = 102, Name = "Shyam" };

            // Act
            var result = _doctorService.AddDoctor(newDoctor);

            // Assert
            Assert.AreEqual(newDoctor, result);
        }

        [Test]
        public void AddDoctor_Fail()
        {
            // Arrange
            var existingDoctor = new Doctor { Id = 101, Name = "Ram" };

            // Act
            var result = _doctorService.AddDoctor(existingDoctor);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AddDoctor_Exception()
        {
            // Arrange
            var doctorWithException = new Doctor { Id = 103, Name = "ExceptionDoctor" };

            // Act & Assert
            Assert.Throws<Exception>(() => _doctorService.AddDoctor(doctorWithException));
        }

        [Test]
        public void GetDoctor_Pass()
        {
            // Arrange
            var expectedDoctor = new Doctor { Id = 101, Name = "Ram" };

            // Act
            var result = _doctorService.GetDoctor(101);

            // Assert
            Assert.AreEqual(expectedDoctor, result);
        }

        [Test]
        public void GetDoctor_Fail()
        {
            // Arrange & Act
            var result = _doctorService.GetDoctor(999); // Non-existing ID

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetDoctor_Exception()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _doctorService.GetDoctor(0)); // Invalid ID
        }
        [Test]
        public void GetAllDoctors_Pass()
        {
            // Arrange
            var expectedDoctors = new List<Doctor>
            {
                new Doctor { Id = 101, Name = "Ram" }
                
            };

            // Act
            var result = _doctorService.GetAllDoctors();

            // Assert
            Assert.AreEqual(expectedDoctors.Count, result.Count);
            Assert.AreEqual(expectedDoctors[0], result[0]); 
        }

        [Test]
        public void UpdateDoctor_Pass()
        {
            // Arrange
            var doctorToUpdate = new Doctor { Id = 101, Name = "Updated Name" };

            // Act
            var result = _doctorService.UpdateDoctor(doctorToUpdate);

            // Assert
            Assert.AreEqual(doctorToUpdate, result);
        }

        [Test]
        public void UpdateDoctor_Fail()
        {
            // Arrange
            var nonExistingDoctor = new Doctor { Id = 999, Name = "Non-existing Doctor" };

            // Act
            var result = _doctorService.UpdateDoctor(nonExistingDoctor);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void UpdateDoctor_Exception()
        {
            // Arrange
            var doctorWithException = new Doctor { Id = 101, Name = "ExceptionDoctor" };

            // Act & Assert
            Assert.Throws<Exception>(() => _doctorService.UpdateDoctor(doctorWithException));
        }

        [Test]
        public void DeleteDoctor_Pass()
        {
            // Arrange
            var doctorIdToDelete = 101;

            // Act
            var result = _doctorService.DeleteDoctor(doctorIdToDelete);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteDoctor_Fail()
        {
            // Arrange
            var nonExistingDoctorId = 999;

            // Act
            var result = _doctorService.DeleteDoctor(nonExistingDoctorId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteDoctor_Exception()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _doctorService.DeleteDoctor(0));
        }
        [Test]
        public void AddDoctor_EmptyName_Fail()
        {
            // Arrange
            var newDoctor = new Doctor { Id = 102, Name = "" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _doctorService.AddDoctor(newDoctor));
        }
    }
}
    