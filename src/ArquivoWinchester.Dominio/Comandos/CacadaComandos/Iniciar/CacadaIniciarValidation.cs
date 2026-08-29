using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Iniciar
{
    internal class CacadaIniciarValidation : AbstractValidator<CacadaIniciarRequest>
    {
        public CacadaIniciarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
