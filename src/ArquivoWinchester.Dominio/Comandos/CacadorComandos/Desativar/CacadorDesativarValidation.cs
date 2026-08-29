using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Desativar
{
    internal class CacadorDesativarValidation : AbstractValidator<CacadorDesativarRequest>
    {
        public CacadorDesativarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
