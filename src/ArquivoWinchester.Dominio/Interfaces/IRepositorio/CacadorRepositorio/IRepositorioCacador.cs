using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.Base;

namespace ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio
{
    public interface IRepositorioCacador : IRepositorioBase<Cacador>
    {
        Task<bool> ExisteNomeCadastrarAsync(string nome);
        Task<bool> ExiteNomeEditarAsync(Guid id, string nome);
        Task<List<Cacador>> ListarCacadoresAsync();
        Task<Cacador?> ObterCacadorPorNomeAsync(string nome);
        Task<Cacador?> ObterCacadorPorIdAsync(Guid id);
    }
}
