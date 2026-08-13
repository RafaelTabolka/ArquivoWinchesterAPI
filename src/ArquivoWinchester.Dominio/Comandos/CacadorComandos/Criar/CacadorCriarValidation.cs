using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Criar
{
    internal class CacadorCriarValidation : AbstractValidator<CacadorCriarRequest>
    {
        public CacadorCriarValidation()
        {
            RuleFor(c => c.NomeCacador)
                .NotEmpty().WithMessage("Nome do caçador não pode ser vazio")
                .MaximumLength(50).WithMessage("Nome do caçador deve ter no máximo 50 caracteres");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Senha não pode ser vazia")
                .Matches(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}")
                .WithMessage("A senha deve ter uma letra minúscula, " +
                    "uma maiúscula, um dígito, um caractere especial e no mínimo 8 caracteres")
                .Equal(c => c.ConfirmaSenha)
                .WithMessage("As duas senhas precisam ser iguais");

            RuleFor(c => c.RegiaoBaseCacador)
                .NotEmpty().WithMessage("Região base não pode ser vazia")
                .IsInEnum().WithMessage("Região inválida");

            RuleFor(c => c.EspecialidadeCacador)
                .NotEmpty().WithMessage("Especialidade não pode ser vazia")
                .IsInEnum().WithMessage("Especialidade inválida");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone não pode ser vazio");

            RuleFor(c => c.Anotacoes)
                .MaximumLength(300).WithMessage("Anotações deve ter no máximo 300 caracteres");
        }
    }
}
