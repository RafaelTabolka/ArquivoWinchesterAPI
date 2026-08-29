using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.Base;

namespace ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio
{
    public interface IRepositorioSerSobrenatural : IRepositorioBase<SerSobrenatural>
    {
        Task<SerSobrenatural?> ObterSerSobrenaturalAtivoPorIdAsync(Guid id);

        Task<bool> ExisteSerSobrenaturalComCacadaAbertaOuInvestigandoAsync(Guid id);

        Task<bool> ExisteNomeSerSobrenaturalCadastrarAsync(string nomeSerSobrenatural);
        
        Task<bool> ExisteNomeSerSobrenaturalAtualizarAsync(Guid id, string nomeSerSobrenatural);

        Task<SerSobrenatural?> ObterSerSobrenaturalPorIdAsync(Guid id);
    }
}
