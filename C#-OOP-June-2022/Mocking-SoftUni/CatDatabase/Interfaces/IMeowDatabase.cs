using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatDatabase.Interfaces
{
    public interface IMeowDatabase
    {
        public void Add(ICat cat);

        public void Remove(string name);

        public ICat GetOldestCat();

        public List<ICat> ReturnAllCatsUnderYears(int years);
    }
}
