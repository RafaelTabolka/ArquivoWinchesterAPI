using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Desativar
{
    public class SerSobrenaturalDesativarRequest(Guid id) : IRequest<SerSobrenaturalDesativarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
