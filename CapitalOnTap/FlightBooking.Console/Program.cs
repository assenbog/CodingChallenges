using System;
using System.Collections.Generic;
using FlightBooking.Core;
using FlightBooking.Core.BusinessRules;

namespace FlightBooking.Console
{
    internal class Program
    {
        private static ScheduledFlight _scheduledFlight;

        private static void Main(string[] args)
        {
            var rules = GetStandardBusinessRules(); // GetAlternateBusinessRules();

            SetupAirlineData(rules);

            string command;
            do
            {
                System.Console.WriteLine("Please enter command.");
                command = System.Console.ReadLine() ?? "";
                var enteredText = command.ToLower();
                if (enteredText.Contains("print summary"))
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine(_scheduledFlight.GetSummary());
                }
                else if (enteredText.Contains("add general"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.General,
                        Name = passengerSegments[2],
                        Age = Convert.ToInt32(passengerSegments[3])
                    });
                }
                else if (enteredText.Contains("add loyalty"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.LoyaltyMember,
                        Name = passengerSegments[2],
                        Age = Convert.ToInt32(passengerSegments[3]),
                        LoyaltyPoints = Convert.ToInt32(passengerSegments[4]),
                        IsUsingLoyaltyPoints = Convert.ToBoolean(passengerSegments[5]),
                    });
                }
                else if (enteredText.Contains("add airline"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.AirlineEmployee,
                        Name = passengerSegments[2],
                        Age = Convert.ToInt32(passengerSegments[3]),
                    });
                }
                else if (enteredText.Contains("add discounted"))
                {
                    var passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.Discounted,
                        Name = passengerSegments[2],
                        Age = Convert.ToInt32(passengerSegments[3]),
                    });
                }
                else if (enteredText.Contains("exit"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("UNKNOWN INPUT");
                    System.Console.ResetColor();
                }
            } while (command != "exit");
        }

        private static void SetupAirlineData(List<IFlightBusinessRule> flightBusinessRule)
        {
            var londonToParis = new FlightRoute("London", "Paris")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.1
            };

            var availablePlanes = new List<Plane>
            {
                new Plane { Id = 234, Name = "Bombardier Q400", NumberOfSeats = 250 },
                new Plane { Id = 345, Name = "Airbus A340", NumberOfSeats = 200 }
            };

            _scheduledFlight = new ScheduledFlight(londonToParis, flightBusinessRule, availablePlanes);

            _scheduledFlight.SetAircraftForRoute(new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 });
        }

        private static List<IFlightBusinessRule> GetStandardBusinessRules()
        {
            return new List<IFlightBusinessRule>
            {
                new ProfitSurplus(),
                new SufficientSeating(),
                new AcceptableTakeofPercentage()
            };
        }

        private static List<IFlightBusinessRule> GetAlternateBusinessRules()
        {
            return new List<IFlightBusinessRule>
            {
                new ProfitSurplus(),
                new SufficientSeating(),
                new AirlineAcceptableTakeofPercentage()
            };
        }
    }
}
