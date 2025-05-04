using MediatR;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace ModeloDeConsumoApplication.Queries
{
    public class ObterFilmesListaQueryHandler(HttpClient httpClient, IConfiguration configuration) : IRequestHandler<ObterFilmesListaQuery, string>
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string tmdbToken = configuration["TMDb:BearerToken"]!;
        private readonly string uriConfig = configuration["UriConfiguration"]!;

        public async Task<string> Handle(ObterFilmesListaQuery _, CancellationToken cancellationToken)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriConfig);

            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tmdbToken);

            var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return "Erro ao acessar a API TMDb";

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            return content ?? "Sem retorno";
        }
    }
}
