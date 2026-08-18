using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar
{
    internal class SerSobrenaturalCriarValidation : AbstractValidator<SerSobrenaturalCriarRequest>
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

        public SerSobrenaturalCriarValidation()
        {
            RuleFor(s => s.NomeEntidade)
                .NotEmpty().WithMessage("Nome da entidade não pode ser vazio")
                .MaximumLength(100).WithMessage("Nome da entidade não pode ter mais que 100 caracteres");

            RuleFor(s => s.CacadorCriadorId)
                .NotEmpty().WithMessage("Id do caçador não pode ser vazio");

            RuleFor(s => s.ContraMedida)
                .NotEmpty().WithMessage("Contra mediade não pode ser vazio")
                .MaximumLength(300).WithMessage("Contra mediade não pode ter mais que 300 caracteres");

            RuleFor(s => s.NivelRisco)
                .NotEmpty().WithMessage("Nível de risco não pode ser vazio")
                .IsInEnum().WithMessage("Nível de risco informado é inválido");

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

            RuleFor(s => s.SinaisComuns)
                .NotEmpty().WithMessage("Sinais comuns não pode ser vazio")
                .MaximumLength(300).WithMessage("Sinais comuns deve ter 300 caracteres no máximo");

            RuleFor(s => s.StatusSerSobrenatural)
                .NotEmpty().WithMessage("Status da entidade não pode ser vazio")
                .IsInEnum().WithMessage("Status informado é inválido");
        }
    }
}
