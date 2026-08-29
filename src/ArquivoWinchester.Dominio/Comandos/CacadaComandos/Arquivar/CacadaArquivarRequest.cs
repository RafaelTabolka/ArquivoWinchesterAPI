using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Arquivar
{
    public class CacadaArquivarRequest(Guid id) : IRequest<CacadaArquivarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
