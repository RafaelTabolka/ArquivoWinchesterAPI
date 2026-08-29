using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Arquivar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Atualizar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Criar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Deletar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Iniciar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Listar;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Obter;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Reabrir;
using ArquivoWinchester.Dominio.Comandos.CacadaComandos.Resolver;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoWinchester.WebApi.Controllers.CacadaController
{
    [Authorize]
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

        [HttpPatch("iniciarInvestigacao/{id}")]
        public async Task<IActionResult> IniciarCacada(
            [FromRoute] Guid id)
        {
            var request = new CacadaIniciarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("resolver/{id}")]
        public async Task<IActionResult> ResolverCacada(
            [FromRoute] Guid id)
        {
            var request = new CacadaResolverRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("arquivar/{id}")]
        public async Task<IActionResult> ArquivarCacada(
            [FromRoute] Guid id)
        {
            var request = new CacadaArquivarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("reabrir/{id}")]
        public async Task<IActionResult> ReabrirCacada(
            [FromRoute] Guid id)
        {
            var request = new CacadaReabrirRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeletarCacada(
            [FromRoute] Guid id)
        {
            var request = new CacadaDeletarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
