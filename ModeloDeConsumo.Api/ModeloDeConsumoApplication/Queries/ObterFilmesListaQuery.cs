using MediatR;

namespace ModeloDeConsumoApplication.Queries
{
    public record ObterFilmesListaQuery : IRequest<string>{ };
}
