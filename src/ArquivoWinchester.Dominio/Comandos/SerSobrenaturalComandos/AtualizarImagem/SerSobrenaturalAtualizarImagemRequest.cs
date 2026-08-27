using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Dto;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.AtualizarImagem
{
    public class SerSobrenaturalAtualizarImagemRequest :
        IRequest<SerSobrenaturalAtualizarImagemResponse>
    {
        public Guid Id { get; set; }
        internal ArquivoImagemDto Imagem { get; set; } = null!;

        public void DefinirImagem(ArquivoImagemDto imagem)
        {
            Imagem = imagem;
        }
    }
}
