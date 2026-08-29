using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Arquivar
{
    internal class CacadaArquivarValidation : AbstractValidator<CacadaArquivarRequest>
    {
        public CacadaArquivarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");
        }
    }
}
