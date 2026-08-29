using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Ativar
{
    public class SerSobrenaturalAtivarRequest(Guid id) : IRequest<SerSobrenaturalAtivarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
