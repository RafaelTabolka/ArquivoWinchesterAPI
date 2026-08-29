using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Desativar
{
    internal class CacadorDesativarHandler(IRepositorioCacador repositorioCacador) :
        IRequestHandler<CacadorDesativarRequest, CacadorDesativarResponse>
    {
        public async Task<CacadorDesativarResponse> Handle(
            CacadorDesativarRequest request, CancellationToken cancellationToken)
        {
            var cacador = await repositorioCacador.ObterPorIdAsync(request.Id);

            if (cacador == null)
                return new CacadorDesativarResponse("Caçador não encontrado");

            cacador.Desativar();
            repositorioCacador.Atualizar(cacador);
            await repositorioCacador.CommitAsync();

            return new CacadorDesativarResponse("Caçador desativado com sucesso");
        }
    }
}
