using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Deletar
{
    internal class CacadorDeletarValidation : AbstractValidator<CacadorDeletarRequest>
    {
        public CacadorDeletarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
