using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Atualizar
{
    internal class SerSobrenaturalAtualizarHandler(
        IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<SerSobrenaturalAtualizarRequest, SerSobrenaturalAtualizarResponse>
    {
        public async Task<SerSobrenaturalAtualizarResponse> Handle(
            SerSobrenaturalAtualizarRequest request, CancellationToken cancellationToken)
        {
            var serSobrenatural = await repositorioSerSobrenatural
                .ObterPorIdAsync(request.Id);

            if (serSobrenatural == null)
                return new SerSobrenaturalAtualizarResponse("Ser sobrenatural não encontrado");

            serSobrenatural.Atualizar(
                request.NomeEntidade,
                request.CacadorAtualizadorId,
                request.ContraMedida,
                request.NivelRisco,
                request.SinaisComuns
            );

            repositorioSerSobrenatural.Atualizar(serSobrenatural);
            await repositorioSerSobrenatural.CommitAsync();

            return new SerSobrenaturalAtualizarResponse("Atualização realizada com sucesso");
        }
    }
}
