using System.Collections.Generic;

namespace FlightBooking.Core.BusinessRules
{
    public interface IFlightBusinessRule
    {
        bool Pass(FlightRoute flightRoute, Plane allocatedAircraft, List<Passenger> passengers);
    }
}
