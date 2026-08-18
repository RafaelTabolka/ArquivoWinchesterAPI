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
        public ArquivoImagemDto Imagem { get; set; } = null!;
        public string SinaisComuns { get; set; } = string.Empty;
        public EnumStatusSerSobrenatural StatusSerSobrenatural { get; set; }
    }

    public class ArquivoImagemDto(
        Stream conteudo,
        string nomeArquivo,
        string tipoConteudo,
        long tamanho
    )
    {
        public Stream Conteudo { get; } = conteudo;
        public string NomeArquivo { get; } = nomeArquivo;
        public string TipoConteudo { get; } = tipoConteudo;
        public long Tamanho { get; } = tamanho;
    }
}
