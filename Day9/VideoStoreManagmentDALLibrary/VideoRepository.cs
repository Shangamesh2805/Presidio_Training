using System.Collections.Generic;
using Video_Store_Management_Models;
namespace VideoStoreManagmentDALLibrary
{
    public class VideoRepository : IRepository<int, Video>
    {
       private readonly Dictionary<int, Video> _videos;

        public VideoRepository()
        {
                _videos = new Dictionary<int, Video>();
            
        }

        public Video Add(Video video)
        {
            try
            {
                if (_videos.ContainsValue(video))
                {
                    throw new InvalidOperationException("Video already exists in the repository.");
                }

                video.Id = GenerateId();
                _videos.Add(video.Id, video);
                return video;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while adding the video: {ex.Message}");
                return null;
            }
        }

        public Video Delete(int key)
        {
            try
            {
                if (_videos.ContainsKey(key))
                {
                    var video = _videos[key];
                    _videos.Remove(key);
                    return video;
                }
                else
                {
                    throw new KeyNotFoundException($"Video with ID {key} does not found in the repository.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the video: {ex.Message}");
                return null;
            }
        }
    

        public Video Get(int key)
        {
           
            try
            {
                if (_videos.ContainsKey(key))
                {
                    return _videos[key];
                }
                else
                {
                    throw new KeyNotFoundException($"Video with ID {key} does not exist in the repository.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the video: {ex.Message}");
                return null;
            }
        }
    

        public List<Video> GetAll()
        {
            return _videos.Values.ToList();
        }

        public List<Video> GetAvailableVideos()
        {
            throw new NotImplementedException();
        }

        public List<Video> GetVideosByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public Video Update(Video video)
        {
            try
            {
                if (_videos.ContainsKey(video.Id))
                {
                    _videos[video.Id] = video;
                    return video;
                }
                else
                {
                    throw new KeyNotFoundException($"Video with ID {video.Id} does not exist in the repository.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the video: {ex.Message}");
                return null;
            }
        }
    
        private int GenerateId()
        {
            if (_videos.Count == 0)
            {
                return 1;
            }
            int id = _videos.Keys.Max();
            return ++id;
        }
    }
}
