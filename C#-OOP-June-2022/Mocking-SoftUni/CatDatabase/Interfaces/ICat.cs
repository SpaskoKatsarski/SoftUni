using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatDatabase.Interfaces
{
    public interface ICat
    {
        string Name { get; }

        string Description { get; }

        int Age { get; }

        void Meow();
    }
}
