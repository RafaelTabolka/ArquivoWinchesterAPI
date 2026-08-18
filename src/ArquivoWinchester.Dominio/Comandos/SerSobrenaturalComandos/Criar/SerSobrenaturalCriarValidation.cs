using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar
{
    internal class SerSobrenaturalCriarValidation : AbstractValidator<SerSobrenaturalCriarRequest>
    {
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

            RuleFor(s => s.ImagemUrl)
                .NotEmpty().WithMessage("Imagem não pode ser vazia")
                .MaximumLength(300).WithMessage("Limite de caracteres excedido");

            RuleFor(s => s.SinaisComuns)
                .NotEmpty().WithMessage("Sinais comuns não pode ser vazio")
                .MaximumLength(300).WithMessage("Sinais comuns deve ter 300 caracteres no máximo");

            RuleFor(s => s.StatusSerSobrenatural)
                .NotEmpty().WithMessage("Status da entidade não pode ser vazio")
                .IsInEnum().WithMessage("Status informado é inválido");
        }
    }
}
