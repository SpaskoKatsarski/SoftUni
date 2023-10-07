using System.Collections.Generic;

namespace PublicTransportManagementSystem
{
    public class Bus
    {
        public string Id { get; set; }
    
        public string Number { get; set; }
    
        public int Capacity { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}