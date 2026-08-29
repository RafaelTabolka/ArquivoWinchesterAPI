using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Atualizar
{
    internal class SerSobrenaturalAtualizarValidation : 
        AbstractValidator<SerSobrenaturalAtualizarRequest>
    {
        public SerSobrenaturalAtualizarValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");

            RuleFor(s => s.NomeSerSobrenatural)
                .NotEmpty().WithMessage("Nome não pode ser vazio");

            RuleFor(s => s.CacadorAtualizadorId)
                .NotEmpty().WithMessage("Id do atualizador não pode ser vazio");

            RuleFor(s => s.ContraMedida)
                .NotEmpty().WithMessage("Contra Medida não pode ser vazio");

            RuleFor(s => s.NivelRisco)
                .NotEmpty().WithMessage("Nível de risco não pode ser vazio")
                .IsInEnum().WithMessage("Nível de risco inválido");

            RuleFor(s => s.SinaisComuns)
                .NotEmpty().WithMessage("Sinais comuns não pode ser vazio");
        }
    }
}
