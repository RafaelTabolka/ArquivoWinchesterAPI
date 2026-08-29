using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Resolver
{
    internal class CacadaResolverHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaResolverRequest, CacadaResolverResponse>
    {
        public async Task<CacadaResolverResponse> Handle(
            CacadaResolverRequest request, CancellationToken cancellationToken)
        {
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
