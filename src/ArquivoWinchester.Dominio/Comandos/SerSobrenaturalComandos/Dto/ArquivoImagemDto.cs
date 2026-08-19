namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Dto
{
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
