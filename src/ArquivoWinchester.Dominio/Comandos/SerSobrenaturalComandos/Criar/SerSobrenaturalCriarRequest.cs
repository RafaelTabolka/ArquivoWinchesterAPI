using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Dto;
using ArquivoWinchester.Dominio.Enumeradores.SerSobrenaturalEnum;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar
{
    public class SerSobrenaturalCriarRequest : IRequest<SerSobrenaturalCriarResponse>
    {
        public string NomeEntidade { get; set; } = string.Empty;
        public Guid CacadorCriadorId { get; set; }
        public string ContraMedida { get; set; } = string.Empty;
        public EnumNivelRiscoSerSobrenatural NivelRisco { get; set; }
        internal ArquivoImagemDto Imagem { get; set; } = null!;
        public string SinaisComuns { get; set; } = string.Empty;

        public void DefinirImagem(ArquivoImagemDto imagem)
        {
            Imagem = imagem;
        }
    }
}
