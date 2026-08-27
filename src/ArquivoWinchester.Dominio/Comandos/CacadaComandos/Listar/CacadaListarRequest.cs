using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Listar
{
    public class CacadaListarRequest : IRequest<List<CacadaListarResponse>>;
}
