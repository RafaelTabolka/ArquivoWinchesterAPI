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
        }
    }
}
