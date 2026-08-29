using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Deletar
{
    internal class CacadorDeletarHandler(IRepositorioCacador repositorioCacador) :
        IRequestHandler<CacadorDeletarRequest, CacadorDeletarResponse>
    {
        public async Task<CacadorDeletarResponse> Handle(
            CacadorDeletarRequest request, CancellationToken cancellationToken)
        {
            var cacador = await repositorioCacador.ObterCacadorPorIdAsync(request.Id);

            if (cacador == null)
                return new CacadorDeletarResponse("Caçador não encontrado");

            if (cacador.Cacadas.Count > 0 || cacador.SeresSobrenaturais.Count > 0)
            {
                cacador.Desativar();
                repositorioCacador.Atualizar(cacador);
                await repositorioCacador.CommitAsync();

                return new CacadorDeletarResponse("Caçador possui caçadas ou " +
                    "seres cadastrados. Caçador foi destivado");
            }

            await repositorioCacador.Deletar(cacador.Id);
            await repositorioCacador.CommitAsync();

            return new CacadorDeletarResponse("Caçador excluído com sucesso");
        }
    }
}
