using System.Collections.Generic;

namespace Exam.ViTube
{
    public class User
    {
        public User(string id, string username)
        {
            Id = id;
            Username = username;
            this.WatchedVideos = new List<Video>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public ICollection<Video> WatchedVideos { get; set; }

        // VideoId -> "like" or "dislike"
        public int LikedAndDislikedVideosCount { get; set; }
    }
}
