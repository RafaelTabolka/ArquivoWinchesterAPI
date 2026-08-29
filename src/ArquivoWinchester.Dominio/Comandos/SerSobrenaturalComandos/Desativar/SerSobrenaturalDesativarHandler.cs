using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Desativar
{
    internal class SerSobrenaturalDesativarHandler(IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<SerSobrenaturalDesativarRequest, SerSobrenaturalDesativarResponse>
    {
        public async Task<SerSobrenaturalDesativarResponse> Handle(
            SerSobrenaturalDesativarRequest request, CancellationToken cancellationToken)
        {
            var serSobrenatual = await repositorioSerSobrenatural.ObterPorIdAsync(request.Id);

            if (serSobrenatual == null)
                return new SerSobrenaturalDesativarResponse("Ser sobrenatural não encontrado");

            serSobrenatual.Desativar();
            repositorioSerSobrenatural.Atualizar(serSobrenatual);
            await repositorioSerSobrenatural.CommitAsync();

            return new SerSobrenaturalDesativarResponse("Ser sobrenatural desativado com sucesso");
        }
    }
}
