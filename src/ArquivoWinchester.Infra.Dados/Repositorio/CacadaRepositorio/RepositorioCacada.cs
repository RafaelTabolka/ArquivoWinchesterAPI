using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using ArquivoWinchester.Dominio.Enumeradores.CacadaEnum;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using ArquivoWinchester.Infra.Dados.Contexto;
using ArquivoWinchester.Infra.Dados.Repositorio.Base;
using Microsoft.EntityFrameworkCore;

namespace ArquivoWinchester.Infra.Dados.Repositorio.CacadaRepositorio
{
    public class RepositorioCacada(ArquivoWinchesterContexto contexto) :
        RepositorioBase<Cacada>(contexto), IRepositorioCacada
    {
        public async Task<Cacada?> ObterCacadaAbertaOuInvestigandoPorIdAsync(Guid id)
        {
            return await DbSet
                .FirstOrDefaultAsync(cacada =>
                cacada.Id == id &&
                (cacada.StatusCacada == EnumStatusCacada.Aberto ||
                cacada.StatusCacada == EnumStatusCacada.Investigando));
        }
    }
}
