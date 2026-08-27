using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Resolver
{
    public class CacadaResolverRequest(Guid id) : IRequest<CacadaResolverResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
