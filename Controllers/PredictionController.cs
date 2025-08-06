using Microsoft.AspNetCore.Mvc;
using skylance_backend.Services;
using System.Threading.Tasks;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredictionController : ControllerBase
    {
        private readonly MLService _mlService;

        public PredictionController(MLService mlService)
        {
            _mlService = mlService;
        }
        // POST /api/prediction
        [HttpPost]
        public async Task<IActionResult> Predict([FromBody] double[] features)
        {
            var result = await _mlService.GetPredictionSafeAsync(features);
            if (result == null)
            {
                // we logged the failure inside MLService,
                // return a 503 so the caller knows to ignore/update later
                return StatusCode(503, new { error = "ML service temporarily unavailable" });
            }

            return Ok(new { prediction = result });
        }
    }
}