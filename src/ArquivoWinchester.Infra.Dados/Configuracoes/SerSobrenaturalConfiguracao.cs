using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArquivoWinchester.Infra.Dados.Configuracoes
{
    internal class SerSobrenaturalConfiguracao : IEntityTypeConfiguration<SerSobrenatural>
    {
        public void Configure(EntityTypeBuilder<SerSobrenatural> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.NomeSerSobrenatural)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.CacadorCriadorId)
                .IsRequired();

            builder.Property(s => s.CacadorAtualizadorId)
                .IsRequired(false);

            builder.Property(s => s.Contramedida)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(s => s.NivelRiscoSerSobrenatural)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(s => s.ImagemUrl)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(s => s.SinaisComuns)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(s => s.StatusSerSobrenatural)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.HasOne(c => c.Cacador)
                .WithMany(s => s.SeresSobrenaturais)
                .HasForeignKey(c => c.CacadorCriadorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("TB_SeresSobrenaturais");
        }
    }
}
