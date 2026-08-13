using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using ArquivoWinchester.Infra.Dados.Contexto;
using ArquivoWinchester.Infra.Dados.Repositorio.Base;

namespace ArquivoWinchester.Infra.Dados.Repositorio.SerSobrenaturalRepositorio
{
    public class RepositorioSerSobrenatural(ArquivoWinchesterContexto contexto) :
        RepositorioBase<SerSobrenatural>(contexto), IRepositorioSerSobrenatural;
}
