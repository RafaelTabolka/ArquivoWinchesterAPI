using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Enumeradores.CacadaEnum;
using ArquivoWinchester.Dominio.Enumeradores.SerSobrenaturalEnum;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using ArquivoWinchester.Infra.Dados.Contexto;
using ArquivoWinchester.Infra.Dados.Repositorio.Base;
using Microsoft.EntityFrameworkCore;

namespace ArquivoWinchester.Infra.Dados.Repositorio.SerSobrenaturalRepositorio
{
    public class RepositorioSerSobrenatural(ArquivoWinchesterContexto contexto) :
        RepositorioBase<SerSobrenatural>(contexto), IRepositorioSerSobrenatural
    {
        public async Task<bool> ExisteNomeSerSobrenaturalAtualizarAsync(Guid id, string nomeSerSobrenatural)
        {
            return await DbSet
                .AnyAsync(ser =>
                ser.Id != id && ser.NomeSerSobrenatural == nomeSerSobrenatural);
        }

        public async Task<bool> ExisteNomeSerSobrenaturalCadastrarAsync(string nomeSerSobrenatural)
        {
            return await DbSet
                .AnyAsync(ser => ser.NomeSerSobrenatural == nomeSerSobrenatural);
        }

        public async Task<bool> ExisteSerSobrenaturalComCacadaAbertaOuInvestigandoAsync(Guid id)
        {
            return await DbSet
                .AnyAsync(ser => 
                ser.Id == id &&
                ser.Cacadas.Any(cacada => 
                cacada.StatusCacada == EnumStatusCacada.Aberto ||
                cacada.StatusCacada == EnumStatusCacada.Investigando));
        }

        public async Task<SerSobrenatural?> ObterSerSobrenaturalAtivoPorIdAsync(Guid id)
        {
            return await DbSet
                .FirstOrDefaultAsync(ser => ser.Id == id && 
                ser.StatusSerSobrenatural == EnumStatusSerSobrenatural.Ativo);
        }

        public async Task<SerSobrenatural?> ObterSerSobrenaturalPorIdAsync(Guid id)
        {
            return await DbSet
                .Include(ser => ser.Cacadas)
                .FirstOrDefaultAsync(ser => ser.Id == id);
        }
    }
}
