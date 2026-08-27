using FluentValidation;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Atualizar
{
    internal class CacadaAtualizarValidation : AbstractValidator<CacadaAtualizarRequest>
    {
        public CacadaAtualizarValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O id não pode ser vazio");

            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("Título não pode ser vazio")
                .MaximumLength(100).WithMessage("Título tem no máximo 100 caracteres");

            RuleFor(c => c.CacadorAtualizadorId)
                .NotEmpty().WithMessage("O id do atualizador da entidade não pode ser vazio");

            RuleFor(c => c.DificuldadeCacada)
                .NotEmpty().WithMessage("A dificuldade da caçada não pode ser vazio")
                .IsInEnum().WithMessage("Dificuldade da caçada incorreto");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Cidade não pode ser vazio")
                .MaximumLength(50).WithMessage("Cidade tem no máximo 50 caracteres");

            RuleFor(c => c.Uf)
                .NotEmpty().WithMessage("Uf não pode ser vazio")
                .Length(2).WithMessage("Uf tem no máximo 2 caracteres");

            RuleFor(c => c.SerSobrenaturalId)
                .NotEmpty().WithMessage("O id do ser sobrenatural não pode ser vazio");

            RuleFor(c => c.Latitude)
                .NotEmpty().WithMessage("Latitude não pode ser vazio")
                .GreaterThanOrEqualTo(-90).WithMessage("Somente valores entre -90 a 90 " +
                "são permitidos para latitude.")
                .LessThanOrEqualTo(90).WithMessage("Somente valores entre -90 a 90 " +
                "são permitidos para latitude.");

            RuleFor(c => c.Longitude)
                .NotEmpty().WithMessage("Latitude não pode ser vazio")
                .GreaterThanOrEqualTo(-180).WithMessage("Somente valores entre -180 a 180 " +
                "são permitidos para longitude.")
                .LessThanOrEqualTo(180).WithMessage("Somente valores entre -180 a 180 " +
                "são permitidos para longitude.");

            RuleFor(c => c.DataCacada)
                .NotEmpty().WithMessage("Data da caçada não pode ser vazia");

            RuleFor(c => c.Resumo)
                .MaximumLength(200).WithMessage("Resumo tem no máximo 200 caracteres");
        }
    }
}
