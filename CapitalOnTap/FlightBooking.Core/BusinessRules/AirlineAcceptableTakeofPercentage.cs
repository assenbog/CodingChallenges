using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.BusinessRules
{
    public class AirlineAcceptableTakeofPercentage : IFlightBusinessRule
    {
        public bool Pass(FlightRoute flightRoute, Plane allocatedAircraft, List<Passenger> passengers)
        {
            return passengers.Count(p => p.Type == PassengerType.AirlineEmployee) / (double)allocatedAircraft.NumberOfSeats > flightRoute.MinimumTakeOffPercentage;
        }
    }
}
