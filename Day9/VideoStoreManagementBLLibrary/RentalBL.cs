using System;
using System.Collections.Generic;
using Video_Store_Management_Models;
using VideoStoreManagmentDALLibrary;

namespace VideoStoreManagementBLLibrary
{
    public class RentalBL : IRentalService
    {
        private readonly RentalRepository _rentalRepository;

        public RentalBL()
        {
            _rentalRepository = new RentalRepository();
        }

        public List<Rental> GetAllRentals()
        {
            try
            {
                return _rentalRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all rentals: {ex.Message}");
                return null;
            }
        }

        public List<Rental> GetRentalsByCustomer(int customerId)
        {
            try
            {
                
                return _rentalRepository.GetRentalsByCustomer(customerId);
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving rentals by customer: {ex.Message}");
                return null;
            }
        }

        public List<Rental> GetRentalsByVideo(int videoId)
        {
            try
            {
                
                return _rentalRepository.GetRentalsByVideo(videoId);
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving rentals by video: {ex.Message}");
                return null;
            }
        }

        public Rental RentVideo(int customerId, int videoId)
        {
            try
            {
                Rental rental = new(customerId, videoId);

                return _rentalRepository.Add(rental);
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while renting the video: {ex.Message}");
                return null;
            }
        }

        public bool ReturnVideo(int rentalId)
        {
            try
            {
                
                return _rentalRepository.Delete(rentalId) != null;
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while returning the video: {ex.Message}");
                return false;
            }
        }
    }
}
