namespace AquaShop.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Models.Aquariums.Contracts;
    using Models.Fish.Contracts;
    using Models.Aquariums;
    using Models.Decorations;
    using Models.Fish;
    using Repositories;
    using Contracts;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            if (decorationType == nameof(Ornament))
            {
                this.decorations.Add(new Ornament());
            }
            else if (decorationType == nameof(Plant))
            {
                this.decorations.Add(new Plant());
            }

            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = this.aquariums.First(a => a.Name == aquariumName);
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            IFish fish = null;
            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            
            var aquarium = this.aquariums.First(a => a.Name == aquariumName);
            
            if ((aquarium.GetType().Name == nameof(FreshwaterAquarium) && fish.GetType().Name == nameof(FreshwaterFish)) || (aquarium.GetType().Name == nameof(SaltwaterAquarium) && fish.GetType().Name == nameof(SaltwaterFish)))
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return "Water not suitable.";
            }
        }

        public string FeedFish(string aquariumName)
        {
            var aqurarium = this.aquariums.First(a => a.Name == aquariumName);
            aqurarium.Feed();
            return $"Fish fed: {aqurarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal sum = 0;
            var aquarium = this.aquariums.First(a => a.Name == aquariumName);

            sum += aquarium.Fish.Select(f => f.Price).Sum();
            sum += aquarium.Decorations.Select(d => d.Price).Sum();

            return $"The value of Aquarium {aquariumName} is {sum:f2}.";
        }

        public string Report()
        {
            var result = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                result.AppendLine(aquarium.GetInfo());
            }

            return result.ToString().Trim();
        }
    }
}
