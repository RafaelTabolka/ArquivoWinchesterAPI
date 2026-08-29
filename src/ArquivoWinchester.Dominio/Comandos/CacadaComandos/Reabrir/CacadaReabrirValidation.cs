using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Reabrir
{
    internal class CacadaReabrirValidation : AbstractValidator<CacadaReabrirRequest>
    {
        public CacadaReabrirValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
