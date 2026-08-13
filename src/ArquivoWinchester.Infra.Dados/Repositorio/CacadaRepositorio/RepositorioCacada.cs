using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using ArquivoWinchester.Infra.Dados.Contexto;
using ArquivoWinchester.Infra.Dados.Repositorio.Base;

namespace ArquivoWinchester.Infra.Dados.Repositorio.CacadaRepositorio
{
    public class RepositorioCacada(ArquivoWinchesterContexto contexto) :
        RepositorioBase<Cacada>(contexto), IRepositorioCacada;
}
