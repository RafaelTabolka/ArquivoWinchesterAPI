using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Criar
{
    internal class CacadaCriarHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaCriarRequest, CacadaCriarResponse>
    {
        public async Task<CacadaCriarResponse> Handle(
            CacadaCriarRequest request, CancellationToken cancellationToken)
        {
            var validacao = new CacadaCriarValidation();

            var validacaoResponse = validacao.Validate(request);

            if (!validacaoResponse.IsValid)
                throw new ValidationException(validacaoResponse.Errors);

            var cacada = new Cacada(
                request.Titulo,
                request.CacadorCriadorId,
                request.DificuldadeCacada,
                request.Cidade,
                request.Uf,
                request.SerSobrenaturalId,
                request.Latitude,
                request.Longitude,
                request.DataCacada,
                request.Resumo
            );

            await repositorioCacada.AdicionarAsync(cacada);
            await repositorioCacada.CommitAsync();

            return new CacadaCriarResponse("Caçada criada com sucesso");
        }
    }
}
