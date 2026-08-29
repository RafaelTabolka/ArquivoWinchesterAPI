using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Iniciar
{
    public class CacadaIniciarRequest(Guid id) : IRequest<CacadaIniciarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
