using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Deletar
{
    public class SerSobrenaturalDeletarRequest(Guid id) : IRequest<SerSobrenaturalDeletarResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
