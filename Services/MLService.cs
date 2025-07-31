using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace skylance_backend.Services
{
    public class MLService
    {
        private readonly HttpClient _httpClient;

        public MLService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetPredictionAsync(double[] features)
        {
            var requestBody = JsonSerializer.Serialize(new { features });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5000/predict", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PredictionResult>(responseJson);

            return result.prediction;
        }

        private class PredictionResult
        {
            public int prediction { get; set; }
        }
    }
}