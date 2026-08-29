using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Deletar
{
    internal class SerSobrenaturalDeletarHandler(IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<SerSobrenaturalDeletarRequest, SerSobrenaturalDeletarResponse>
    {
        public async Task<SerSobrenaturalDeletarResponse> Handle(
            SerSobrenaturalDeletarRequest request, CancellationToken cancellationToken)
        {
            var serSobrenatural = await repositorioSerSobrenatural
                .ObterSerSobrenaturalPorIdAsync(request.Id);

            if (serSobrenatural == null)
                return new SerSobrenaturalDeletarResponse("Ser sobrenatural não encontrado");

            if (serSobrenatural.Cacadas.Count > 0)
            {
                var existeSerComCacadaAbertaOuInvestigando = await repositorioSerSobrenatural
                    .ExisteSerSobrenaturalComCacadaAbertaOuInvestigandoAsync(serSobrenatural.Id);

                if (existeSerComCacadaAbertaOuInvestigando)
                    return new SerSobrenaturalDeletarResponse("Ser sobrenatural está " +
                        "atrelado a caçadas com status aberto/investigando");

                serSobrenatural.Desativar();
                repositorioSerSobrenatural.Atualizar(serSobrenatural);
                await repositorioSerSobrenatural.CommitAsync();
                
                return new SerSobrenaturalDeletarResponse("Ser sobrenatural desativado");
            }

            await repositorioSerSobrenatural.Deletar(serSobrenatural.Id);
            await repositorioSerSobrenatural.CommitAsync();

            return new SerSobrenaturalDeletarResponse("Ser sobrenatural excluído com sucesso");
        }
    }
}
