using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.BusinessRules
{
    public class Options
    {
        public List<Plane> GetSuitableAlternatives(List<Passenger> passengers, List<Plane> availablePlanes)
        {
            var passengerCount = passengers.Count;

            return availablePlanes.Where(p => p.NumberOfSeats >= passengerCount).ToList();
        }
    }
}
