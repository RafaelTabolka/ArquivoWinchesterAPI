using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Atualizar
{
    internal class CacadaAtualizarHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaAtualizarRequest, CacadaAtualizarResponse>
    {
        public async Task<CacadaAtualizarResponse> Handle(
            CacadaAtualizarRequest request, CancellationToken cancellationToken)
        {
            var validacao = new CacadaAtualizarValidation();

            var validacaoResponse = validacao.Validate(request);

            if (!validacaoResponse.IsValid)
                throw new ValidationException(validacaoResponse.Errors);

            var cacada = await repositorioCacada.ObterPorIdAsync(request.Id);

            if (cacada == null)
                return new CacadaAtualizarResponse("Caçada não encontrada");

            cacada.Atualizar(
                request.Titulo,
                request.CacadorAtualizadorId,
                request.DificuldadeCacada,
                request.Cidade,
                request.Uf,
                request.SerSobrenaturalId,
                request.Latitude,
                request.Longitude,
                request.DataCacada,
                request.Resumo
            );

            repositorioCacada.Atualizar(cacada);
            await repositorioCacada.CommitAsync();

            return new CacadaAtualizarResponse("Caçada atualizada com sucesso");
        }
    }
}
