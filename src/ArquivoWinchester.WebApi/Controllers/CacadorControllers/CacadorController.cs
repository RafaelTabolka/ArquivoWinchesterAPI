using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Criar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoWinchester.WebApi.Controllers.CacadorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacadorController(ISender mediator) : ControllerBase
    {
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarCacador(CacadorCriarRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Criado", response);
        }
    }
}
