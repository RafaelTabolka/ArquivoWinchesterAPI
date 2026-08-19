using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IServico;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

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
            var validacao = new SerSobrenaturalCriarValidation();

            var validacaoResponse = validacao.Validate(request);

            if (!validacaoResponse.IsValid)
                throw new ValidationException(validacaoResponse.Errors);

            var imagemUrl = await armazenamentoImagem.ArmazenarImagemAsync(request.Imagem);

            var serSobrenatural = new SerSobrenatural(
                request.NomeEntidade,
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
