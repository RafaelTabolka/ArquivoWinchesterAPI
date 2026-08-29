using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Atualizar
{
    internal class CacadorAtualizarHandler(IRepositorioCacador repositorioCacador) :
        IRequestHandler<CacadorAtualizarRequest, CacadorAtualizarResponse>
    {
        public async Task<CacadorAtualizarResponse> Handle(
            CacadorAtualizarRequest request, CancellationToken cancellationToken)
        {
            var cacador = await repositorioCacador.ObterPorIdAsync(request.Id);

            if (cacador == null)
                return new CacadorAtualizarResponse("Caçador não encontrado");

            var existeNome = await repositorioCacador.ExisteNomeEditarAsync(request.Id, request.NomeCacador);

            if (existeNome)
                return new CacadorAtualizarResponse("Nome do caçador já em uso");

            cacador.Atualizar(
                request.NomeCacador,
                request.RegiaoBaseCacador,
                request.EspecialidadeCacador,
                request.Telefone,
                request.Anotacoes
            );

            repositorioCacador.Atualizar(cacador);
            await repositorioCacador.CommitAsync();

            return new CacadorAtualizarResponse("Caçador atualizado com sucesso");
        }
    }
}
