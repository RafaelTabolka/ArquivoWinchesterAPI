using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Obter
{
    internal class CacadaObterValidation : AbstractValidator<CacadaObterRequest>
    {
        public CacadaObterValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
