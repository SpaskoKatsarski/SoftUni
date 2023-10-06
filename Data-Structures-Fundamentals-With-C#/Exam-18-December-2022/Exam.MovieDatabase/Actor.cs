using System.Collections.Generic;

namespace Exam.MovieDatabase
{
    public class Actor
    {
        public Actor(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
