using MediatR;
using Microsoft.Extensions.Configuration;
using ModeloDeConsumoApplication.Reponse;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ModeloDeConsumoApplication.Queries
{
    public class ObterFilmesListaQueryHandler(HttpClient httpClient, IConfiguration configuration) : IRequestHandler<ObterFilmesListaQuery, ObterFilmesListaResponse?>
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string tmdbToken = configuration["TMDb:BearerToken"]!;
        private readonly string uriConfig = configuration["UriConfiguration"]!;

        public async Task<ObterFilmesListaResponse?> Handle(ObterFilmesListaQuery request, CancellationToken cancellationToken)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriConfig);

            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tmdbToken);

            var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = JsonSerializer.Deserialize<ObterFilmesListaResponse>(content);

            return result;
        }
    }
}

