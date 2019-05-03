using System.Collections.Generic;

namespace FlightBooking.Core.BusinessRules
{
    public class SufficientSeating : IFlightBusinessRule
    {
        public bool Pass(FlightRoute flightRoute, Plane allocatedAircraft, List<Passenger> passengers)
        {
            return allocatedAircraft.NumberOfSeats >= passengers.Count;
        }
    }
}
