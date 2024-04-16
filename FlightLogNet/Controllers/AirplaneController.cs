﻿namespace FlightLogNet.Controllers
{
    using System.Collections.Generic;
    using Facades;
    using FlightLogNet.Models;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class AirplaneController(ILogger<AirplaneController> logger, AirplaneFacade airplaneFacade)
        : ControllerBase
    {
        // TODO 3.1: Vystavte REST HTTPGet metodu vracející seznam klubových letadel (done)
        // Letadla získáte voláním airplaneFacade
        // dotazované URL je /airplane
        // Odpověď by měla být kolekce AirplaneModel
        [HttpGet]
        public IEnumerable<AirplaneModel> GetClubAirplanes()
        {
            logger.LogDebug("Get club airplanes");
            return airplaneFacade.GetClubAirplanes();
        }
    }
}
