using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Arquivar
{
    internal class CacadaArquivarHandler(IRepositorioCacada repositorioCacada) :
        IRequestHandler<CacadaArquivarRequest, CacadaArquivarResponse>
    {
        public async Task<CacadaArquivarResponse> Handle(
            CacadaArquivarRequest request, CancellationToken cancellationToken)
        {
            var cacada = await repositorioCacada.ObterPorIdAsync(request.Id);

            if (cacada == null)
                throw new Exception("Caçada não encontrada");

            cacada.Arquivar();

            repositorioCacada.Atualizar(cacada);
            await repositorioCacada.CommitAsync();

            return new CacadaArquivarResponse("Caçada arquivada com sucesso");
        }
    }
}
