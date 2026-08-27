using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Obter
{
    public class CacadaObterRequest(Guid id) : IRequest<CacadaObterResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
