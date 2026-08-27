using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Obter
{
    internal class CacadaObterHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaObterRequest, CacadaObterResponse>
    {
        public async Task<CacadaObterResponse> Handle(
            CacadaObterRequest request, CancellationToken cancellationToken)
        {
            var validacao = new CacadaObterValidation();

            var validacaoResponse = validacao.Validate(request);

            if (!validacaoResponse.IsValid)
                throw new ValidationException(validacaoResponse.Errors);

            var cacada = await repositorioCacada.ObterPorIdAsync(request.Id);

            if (cacada == null)
                throw new Exception("Caçada não encontrada");

            var cacadaResponse = new CacadaObterResponse(
                cacada.Id,
                cacada.Titulo,
                cacada.CacadorCriadorId,
                cacada.CacadorAtualizadorId,
                cacada.StatusCacada,
                cacada.DificuldadeCacada,
                cacada.Cidade,
                cacada.Uf,
                cacada.SerSobrenaturalId,
                cacada.Latitude,
                cacada.Longitude,
                cacada.DataCacada,
                cacada.Resumo
            );

            return cacadaResponse;
        }
    }
}
