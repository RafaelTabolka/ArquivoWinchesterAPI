using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Listar
{
    public class SerSobrenaturalListarRequest : IRequest<List<SerSobrenaturalListarResponse>>;
}
