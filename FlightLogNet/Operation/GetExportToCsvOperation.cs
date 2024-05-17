namespace FlightLogNet.Operation
{
    using System.Collections.Generic;
    using System.Text;
    using FlightLogNet.Models;
    using Repositories.Interfaces;

    public class GetExportToCsvOperation(IFlightRepository flightRepository)
    {
        private const string _header = "FlightId, TakeOffTime, LandingTime, Immatriculation, Pilot, Copilot, Task";
        public byte[] Execute()
        {
            IList<FlightModel> flights = flightRepository.GetAllFlights();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(_header);
            foreach (FlightModel flight in flights)
            {
               AppendFlight(builder, flight);
            }

            string res = builder.ToString();
            return Encoding.UTF8.GetBytes(res);
        }

        private void AppendFlight(StringBuilder builder, FlightModel flight)
        {
            builder.AppendLine($"{flight.Id}, {flight.TakeoffTime}, {flight.LandingTime}, {flight.Airplane.Immatriculation}, {flight.Pilot.FirstName} {flight.Pilot.LastName}, {flight.Copilot?.FirstName}{flight.Copilot?.LastName}, {flight.Task}");
        }
    }
}
