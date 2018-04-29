namespace Travel.Core.Controllers
{
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 0x3000;

        private IAirport airport;
        private IAirplaneFactory airplaneFactory;
        private IItemFactory itemFactory;

        public AirportController(IAirport airport)
        {
            this.airport = airport;
            this.airplaneFactory = new AirplaneFactory();
            this.itemFactory = new ItemFactory();
        }

        public string RegisterPassenger(string username)
        {
            if (this.airport.GetPassenger(username) != null)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            var passenger = new Passenger(username);

            this.airport.AddPassenger(passenger);

            return $"Registered {passenger.Username}";
        }

        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            var passenger = this.airport.GetPassenger(username);

            var items = bagItems.Select(type => this.itemFactory.CreateItem(type)).ToList();

            var bag = new Bag(passenger, items);
            passenger.Bags.Add(bag);

            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
        }

        public string RegisterTrip(string source, string destination, string planeType)
        {
            var airplane = this.airplaneFactory.CreateAirplane(planeType);

            var trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        public string CheckIn(string username, string tripId, IEnumerable<int> bagIndexes)
        {
            var passenger = this.airport.GetPassenger(username);
            var trip = this.airport.GetTrip(tripId);

            var passengerAlreadyCheckedIn = this.airport.Trips.Any(t => t.Airplane.Passengers.Contains(passenger));
            if (passengerAlreadyCheckedIn)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }
                
            var confiscatedBags = CheckInBags(passenger, bagIndexes);
            trip.Airplane.AddPassenger(passenger);

            return
                $"Checked in {passenger.Username} with {bagIndexes.Count() - confiscatedBags}/{bagIndexes.Count()} checked in bags";
        }

        private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
        {
            var bags = passenger.Bags;

            var confiscatedBagCount = 0;
            foreach (var index in bagsToCheckIn)
            {
                var currentBag = bags[index];
                bags.RemoveAt(index);

                if (ShouldConfiscate(currentBag))
                {
                    airport.AddConfiscatedBag(currentBag);
                    confiscatedBagCount++;
                }
                else
                {
                    this.airport.AddCheckedBag(currentBag);
                }
            }

            return confiscatedBagCount;
        }

        private static bool ShouldConfiscate(IBag bag)
        {
            var luggageValue = bag.Items.Sum(i => i.Value);

            var shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
            return shouldConfiscate;
        }
    }
}