using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Listar
{
    internal class SerSobrenaturalListarHandler(
        IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<SerSobrenaturalListarRequest, List<SerSobrenaturalListarResponse>>
    {
        public async Task<List<SerSobrenaturalListarResponse>> Handle(
            SerSobrenaturalListarRequest request, CancellationToken cancellationToken)
        {
            var seresSobrenaturais = await repositorioSerSobrenatural
                .ObterTodosAsync();

            var seresSobrenaturaisResponse = seresSobrenaturais
                .Select(ser => new SerSobrenaturalListarResponse(
                    ser.Id,
                    ser.NomeSerSobrenatural,
                    ser.CacadorCriadorId,
                    ser.CacadorAtualizadorId,
                    ser.Contramedida,
                    ser.NivelRiscoSerSobrenatural,
                    ser.ImagemUrl,
                    ser.SinaisComuns,
                    ser.StatusSerSobrenatural
                )).ToList();

            return seresSobrenaturaisResponse;
        }
    }
}
