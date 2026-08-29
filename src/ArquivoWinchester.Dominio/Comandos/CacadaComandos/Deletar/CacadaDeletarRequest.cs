using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Deletar
{
    public class CacadaDeletarRequest(Guid id) : IRequest<CacadaDeletarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
