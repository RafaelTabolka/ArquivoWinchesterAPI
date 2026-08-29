using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Resolver
{
    internal class CacadaResolverHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaResolverRequest, CacadaResolverResponse>
    {
        public async Task<CacadaResolverResponse> Handle(
            CacadaResolverRequest request, CancellationToken cancellationToken)
        {
            //var validacao = new CacadaResolverValidation();

            //var validacaoResponse = validacao.Validate(request);

            //if (!validacaoResponse.IsValid)
            //    throw new ValidationException(validacaoResponse.Errors);

            var cacada = await repositorioCacada.ObterPorIdAsync(request.Id);

            if (cacada == null)
                throw new Exception("Caçada não encontrada");

            cacada.Resolver();

            repositorioCacada.Atualizar(cacada);
            await repositorioCacada.CommitAsync();

            return new CacadaResolverResponse("Caçada resolvida");
        }
    }
}
