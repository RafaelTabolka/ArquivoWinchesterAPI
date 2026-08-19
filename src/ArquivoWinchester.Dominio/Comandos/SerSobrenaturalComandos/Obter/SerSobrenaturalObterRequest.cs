using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Obter
{
    public class SerSobrenaturalObterRequest(Guid id) : IRequest<SerSobrenaturalObterResponse>
    {
        public Guid Id { get; } = id;
    }
}
