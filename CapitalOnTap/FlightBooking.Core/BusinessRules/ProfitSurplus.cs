using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.BusinessRules
{
    public class ProfitSurplus : IFlightBusinessRule
    {
        public bool Pass(FlightRoute flightRoute, Plane allocatedAircraft, List<Passenger> passengers)
        {
            var nonDiscountedProfitFromFlight = passengers.Where(p => p.Type == PassengerType.General
                                      || (p.Type == PassengerType.LoyaltyMember && !p.IsUsingLoyaltyPoints))
                             .Count() * flightRoute.BasePrice;
            var discountedProfitFromFlight = passengers.Where(p => p.Type == PassengerType.Discounted)
                             .Count() * flightRoute.BasePrice / 2D;
            return nonDiscountedProfitFromFlight + discountedProfitFromFlight - flightRoute.BaseCost > 0;
        }
    }
}
