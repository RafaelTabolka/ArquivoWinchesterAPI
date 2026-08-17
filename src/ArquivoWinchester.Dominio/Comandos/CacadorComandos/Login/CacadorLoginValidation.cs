using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Login
{
    internal class CacadorLoginValidation : AbstractValidator<CacadorLoginRequest>
    {
        public CacadorLoginValidation()
        {
            RuleFor(c => c.NomeCacador)
                .NotEmpty().WithMessage("Nome do caçador não pode ser vazio");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Senha não pode ser vazio");
        }
    }
}
