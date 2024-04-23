using DoctorClinicModel;
using DoctorClinicDALLibrary;
using NUnit.Framework;
using System;
using DoctorClinicBLLibrary;

namespace DoctorClinicBLTester
{
    public class PatientBLTest
    {
        PatientRepository _patientRepository;
        IPatientService _patientService;

        [SetUp]
        public void Setup()
        {
            _patientRepository = new PatientRepository();
            _patientService = new PatientBL(_patientRepository);
        }

        [Test]
        public void AddPatient_Pass()
        {
            // Arrange
            var newPatient = new Patient { Id = 1, Name = "John Doe" };

            // Act
            var result = _patientService.AddPatient(newPatient);

            // Assert
            Assert.AreEqual(newPatient, result);
        }

        [Test]
        public void AddPatient_Fail()
        {
            // Arrange
            var existingPatient = new Patient { Id = 1, Name = "Existing Patient" };
            _patientRepository.Add(existingPatient); 
            // Act
            var result = _patientService.AddPatient(existingPatient);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AddPatient_Exception()
        {
            // Arrange
            var patientWithException = new Patient { Id = 2, Name = "Exception Patient" };

            // Act & Assert
            Assert.Throws<Exception>(() => _patientService.AddPatient(patientWithException));
        }

        [Test]
        public void GetPatient_Pass()
        {
            // Arrange
            var expectedPatient = new Patient { Id = 1, Name = "John Doe" };
            _patientRepository.Add(expectedPatient);

            // Act
            var result = _patientService.GetPatient(1);

            // Assert
            Assert.AreEqual(expectedPatient, result);
        }

        [Test]
        public void GetPatient_Fail()
        {
            // Arrange & Act
            var result = _patientService.GetPatient(999); 

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetPatient_Exception()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _patientService.GetPatient(0)); 
        }

        [Test]
        public void GetAllPatients_Pass()
        {
            // Arrange
            var expectedPatients = new[] {
                new Patient { Id = 1, Name = "John Doe" },
                new Patient { Id = 2, Name = "Jane Smith" }
            };
            foreach (var patient in expectedPatients)
            {
                _patientRepository.Add(patient); 
            }

            // Act
            var result = _patientService.GetAllPatients();

            // Assert
            Assert.AreEqual(expectedPatients.Length, result.Count);
            CollectionAssert.AreEqual(expectedPatients, result);
        }

        [Test]
        public void UpdatePatient_Pass()
        {
            // Arrange
            var patientToUpdate = new Patient { Id = 1, Name = "Updated Patient" };
            _patientRepository.Add(patientToUpdate);

            // Act
            var result = _patientService.UpdatePatient(patientToUpdate);

            // Assert
            Assert.AreEqual(patientToUpdate, result);
        }

        [Test]
        public void UpdatePatient_Fail()
        {
            // Arrange
            var nonExistingPatient = new Patient { Id = 999, Name = "Non-existing Patient" };

            // Act
            var result = _patientService.UpdatePatient(nonExistingPatient);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void UpdatePatient_Exception()
        {
            // Arrange
            var patientWithException = new Patient { Id = 1, Name = "Exception Patient" };

            // Act & Assert
            Assert.Throws<Exception>(() => _patientService.UpdatePatient(patientWithException));
        }

        [Test]
        public void DeletePatient_Pass()
        {
            // Arrange
            var patientIdToDelete = 1;
            _patientRepository.Add(new Patient { Id = patientIdToDelete, Name = "To Delete" }); 

            // Act
            var result = _patientService.DeletePatient(patientIdToDelete);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeletePatient_Fail()
        {
            // Arrange & Act
            var result = _patientService.DeletePatient(999); // Non-existing ID

            // Assert
            Assert.IsNull(result);
        }
    }
}
