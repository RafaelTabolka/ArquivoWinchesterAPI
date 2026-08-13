using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArquivoWinchester.Infra.Dados.Configuracoes
{
    internal class CacadorConfiguracao : IEntityTypeConfiguration<Cacador>
    {
        public void Configure(EntityTypeBuilder<Cacador> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCacador)
                .IsRequired()
                .UseCollation("Latin1_General_CI_AI")
                .HasMaxLength(50);

            builder.HasIndex(c => c.NomeCacador)
                .IsUnique();

            builder.Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.RegiaoBaseCacador)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.EspecialidadeCacador)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Telefone)
                .IsRequired();

            builder.Property(c => c.Anotacoes)
                .IsRequired(false)
                .HasMaxLength(300);

            builder.Property(c => c.StatusCacador)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.ToTable("TB_Cacadores");
        }
    }
}
