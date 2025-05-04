using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModeloDeConsumoApplication.Queries;

namespace ModeloDeConsumo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Retorna uma lista de filmes pouplares
    /// </summary>
    /// <returns>Lista de filmes pouplares</returns>
    public class MoviesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("trending-tv")]
        public async Task<IActionResult> GetTrendingTV()
        {
            var result = await _mediator.Send(new ObterFilmesListaQuery());

            if( result != null)
            {
                return Content(result,"Application/json");
            }

            return BadRequest();
        }
    }
}
