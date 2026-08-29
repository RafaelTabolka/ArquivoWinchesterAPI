using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Desativar
{
    public class CacadorDesativarRequest(Guid id) : IRequest<CacadorDesativarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
