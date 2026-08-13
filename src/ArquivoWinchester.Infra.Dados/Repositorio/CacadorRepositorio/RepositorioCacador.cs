using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using ArquivoWinchester.Infra.Dados.Contexto;
using ArquivoWinchester.Infra.Dados.Repositorio.Base;
using Microsoft.EntityFrameworkCore;

namespace ArquivoWinchester.Infra.Dados.Repositorio.CacadorRepositorio
{
    public class RepositorioCacador(ArquivoWinchesterContexto contexto) :
        RepositorioBase<Cacador>(contexto), IRepositorioCacador
    {
        public async Task<bool> ExisteNomeCadastrarAsync(string nome)
        {
            return await DbSet.AnyAsync(cacador => cacador.NomeCacador == nome);
        }

        public async Task<bool> ExiteNomeEditarAsync(Guid id, string nome)
        {
            return await DbSet.AnyAsync(
                cacador => cacador.Id != id && cacador.NomeCacador == nome
            );
        }

        public async Task<List<Cacador>> ListarCacadoresAsync()
        {
            return await DbSet
                .Include(cacador => cacador.Cacadas)
                .Include(cacador => cacador.SeresSobrenaturais)
                .ToListAsync();
        }

        public async Task<Cacador?> ObterCacadorPorIdAsync(Guid id)
        {
            return await DbSet
                .Include(cacador => cacador.Cacadas)
                .Include(cacador => cacador.SeresSobrenaturais)
                .FirstOrDefaultAsync(cacador => cacador.Id == id);
        }
    }
}
