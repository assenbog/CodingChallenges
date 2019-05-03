using System.Collections.Generic;

namespace FlightBooking.Core.BusinessRules
{
    public class AcceptableTakeofPercentage : IFlightBusinessRule
    {
        public bool Pass(FlightRoute flightRoute, Plane allocatedAircraft, List<Passenger> passengers)
        {
            return passengers.Count / (double)allocatedAircraft.NumberOfSeats > flightRoute.MinimumTakeOffPercentage;
        }
    }
}
