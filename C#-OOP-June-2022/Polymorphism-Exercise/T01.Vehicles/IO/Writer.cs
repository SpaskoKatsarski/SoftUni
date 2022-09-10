using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Writer : IWriter
    {
        void IWriter.WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
