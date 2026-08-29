using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Deletar
{
    internal class SerSobrenaturalDeletarValidation : AbstractValidator<SerSobrenaturalDeletarRequest>
    {
        public SerSobrenaturalDeletarValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
