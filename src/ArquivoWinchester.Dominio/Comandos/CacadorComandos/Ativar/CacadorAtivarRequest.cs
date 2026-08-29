using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Ativar
{
    public class CacadorAtivarRequest(Guid id) : IRequest<CacadorAtivarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
