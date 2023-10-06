using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private List<User> users = new List<User>();
        private List<Video> videos = new List<Video>();

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
            user.VideosByLikeOrDislike.Add(video.Id, "dislike");
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            ICollection<User> users = this.users
                .Where(u => u.WatchedVideos.Count == 0 && u.VideosByLikeOrDislike.Count == 0)
                .ToList();

            return users;
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            IEnumerable<User> users = this.users
                .OrderByDescending(u => u.WatchedVideos.Count)
                .ThenByDescending(u => u.VideosByLikeOrDislike.Count)
                .ThenBy(u => u.Username);

            return users;
        }

        public IEnumerable<Video> GetVideos()
        {
            return this.videos.AsEnumerable();
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            IEnumerable<Video> videos = this.videos
                .OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes);

            return videos;
        }

        public void LikeVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Likes++;
            user.VideosByLikeOrDislike.Add(video.Id, "like");
        }

        public void PostVideo(Video video)
        {
            this.videos.Add(video);
        }

        public void RegisterUser(User user)
        {
            this.users.Add(user);
        }

        public void WatchVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Views++;
            user.WatchedVideos.Add(video);
        }
    }
}
