namespace CatDatabase
{
    using CatDatabase.Interfaces;
    using System.Collections;

    public class MeowDatabase : IEnumerable, IMeowDatabase
    {
        private readonly List<ICat> cats;

        public MeowDatabase()
        {
            this.cats = new List<ICat>();
        }

        public MeowDatabase(params ICat[] cats)
            :this()
        {
            foreach (var cat in cats)
            {
                this.cats.Add(cat);
            }
        }

        public IEnumerator<ICat> GetEnumerator()
        {
            foreach (var cat in this.cats)
                yield return cat;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<ICat> ReturnAllCatsUnderYears(int years)
        {
            List<ICat> catsBelowTheGivenYears = this.Cats.Where(c => c.Age < years).ToList();
            return catsBelowTheGivenYears;
        }

        public void Add(ICat cat)
        {
            if (this.Cats.Any(c => c.Name == cat.Name))
            {
                throw new InvalidOperationException("Cat with this name already exists!");
            }

            this.cats.Add(cat);
        }

        public IReadOnlyCollection<ICat> Cats => this.cats.AsReadOnly();

        public void Remove(string name)
        {
            if (this.Cats.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty!");
            }

            if (!this.Cats.Any(c => c.Name == name))
            {
                throw new InvalidOperationException("Cat with the given name doesn't exist!");
            }

            this.cats.Remove(this.Cats.First(c => c.Name == name));
        }

        public ICat GetOldestCat()
        {
            return this.Cats.OrderByDescending(c => c.Age).First();
        }
    }
}
