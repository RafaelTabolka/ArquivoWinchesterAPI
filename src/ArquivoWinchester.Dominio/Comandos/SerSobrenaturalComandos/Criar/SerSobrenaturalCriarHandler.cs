using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar
{
    internal class SerSobrenaturalCriarHandler(
        IRepositorioSerSobrenatural repositorioSerSobrenatural) :
        IRequestHandler<SerSobrenaturalCriarRequest, SerSobrenaturalCriarResponse>
    {
        public async Task<SerSobrenaturalCriarResponse> Handle(
            SerSobrenaturalCriarRequest request, CancellationToken cancellationToken)
        {
            var validacao = new SerSobrenaturalCriarValidation();

            var validacaoResponse = validacao.Validate(request);

            if (!validacaoResponse.IsValid)
                throw new ValidationException(validacaoResponse.Errors);

            //var serSobrenatural = new SerSobrenatural(
            //    request.NomeEntidade,
            //    request.CacadorCriadorId,
            //    request.ContraMedida,
            //    request.NivelRisco,
            //    request.Imagem,
            //    request.SinaisComuns
            //);

            //await repositorioSerSobrenatural.AdicionarAsync(serSobrenatural);
            await repositorioSerSobrenatural.CommitAsync();

            return new SerSobrenaturalCriarResponse("Ser sobrenatural cadastrado com sucesso");
        }
    }
}
