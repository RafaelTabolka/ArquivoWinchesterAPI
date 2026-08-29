using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IServico;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar
{
    internal class SerSobrenaturalCriarHandler(
        IRepositorioSerSobrenatural repositorioSerSobrenatural,
        IArmazenamentoImagem armazenamentoImagem) :
        IRequestHandler<SerSobrenaturalCriarRequest, SerSobrenaturalCriarResponse>
    {
        public async Task<SerSobrenaturalCriarResponse> Handle(
            SerSobrenaturalCriarRequest request, CancellationToken cancellationToken)
        {
            var existeNome = await repositorioSerSobrenatural.ExisteNomeSerSobrenaturalCadastrarAsync(request.NomeSerSobrenatural);

            if (existeNome)
                return new SerSobrenaturalCriarResponse("Nome do ser sobrenatural já em uso");

            var imagemUrl = await armazenamentoImagem.ArmazenarImagemAsync(request.Imagem);

            var serSobrenatural = new SerSobrenatural(
                request.NomeSerSobrenatural,
                request.CacadorCriadorId,
                request.ContraMedida,
                request.NivelRisco,
                imagemUrl,
                request.SinaisComuns
            );

            await repositorioSerSobrenatural.AdicionarAsync(serSobrenatural);
            await repositorioSerSobrenatural.CommitAsync();

            return new SerSobrenaturalCriarResponse("Ser sobrenatural cadastrado com sucesso");
        }
    }
}
