using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Ativar;
using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Atualizar;
using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.AtualizarImagem;
using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar;
using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Deletar;
using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Dto;
using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Listar;
using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Obter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoWinchester.WebApi.Controllers.SerSobrenaturalControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SerSobrenaturalController(ISender mediator) : ControllerBase
    {
        [HttpGet("listar")]
        public async Task<IActionResult> ListarSeresSobrenaturais()
        {
            var request = new SerSobrenaturalListarRequest();

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarSeresSobrenaturais(
            [FromRoute] Guid id)
        {
            var request = new SerSobrenaturalObterRequest(id);

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("cadastrar")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CadastrarSerSobrenatural(
            [FromForm] SerSobrenaturalCriarRequest request,
            IFormFile arquivoImagem)
        {
            await using var conteudo = arquivoImagem.OpenReadStream();

            request.DefinirImagem(new ArquivoImagemDto(
                conteudo,
                Path.GetFileName(arquivoImagem.FileName),
                arquivoImagem.ContentType,
                arquivoImagem.Length
            ));

            var response = await mediator.Send(request);
            return Created("Criado", response);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarSerSobrenatural(
            SerSobrenaturalAtualizarRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("atualizarImagem")]
        public async Task<IActionResult> AtualizarImagemSerSobrenatural(
            [FromForm] SerSobrenaturalAtualizarImagemRequest request,
            IFormFile arquivoImagem)
        {
            await using var conteudo = arquivoImagem.OpenReadStream();

            request.DefinirImagem(new ArquivoImagemDto(
                conteudo,
                Path.GetFileName(arquivoImagem.FileName),
                arquivoImagem.ContentType,
                arquivoImagem.Length
            ));

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarSerSobrenatural(
            [FromForm] Guid id)
        {
            var request = new SerSobrenaturalAtivarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("desativar/{id}")]
        public async Task<IActionResult> DesativarSerSobrenatural(
            [FromForm] Guid id)
        {
            var request = new SerSobrenaturalAtivarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeletarSerSobrenatural(
            [FromForm] Guid id)
        {
            var request = new SerSobrenaturalDeletarRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
