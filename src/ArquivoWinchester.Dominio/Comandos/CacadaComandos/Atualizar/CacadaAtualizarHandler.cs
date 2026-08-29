using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Atualizar
{
    internal class CacadaAtualizarHandler(
        IRepositorioCacada repositorioCacada,
        IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<CacadaAtualizarRequest, CacadaAtualizarResponse>
    {
        public async Task<CacadaAtualizarResponse> Handle(
            CacadaAtualizarRequest request, CancellationToken cancellationToken)
        {
            //var validacao = new CacadaAtualizarValidation();

            //var validacaoResponse = validacao.Validate(request);

            //if (!validacaoResponse.IsValid)
            //    throw new ValidationException(validacaoResponse.Errors);

            var cacada = await repositorioCacada.ObterCacadaAbertaOuInvestigandoPorIdAsync(request.Id);

            if (cacada == null)
                return new CacadaAtualizarResponse("Caçada não encontrada ou " +
                    "possui status resolvido/arquivado");

            var serSobrenatural = await repositorioSerSobrenatural
                .ObterSerSobrenaturalAtivoPorIdAsync(request.SerSobrenaturalId);

            if (serSobrenatural == null)
                return new CacadaAtualizarResponse("Ser sobrenatural não encontrado ou inativo");

            cacada.Atualizar(
                request.Titulo,
                request.CacadorAtualizadorId,
                request.DificuldadeCacada,
                request.Cidade,
                request.Uf,
                serSobrenatural.Id,
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
