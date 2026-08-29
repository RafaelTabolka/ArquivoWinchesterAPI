using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Reabrir
{
    internal class CacadaReabrirHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaReabrirRequest, CacadaReabrirResponse>
    {
        public async Task<CacadaReabrirResponse> Handle(
            CacadaReabrirRequest request, CancellationToken cancellationToken)
        {
            var cacada = await repositorioCacada.ObterPorIdAsync(request.Id);

            if (cacada == null)
                throw new Exception("Caçada não encontrada");

            cacada.Reabrir();

            repositorioCacada.Atualizar(cacada);
            await repositorioCacada.CommitAsync();

            return new CacadaReabrirResponse("Caçada reaberta com sucesso");
        }
    }
}
