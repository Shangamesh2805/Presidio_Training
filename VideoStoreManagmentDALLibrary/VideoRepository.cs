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
            if (_videos.ContainsValue(video))
            {
                return null;
            }
            video.Id = GenerateId();
            _videos.Add(video.Id, video);
            return video;
        }

        public Video Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Video Get(int key)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAll()
        {
            throw new NotImplementedException();
        }

        public Video Update(Video item)
        {
            throw new NotImplementedException();
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
