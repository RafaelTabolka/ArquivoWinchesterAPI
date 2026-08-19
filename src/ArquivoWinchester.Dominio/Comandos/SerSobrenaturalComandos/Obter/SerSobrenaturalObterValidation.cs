using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Obter
{
    internal class SerSobrenaturalObterValidation 
        : AbstractValidator<SerSobrenaturalObterRequest>
    {
        public SerSobrenaturalObterValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
