using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Video> videos = new Dictionary<string, Video>();

        public bool Contains(User user)
        {
            return this.users.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
            return this.videos.ContainsKey(video.Id);
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!this.users.ContainsKey(user.Id) || !this.videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            video.Dislikes++;
            user.VideosByLikeOrDislike.Add(video.Id, "dislike");
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            ICollection<User> users = this.users.Values
                .Where(u => u.WatchedVideos.Count == 0 && u.VideosByLikeOrDislike.Count == 0)
                .ToList();

            return users;
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            IEnumerable<User> users = this.users.Values
                .OrderByDescending(u => u.WatchedVideos.Count)
                .ThenByDescending(u => u.VideosByLikeOrDislike.Count)
                .ThenBy(u => u.Username);

            return users;
        }

        public IEnumerable<Video> GetVideos()
        {
            return this.videos.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            IEnumerable<Video> videos = this.videos.Values
                .OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes);

            return videos;
        }

        public void LikeVideo(User user, Video video)
        {
            if (!this.users.ContainsKey(user.Id) || !this.videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            video.Likes++;
            user.VideosByLikeOrDislike.Add(video.Id, "like");
        }

        public void PostVideo(Video video)
        {
            this.videos.Add(video.Id, video);
        }

        public void RegisterUser(User user)
        {
            this.users.Add(user.Id, user);
        }

        public void WatchVideo(User user, Video video)
        {
            if (!this.users.ContainsKey(user.Id) || !this.videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            video.Views++;
            user.WatchedVideos.Add(video);
        }
    }
}
