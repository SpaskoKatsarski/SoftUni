namespace AquaShop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models = new List<IDecoration>();

        public IReadOnlyCollection<IDecoration> Models => this.models.ToList().AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(d => d.GetType().Name == type);
        }
    }
}
