using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Obter
{
    internal class CacadaObterHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaObterRequest, CacadaObterResponse>
    {
        public async Task<CacadaObterResponse> Handle(
            CacadaObterRequest request, CancellationToken cancellationToken)
        {
            var cacada = await repositorioCacada.ObterPorIdAsync(request.Id);

            if (cacada == null)
                throw new Exception("Caçada não encontrada");

            var cacadaResponse = new CacadaObterResponse(
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
            );

            return cacadaResponse;
        }
    }
}
