using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Desativar
{
    internal class SerSobrenaturalDesativarValidation : AbstractValidator<SerSobrenaturalDesativarRequest>
    {
        public SerSobrenaturalDesativarValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
