using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Deletar
{
    internal class CacadaDeletarHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaDeletarRequest, CacadaDeletarResponse>
    {
        public async Task<CacadaDeletarResponse> Handle(
            CacadaDeletarRequest request, CancellationToken cancellationToken)
        {
            var cacada = await repositorioCacada.ObterCacadaAbertaOuInvestigandoPorIdAsync(request.Id);

            if (cacada == null)
                return new CacadaDeletarResponse("Caçada não encontrada ou com " +
                    "status resolvido/arquivado");

            await repositorioCacada.Deletar(cacada.Id);
            await repositorioCacada.CommitAsync();

            return new CacadaDeletarResponse("Caçada excluída com sucesso");
        }
    }
}
