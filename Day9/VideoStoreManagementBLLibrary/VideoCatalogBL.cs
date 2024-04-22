using System;
using System.Collections.Generic;
using System.Linq;
using Video_Store_Management_Models;
using VideoStoreManagmentDALLibrary;

namespace VideoStoreManagementBLLibrary
{
    public class VideoCatalogBL : IVideoCatalogService
    {
        private readonly VideoRepository _videoRepository;

        public VideoCatalogBL(VideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public bool RentVideoToCustomer(int videoId, int customerId)
        {
            try
            {
                var video = _videoRepository.Get(videoId);
                if (video != null && video.IsAvailable)
                {
                    video.IsAvailable = false; 
                    _videoRepository.Update(video); 
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while renting the video: {ex.Message}");
                return false; 
            }
        }

        public Video AddVideo(Video video)
        {
            try
            {
                return _videoRepository.Add(video);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the video: {ex.Message}");
                return null;
            }
        }

        public List<Video> GetAllVideos()
        {
            try
            {
                return _videoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all videos: {ex.Message}");
                return null;
            }
        }

        public List<Video> GetAvailableVideos()
        {
            try
            {
                return _videoRepository.GetAvailableVideos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving available videos: {ex.Message}");
                return null;
            }
        }

        public Video GetVideoById(int videoId)
        {
            try
            {
                return _videoRepository.Get(videoId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the video: {ex.Message}");
                return null;
            }
        }

        public List<Video> GetVideosByGenre(string genre)
        {
            try
            {
                return _videoRepository.GetVideosByGenre(genre);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving videos by genre: {ex.Message}");
                return null;
            }
        }
    }
}
