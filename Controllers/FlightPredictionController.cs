using Microsoft.AspNetCore.Mvc;
using skylance_backend.Services;
using System;
using System.Threading.Tasks;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightPredictionController : ControllerBase
    {
        private readonly MLService _mlService;

        public FlightPredictionController(MLService mlService)
        {
            _mlService = mlService;
        }


        /// Triggers the Python service to predict for all un‐predicted flights.
        /// Python handles feature extraction, inference, and write‐back.

        /// <returns>{ "updated": int }</returns>
        [HttpPost("all")]
        public async Task<IActionResult> PredictFlights()
        {
            var result = await _mlService.CallBulkAsync();
            return Ok(new { updated = result.updated });
        }

        /// Triggers the Python service to predict for a single flight by ID.

        /// <param name="id">Flight ID</param>
        /// <returns>{ "flightId": int, "probability": float }</returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> PredictFlight(int id)
        {
            var result = await _mlService.CallSingleFlightAsync(id);
            return Ok(new
            {
                flightId = id,
                probability = result.probability
            });
        }
    }
}