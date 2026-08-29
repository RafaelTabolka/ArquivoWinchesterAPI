using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Criar
{
    internal class CacadaCriarHandler(
        IRepositorioCacada repositorioCacada,
        IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<CacadaCriarRequest, CacadaCriarResponse>
    {
        public async Task<CacadaCriarResponse> Handle(
            CacadaCriarRequest request, CancellationToken cancellationToken)
        {
            var serSobrenatural = await repositorioSerSobrenatural
                .ObterSerSobrenaturalAtivoPorIdAsync(request.SerSobrenaturalId);

            if (serSobrenatural == null)
                return new CacadaCriarResponse("Ser sobrenatural não encontrado ou inativo");

            var cacada = new Cacada(
                request.Titulo,
                request.CacadorCriadorId,
                request.DificuldadeCacada,
                request.Cidade,
                request.Uf,
                serSobrenatural.Id,
                request.Latitude,
                request.Longitude,
                request.DataCacada,
                request.Resumo
            );

            await repositorioCacada.AdicionarAsync(cacada);
            await repositorioCacada.CommitAsync();

            return new CacadaCriarResponse("Caçada criada com sucesso");
        }
    }
}
