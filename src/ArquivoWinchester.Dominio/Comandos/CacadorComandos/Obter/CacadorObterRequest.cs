using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Obter
{
    public class CacadorObterRequest(Guid id) : IRequest<CacadorObterResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
