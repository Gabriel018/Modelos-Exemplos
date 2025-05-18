using MediatR;
using ModeloDeConsumoApplication.Reponse;

namespace ModeloDeConsumoApplication.Queries
{
    public record ObterFilmesListaQuery : IRequest<ObterFilmesListaResponse>{ };
}
