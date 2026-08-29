using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Ativar;
using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Atualizar;
using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Criar;
using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Deletar;
using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Desativar;
using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Listar;
using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Login;
using ArquivoWinchester.Dominio.Comandos.CacadorComandos.Obter;
using ArquivoWinchester.Dominio.Enumeradores.CacadorEnum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoWinchester.WebApi.Controllers.CacadorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacadorController(ISender mediator) : ControllerBase
    {
        [Authorize]
        [HttpGet("listar")]
        public async Task<IActionResult> ListarCacadores()
        {
            var request = new CacadorListarRequest();
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCacadorPorId(
            [FromRoute] Guid id)
        {
            var request = new CacadorObterRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarCacador(CacadorCriarRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Criado", response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(CacadorLoginRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Login realizado com sucesso", response);
        }

        [Authorize]
        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarCacador(CacadorAtualizarRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles= nameof(EnumPapelCacador.Admin))]
        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarCacador(
            [FromRoute] Guid id)
        {
            var request = new CacadorAtivarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = nameof(EnumPapelCacador.Admin))]
        [HttpPatch("desativar/{id}")]
        public async Task<IActionResult> DesativarCacador(
            [FromRoute] Guid id)
        {
            var request = new CacadorDesativarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = nameof(EnumPapelCacador.Admin))]
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeletarCacador(
            [FromRoute] Guid id)
        {
            var request = new CacadorDeletarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
