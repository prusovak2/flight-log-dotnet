﻿namespace FlightLogNet.Facades
{
    using System.Collections.Generic;

    using Models;
    using Operation;
    using Repositories.Interfaces;

    public class FlightFacade(
        IFlightRepository flightRepository,
        TakeoffOperation takeoffOperation,
        GetExportToCsvOperation getExportToCsvOperation,
        LandOperation landOperation)
    {
        internal IEnumerable<FlightModel> GetAirplanesInAir()
        {
            // TODO 2.5: Doplňte metodu repozitáře, která vrátí letadla ve vzduchu v listě modelů (done)
            return flightRepository.GetAirplanesInFlight();
        }

        internal byte[] GetExportToCsv()
        {
            return getExportToCsvOperation.Execute();
        }

        internal void LandFlight(FlightLandingModel landingModel)
        {
            landOperation.Execute(landingModel);
        }

        internal IEnumerable<ReportModel> GetReport()
        {
            return flightRepository.GetReport();
        }

        internal void TakeoffFlight(FlightTakeOffModel takeOffModel)
        {
            takeoffOperation.Execute(takeOffModel);
        }
    }
}
