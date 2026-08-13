using ArquivoWinchester.Dominio.Entidades.Base;

namespace ArquivoWinchester.Dominio.Interfaces.IRepositorio.Base
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task AdicionarAsync(TEntity entidade);
        Task Deletar(Guid id);
        void Atualizar(TEntity entidade);
        Task CommitAsync();
    }
}
