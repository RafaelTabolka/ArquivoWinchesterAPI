using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Ativar
{
    internal class CacadorAtivarHandler(IRepositorioCacador repositorioCacador) :
        IRequestHandler<CacadorAtivarRequest, CacadorAtivarResponse>
    {
        public async Task<CacadorAtivarResponse> Handle(
            CacadorAtivarRequest request, CancellationToken cancellationToken)
        {
            var cacador = await repositorioCacador.ObterPorIdAsync(request.Id);

            if (cacador == null)
                return new CacadorAtivarResponse("Caçador não encontrado");

            cacador.Ativar();
            repositorioCacador.Atualizar(cacador);
            await repositorioCacador.CommitAsync();

            return new CacadorAtivarResponse("Caçador ativado com sucesso");
        }
    }
}
