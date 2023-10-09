namespace Exam.ViTube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ViTubeRepository : IViTubeRepository
    {
        private List<User> users;
        private List<Video> videos;

        private Dictionary<User, List<Video>> watchedVideosByUser;
        private Dictionary<User, List<Video>> likedVideosByUser;
        private Dictionary<User, List<Video>> dislikedVideosByUser;

        private Dictionary<User, int> usersWithActivity;

        public ViTubeRepository()
        {
            this.users = new List<User>();
            this.videos = new List<Video>();

            this.watchedVideosByUser = new Dictionary<User, List<Video>>();
            this.likedVideosByUser = new Dictionary<User, List<Video>>();
            this.dislikedVideosByUser = new Dictionary<User, List<Video>>();

            this.usersWithActivity = new Dictionary<User, int>();
        }

        public bool Contains(User user)
        {
            return this.users.Contains(user);
        }

        public bool Contains(Video video)
        {
            return this.videos.Contains(video);
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Dislikes++;
            this.dislikedVideosByUser[user].Add(video);
            this.usersWithActivity[user]++;
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            List<User> passiveUsers = new List<User>();

            return this.users
                .Where(u => this.usersWithActivity[u] == 0);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            return this.users
                .OrderByDescending(u => this.watchedVideosByUser[u].Count)
                .ThenByDescending(u => this.likedVideosByUser[u].Count + this.dislikedVideosByUser[u].Count)
                .ThenBy(u => u.Username);
        }

        public IEnumerable<Video> GetVideos()
        {
            return this.videos;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return this.videos
                .OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes);
        }

        public void LikeVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Likes++;
            this.likedVideosByUser[user].Add(video);
            this.usersWithActivity[user]++;
        }

        public void PostVideo(Video video)
        {
            this.videos.Add(video);
        }

        public void RegisterUser(User user)
        {
            this.users.Add(user);
            this.RegisterUserActivity(user);
        }

        public void WatchVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Views++;
            this.watchedVideosByUser[user].Add(video);
            this.usersWithActivity[user]++;
        }

        private void RegisterUserActivity(User user)
        {
            this.watchedVideosByUser.Add(user, new List<Video>());
            this.likedVideosByUser.Add(user, new List<Video>());
            this.dislikedVideosByUser.Add(user, new List<Video>());
            this.usersWithActivity.Add(user, 0);
        }
    }
}
