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
            this.VideosByLikeOrDislike = new Dictionary<string, string>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public ICollection<Video> WatchedVideos { get; set; }

        // VideoId -> "like" or "dislike"
        public Dictionary<string, string> VideosByLikeOrDislike { get; private set; }
    }
}
