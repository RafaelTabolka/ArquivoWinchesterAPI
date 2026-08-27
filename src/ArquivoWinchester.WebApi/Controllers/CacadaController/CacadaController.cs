using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Atualizar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Criar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Listar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Obter;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Resolver;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoWinchester.WebApi.Controllers.CacadaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacadaController(ISender mediator) : ControllerBase
    {
        [HttpGet("listar")]
        public async Task<IActionResult> ListarCacadas()
        {
            var request = new CacadaListarRequest();
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCacadaPorId(
            [FromRoute] Guid id)
        {
            var request = new CacadaObterRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarCacada(CacadaCriarRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Criado", response);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarCacada(CacadaAtualizarRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Criado", response);
        }

        [HttpPatch("resolver/{id}")]
        public async Task<IActionResult> ResolverCacada(
            [FromRoute] Guid id)
        {
            var request = new CacadaResolverRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
