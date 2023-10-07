using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        private HashSet<Bus> buses = new HashSet<Bus>();
        private HashSet<Passenger> passengers = new HashSet<Passenger>();

        private Dictionary<Bus, HashSet<Passenger>> passengersByBus = new Dictionary<Bus, HashSet<Passenger>>();

        public void RegisterPassenger(Passenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void AddBus(Bus bus)
        {
            this.buses.Add(bus);
            this.passengersByBus.Add(bus, new HashSet<Passenger>());
        }

        public bool Contains(Passenger passenger)
        {
            return this.passengers.Contains(passenger);
        }

        public bool Contains(Bus bus)
        {
            return this.buses.Contains(bus);
        }

        public IEnumerable<Bus> GetBuses()
        {
            return this.buses;
        }

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!this.passengers.Contains(passenger) || !this.buses.Contains(bus))
            {
                throw new ArgumentException();
            }

            this.passengersByBus[bus].Add(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!this.passengers.Contains(passenger) || 
                !this.buses.Contains(bus) || 
                !this.passengersByBus[bus].Contains(passenger))
            {
                throw new ArgumentException();
            }

            this.passengersByBus[bus].Remove(passenger);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
        {
            return this.passengersByBus[bus];
        }

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
        {
            return this.buses
                .OrderBy(b => this.passengersByBus[b].Count);
        }

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
        {
            return this.buses
                .Where(b => b.Capacity >= capacity);
        }
    }
}