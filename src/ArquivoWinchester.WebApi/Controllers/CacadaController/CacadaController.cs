using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Criar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoWinchester.WebApi.Controllers.CacadaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacadaController(ISender mediator) : ControllerBase
    {
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarCacada(CacadaCriarRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Criado", response);
        }
    }
}
