using System;
using System.Collections.Generic;
using Video_Store_Management_Models;
using VideoStoreManagmentDALLibrary;

namespace VideoStoreManagementBLLibrary
{
    public class RentalBL : IRentalService
    {
        private readonly RentalRepository _rentalRepository;
        private readonly VideoRepository _videoRepository;

        public RentalBL(RentalRepository rentalRepository, VideoRepository videoRepository)
        {
            _rentalRepository = rentalRepository;
            _videoRepository = videoRepository;
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
                Rental rental = new Rental(customerId, videoId);
                _rentalRepository.Add(rental);

                var video = _videoRepository.Get(videoId);
                if (video != null)
                {
                    video.IsAvailable = false;
                    _videoRepository.Update(video);
                }
                else
                {
                    throw new KeyNotFoundException($"Video with ID {videoId} does not exist.");
                }

                Console.WriteLine("Video rented successfully.");
                return rental; 
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
                var rental = _rentalRepository.Get(rentalId);
                if (rental != null)
                {
                    var videoId = rental.VideoId;
                    _rentalRepository.Delete(rentalId); 
                    var video = _videoRepository.Get(videoId);
                    if (video != null)
                    {
                        video.IsAvailable = true; 
                        _videoRepository.Update(video); 
                        return true;
                    }
                    else
                    {
                        throw new KeyNotFoundException($"Video with ID {videoId} does not exist.");
                    }
                }
                else
                {
                    throw new KeyNotFoundException($"Rental with ID {rentalId} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while returning the video: {ex.Message}");
                return false;
            }
        }
    }
}
