using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Deletar
{
    public class CacadorDeletarRequest(Guid id) : IRequest<CacadorDeletarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
