using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Ativar
{
    internal class SerSobrenaturalAtivarValidation : AbstractValidator<SerSobrenaturalAtivarRequest>
    {
        public SerSobrenaturalAtivarValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
