using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ModeloDeConsumoApplication.Reponse
{
    public class ObterFilmesListaResponse
    {
        [JsonPropertyName("results")]
        public required IEnumerable<MoviesDto> Results { get; set; }

        public class MoviesDto
        {
            [JsonPropertyName("name")]
            [Display(Name = "Nome")]
            public string? Name { get; set; }

            [JsonPropertyName("original_name")]
            public string? Nome_Original { get; set; }

            [JsonPropertyName("overview")]
            public string? Visao_Geral { get; set; }

            [JsonPropertyName("origin_country")]
            public IEnumerable<string>? Pais_Origem { get; set; }
        }
    }
}
