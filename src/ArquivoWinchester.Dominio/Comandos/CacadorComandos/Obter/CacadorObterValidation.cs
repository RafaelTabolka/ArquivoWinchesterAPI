using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Obter
{
    internal class CacadorObterValidation : AbstractValidator<CacadorObterRequest>
    {
        public CacadorObterValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
