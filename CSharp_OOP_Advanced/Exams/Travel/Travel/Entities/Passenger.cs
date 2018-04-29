namespace Travel.Entities
{
    using Contracts;
    using System.Collections.Generic;

    public class Passenger : IPassenger
    {
        public Passenger(string username)
        {
            this.Username = username;
            this.Bags = new List<IBag>();
        }

        public string Username { get; }

        public IList<IBag> Bags { get; set; }
    }
}