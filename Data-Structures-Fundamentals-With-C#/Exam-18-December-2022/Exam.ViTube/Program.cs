using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ViTubeRepository repo = new ViTubeRepository();

            var user = new User("1", "Pesho");
            repo.RegisterUser(user);

            IEnumerable<User> passiveUsers = repo.GetPassiveUsers();

            Console.WriteLine(passiveUsers.Count());

            var video = new Video("1", "Destroying G class", 120, 50, 60, 2);
            repo.PostVideo(video);

            Console.WriteLine("Dislikes: " + video.Dislikes);
            repo.DislikeVideo(user, video);
            Console.WriteLine("Dislikes: " + video.Dislikes);

            Console.WriteLine("Views: " + video.Views);
            repo.WatchVideo(user, video);
            Console.WriteLine("Views: " + video.Views);

            Console.WriteLine(passiveUsers.Count());
        }
    }
}
