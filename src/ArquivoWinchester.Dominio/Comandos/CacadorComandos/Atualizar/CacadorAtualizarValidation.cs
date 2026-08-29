using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Atualizar
{
    internal class CacadorAtualizarValidation : AbstractValidator<CacadorAtualizarRequest>
    {
        public CacadorAtualizarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio");

            RuleFor(c => c.NomeCacador)
                .NotEmpty().WithMessage("Nome do caçador não pode ser vazio")
                .MaximumLength(50).WithMessage("Nome do Caçador deve ter no máximo 50 caracteres");

            RuleFor(c => c.RegiaoBaseCacador)
                .NotEmpty().WithMessage("Região base não pode ser vazio")
                .IsInEnum().WithMessage("Valor inválido para Região Base");

            RuleFor(c => c.EspecialidadeCacador)
                .NotEmpty().WithMessage("Especialidade não pode ser vazio")
                .IsInEnum().WithMessage("Valor inválido para Especialidade");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone não pode ser vazio");

            RuleFor(c => c.Anotacoes)
                .MaximumLength(300).WithMessage("Anotações deve ter no máximo 300 caracteres");
        }
    }
}
