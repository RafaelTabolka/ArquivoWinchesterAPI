using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Ativar
{
    internal class SerSobrenaturalAtivarHandler(IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<SerSobrenaturalAtivarRequest, SerSobrenaturalAtivarResponse>
    {
        public async Task<SerSobrenaturalAtivarResponse> Handle(
            SerSobrenaturalAtivarRequest request, CancellationToken cancellationToken)
        {
            var serSobrenatual = await repositorioSerSobrenatural.ObterPorIdAsync(request.Id);

            if (serSobrenatual == null)
                return new SerSobrenaturalAtivarResponse("Ser sobrenatural não encontrado");

            serSobrenatual.Ativar();
            repositorioSerSobrenatural.Atualizar(serSobrenatual);
            await repositorioSerSobrenatural.CommitAsync();

            return new SerSobrenaturalAtivarResponse("Ser sobrenatural ativado com sucesso");
        }
    }
}
