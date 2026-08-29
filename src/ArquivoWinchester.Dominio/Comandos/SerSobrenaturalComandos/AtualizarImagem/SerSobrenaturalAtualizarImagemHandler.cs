using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IServico;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.AtualizarImagem
{
    internal class SerSobrenaturalAtualizarImagemHandler(
        IRepositorioSerSobrenatural repositorioSerSobrenatural,
        IArmazenamentoImagem armazenamentoImagem) :
        IRequestHandler<SerSobrenaturalAtualizarImagemRequest, 
            SerSobrenaturalAtualizarImagemResponse>
    {
        public async Task<SerSobrenaturalAtualizarImagemResponse> Handle(
            SerSobrenaturalAtualizarImagemRequest request, 
            CancellationToken cancellationToken)
        {
            //var validacao = new SerSobrenaturalAtualizarImagemValidation();

            //var validacaoResponse = validacao.Validate(request);

            //if (!validacaoResponse.IsValid)
            //    throw new ValidationException(validacaoResponse.Errors);

            var serSobrenatural = await repositorioSerSobrenatural
                .ObterPorIdAsync(request.Id);

            if (serSobrenatural == null)
                return new 
                    SerSobrenaturalAtualizarImagemResponse("Ser não encontrado");

            var antigaImagemUrl = serSobrenatural.ImagemUrl;

            var imagemUrl = await armazenamentoImagem
                .ArmazenarImagemAsync(request.Imagem);

            serSobrenatural.AtualizarImagem(imagemUrl);

            repositorioSerSobrenatural.Atualizar(serSobrenatural);
            await repositorioSerSobrenatural.CommitAsync();

            await armazenamentoImagem.ExcluirImagemAsync(antigaImagemUrl);

            return new SerSobrenaturalAtualizarImagemResponse(
                "Imagem atualizada com sucesso");
        }
    }
}
