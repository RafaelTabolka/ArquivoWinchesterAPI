using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Reabrir
{
    public class CacadaReabrirRequest(Guid id) : IRequest<CacadaReabrirResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
