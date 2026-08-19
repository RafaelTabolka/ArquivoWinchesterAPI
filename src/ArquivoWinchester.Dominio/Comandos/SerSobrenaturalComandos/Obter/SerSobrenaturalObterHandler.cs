using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Obter
{
    internal class SerSobrenaturalObterHandler(
        IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<SerSobrenaturalObterRequest, SerSobrenaturalObterResponse>
    {
        public async Task<SerSobrenaturalObterResponse> Handle(
            SerSobrenaturalObterRequest request, CancellationToken cancellationToken)
        {
            var serSobrenatural = await repositorioSerSobrenatural
                .ObterPorIdAsync(request.Id);

            if (serSobrenatural == null)
                throw new Exception("Ser sobrenatual não encontrado");

            var serSobrenaturalResponse = new SerSobrenaturalObterResponse(
                serSobrenatural.Id,
                serSobrenatural.NomeEntidade,
                serSobrenatural.CacadorCriadorId,
                serSobrenatural.CacadorAtualizadorId,
                serSobrenatural.Contramedida,
                serSobrenatural.NivelRiscoSerSobrenatural,
                serSobrenatural.ImagemUrl,
                serSobrenatural.SinaisComuns,
                serSobrenatural.StatusSerSobrenatural
            );

            return serSobrenaturalResponse;
        }
    }
}
