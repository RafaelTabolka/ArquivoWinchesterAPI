using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.AtualizarImagem
{
    internal class SerSobrenaturalAtualizarImagemValidation :
        AbstractValidator<SerSobrenaturalAtualizarImagemRequest>
    {
        private const long TamanhoMaximoImagem = 5 * 1024 * 1024;

        private static readonly string[] TiposPermitidos =
        {
            "imagem/jpg",
            "imagem/jpeg",
            "imagem/png",
            "imagem/webp"
        };

        private static readonly string[] ExtensoesPermitidas =
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".webp"
        };

        public SerSobrenaturalAtualizarImagemValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");

            RuleFor(s => s.Imagem)
                .Cascade(CascadeMode.Stop)

                .NotEmpty().WithMessage("Imagem não pode ser vazia")

                .Must(imagem => imagem.Tamanho > 0)
                .WithMessage("O arquivo da imagem está vazio")

                .Must(imagem => imagem.Tamanho < TamanhoMaximoImagem)
                .WithMessage("A imagem deve possuir no máximo 5 MB")

                .Must(imagem => TiposPermitidos.Contains(
                    imagem.TipoConteudo
                )).WithMessage("O formato da imagem deve ser JPG, JPEG, PNG ou WebP")

                .Must(imagem => ExtensoesPermitidas.Contains(
                    Path.GetExtension(imagem.NomeArquivo)))
                .WithMessage("A extensão da imagem deve ser .JPG, .JPEG, .PNG ou .WebP");
        }
    }
}
