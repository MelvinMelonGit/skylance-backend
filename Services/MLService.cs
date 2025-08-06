using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace skylance_backend.Services
{
    // MLService.cs
    public class MLService
    {
        private readonly HttpClient _httpClient;
        public MLService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<int?> GetPredictionSafeAsync(double[] features)
        {
            try
            {
                // Serialize and Deserialize code
                var requestBody = JsonSerializer.Serialize(new { features });
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var resp = await _httpClient.PostAsync("/api/predict", content);
                resp.EnsureSuccessStatusCode();

                var json = await resp.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<PredictionResult>(json);
                return result.prediction;
            }
            catch (Exception ex)
            {
                // log, swallow
                // _logger.LogWarning(ex, "ML prediction failed");
                _logger.LogWarning(ex,
                    "Prediction failed for BookingId={BookingId}. Features={Features}",
                    booking.Id,
                    string.Join(',', features));
                return null;
            }
        }

        private class PredictionResult { public int prediction { get; set; } }
    }
}