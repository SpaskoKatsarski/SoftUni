namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Contracts;
    using System.Linq;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Name} ({this.GetType().Name}):");
            result.Append("Fish: ");
            result.AppendLine(this.Fish.Count == 0 ? "none" : $"{string.Join(", ", this.Fish.Select(f => f.Name))}");
            result.AppendLine($"Decorations: {this.Decorations.Count}");
            result.AppendLine($"Comfort: {this.Comfort}");

            return result.ToString().Trim();
        }
    }
}
