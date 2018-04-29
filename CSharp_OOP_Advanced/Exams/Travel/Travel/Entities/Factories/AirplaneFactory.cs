namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Airplanes.Contracts;
    using Contracts;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string type)
        {
            var allTypes = Assembly.GetCallingAssembly().GetTypes();

            var airplaneType = allTypes
                .Where(t => typeof(IAirplane).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == type);

            var airplane = (IAirplane)Activator.CreateInstance(airplaneType);

            return airplane;
        }
    }
}