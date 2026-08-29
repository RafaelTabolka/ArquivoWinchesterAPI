using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Ativar
{
    internal class CacadorAtivarValidation : AbstractValidator<CacadorAtivarRequest>
    {
        public CacadorAtivarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
