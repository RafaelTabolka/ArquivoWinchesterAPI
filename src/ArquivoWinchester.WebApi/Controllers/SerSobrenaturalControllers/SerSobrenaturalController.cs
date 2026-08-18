using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoWinchester.WebApi.Controllers.SerSobrenaturalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerSobrenaturalController(ISender mediator) : ControllerBase
    {
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarSerSobrenatural(SerSobrenaturalCriarRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Criado", response);
        }
    }
}
