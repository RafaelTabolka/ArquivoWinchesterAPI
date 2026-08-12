using ArquivoWinchester.Dominio.Entidades.Base;
using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Infra.CrossCutting.Extensoes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ArquivoWinchester.Infra.Dados.Contexto
{
    public class ArquivoWinchesterContexto(DbContextOptions<ArquivoWinchesterContexto> opcoes) : DbContext(opcoes)
    {
        public DbSet<Cacada> CacadaSet { get; set; }
        public DbSet<Cacador> CacadorSet { get; set; }
        public DbSet<SerSobrenatural> SerSobrenaturalSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            DefinirInformacoesDeCriacao();
            DefinirInformacoesDeAtualizacao();
            return base.SaveChangesAsync(cancellationToken);
        }

        private IEnumerable<TEntityBase> ObterEntidadesRastreadasPorEstado<TEntityBase>(
            EntityState estadoEntidade)
        {
            return from e in ChangeTracker.Entries()
                   where e.Entity is TEntityBase && e.State == estadoEntidade
                   select (TEntityBase)e.Entity;
        }

        protected virtual void DefinirInformacoesDeCriacao()
        {
            ObterEntidadesRastreadasPorEstado<EntidadeBase>(EntityState.Added)
                .ForEach(entidade => entidade.CriadoEm = DateTime.UtcNow);
        }

        protected virtual void DefinirInformacoesDeAtualizacao()
        {
            ObterEntidadesRastreadasPorEstado<EntidadeBase>(EntityState.Modified)
                .ForEach(entidade => entidade.EditadoEm = DateTime.UtcNow);
        }



    }
}
