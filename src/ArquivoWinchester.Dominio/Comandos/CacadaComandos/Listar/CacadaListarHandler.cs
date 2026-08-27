using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Listar
{
    internal class CacadaListarHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaListarRequest, List<CacadaListarResponse>>
    {
        public async Task<List<CacadaListarResponse>> Handle(
            CacadaListarRequest request, CancellationToken cancellationToken)
        {
            var cacadas = await repositorioCacada.ObterTodosAsync();

            var cacadasResponse = cacadas
                .Select(cacada => new CacadaListarResponse(
                    cacada.Id,
                    cacada.Titulo,
                    cacada.CacadorCriadorId,
                    cacada.CacadorAtualizadorId,
                    cacada.StatusCacada,
                    cacada.DificuldadeCacada,
                    cacada.Cidade,
                    cacada.Uf,
                    cacada.SerSobrenaturalId,
                    cacada.Latitude,
                    cacada.Longitude,
                    cacada.DataCacada,
                    cacada.Resumo
                )).ToList();

            return cacadasResponse;
        }
    }
}
