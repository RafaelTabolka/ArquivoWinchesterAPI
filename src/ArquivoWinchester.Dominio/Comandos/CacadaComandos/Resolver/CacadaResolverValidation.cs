using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Resolver
{
    internal class CacadaResolverValidation : AbstractValidator<CacadaResolverRequest>
    {
        public CacadaResolverValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
