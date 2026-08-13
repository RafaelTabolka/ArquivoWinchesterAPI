using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Listar
{
    public class CacadorListarRequest : IRequest<List<CacadorListarResponse>>;
}
