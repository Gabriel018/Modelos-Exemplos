using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ModeloDeConsumo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(HttpClient httpClient, IConfiguration configuration) : ControllerBase
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string tmdbToken = configuration["TMDb:BearerToken"]!;

        [HttpGet("trending-tv")]
        public async Task<IActionResult> GetTrendingTV()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.themoviedb.org/3/trending/tv/day")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tmdbToken);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Erro ao acessar a API TMDb");

            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}
