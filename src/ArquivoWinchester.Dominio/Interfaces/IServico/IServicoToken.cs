using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;

namespace ArquivoWinchester.Dominio.Interfaces.IServico
{
    public interface IServicoToken
    {
        string GerarToken(Cacador cacador);
    }
}
