using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Iniciar
{
    internal class CacadaIniciarHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaIniciarRequest, CacadaIniciarResponse>
    {
        public async Task<CacadaIniciarResponse> Handle(
            CacadaIniciarRequest request, CancellationToken cancellationToken)
        {
            var cacada = await repositorioCacada.ObterPorIdAsync(request.Id);

            if (cacada == null)
                throw new Exception("Caçada não encontrada");

            cacada.Reabrir();

            repositorioCacada.Atualizar(cacada);
            await repositorioCacada.CommitAsync();

            return new CacadaIniciarResponse("Caçada está começando a ser investigada");
        }
    }
}
