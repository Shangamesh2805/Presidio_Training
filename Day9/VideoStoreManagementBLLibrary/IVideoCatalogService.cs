using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video_Store_Management_Models;

namespace VideoStoreManagementBLLibrary
{
    public interface IVideoCatalogService
    {
        Video AddVideo(Video video);
        Video GetVideoById(int videoId);
        List<Video> GetAllVideos();
        List<Video> GetAvailableVideos();
        List<Video> GetVideosByGenre(string genre);
    }

}
