using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst firstValue, TSecond secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        public TFirst FirstValue { get; }

        public TSecond SecondValue { get; }

        public override string ToString()
        {
            return $"{FirstValue} -> {SecondValue}";
        }
    }
}
