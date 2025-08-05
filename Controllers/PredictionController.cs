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

        [HttpPost]
        public async Task<IActionResult> Predict([FromBody] double[] features)
        {
            var result = await _mlService.GetPredictionAsync(features);
            return Ok(new { prediction = result });
        }
    }
}