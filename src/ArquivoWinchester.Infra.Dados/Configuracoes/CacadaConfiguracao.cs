using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArquivoWinchester.Infra.Dados.Configuracoes
{
    internal class CacadaConfiguracao : IEntityTypeConfiguration<Cacada>
    {
        public void Configure(EntityTypeBuilder<Cacada> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CacadorCriadorId)
                .IsRequired();

            builder.Property(c => c.CacadorAtualizadorId)
                .IsRequired(false);

            builder.Property(c => c.StatusCacada)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.DificuldadeCacada)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Uf)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(c => c.SerSobrenaturalId)
                .IsRequired();

            builder.Property(c => c.Latitude)
                .IsRequired();

            builder.Property(c => c.Longitude)
                .IsRequired();

            builder.Property(c => c.DataCacada)
                .IsRequired();

            builder.Property(c => c.Resumo)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.ToTable("TB_Cacadas");
        }
    }
}
