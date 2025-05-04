using MediatR;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace ModeloDeConsumoApplication.Queries 
{
    public class ObterFilmesListaQueryHandler(HttpClient httpClient, IConfiguration configuration) : IRequestHandler<ObterFilmesListaQuery, string>
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string tmdbToken = configuration["TMDb:BearerToken"]!;

        public async Task<string> Handle(ObterFilmesListaQuery _, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.themoviedb.org/3/trending/tv/day")
            };

            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tmdbToken);

            var response = await _httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
                return "Erro ao acessar a API TMDb";

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            return content?? "";
        }
    }
}
