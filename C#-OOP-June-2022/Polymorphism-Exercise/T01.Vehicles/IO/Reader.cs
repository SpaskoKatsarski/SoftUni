using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Reader : IReader
    {
        string IReader.ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
