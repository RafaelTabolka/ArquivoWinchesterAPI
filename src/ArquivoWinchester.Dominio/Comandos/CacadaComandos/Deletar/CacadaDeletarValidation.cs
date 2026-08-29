using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Deletar
{
    internal class CacadaDeletarValidation : AbstractValidator<CacadaDeletarRequest>
    {
        public CacadaDeletarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
