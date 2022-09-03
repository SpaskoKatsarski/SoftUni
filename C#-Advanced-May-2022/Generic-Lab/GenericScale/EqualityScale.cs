using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        

        public EqualityScale(T leftElement, T rightElement)
        {
            this.leftElement = leftElement;
            this.rightElement = rightElement;
        }

        private T leftElement;
        private T rightElement;

        public T LeftElement
        {
            get { return leftElement; }
            set { leftElement = value; }
        }

        public T RightElement
        {
            get { return rightElement; }
            set { rightElement = value; }
        }

        public bool AreEqual()
        {
            return this.leftElement.Equals(this.rightElement);
        }
    }
}
