using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar;
using ArquivoWinchester.Dominio.Interfaces.IServico;

namespace ArquivoWinchester.Infra.CrossCutting.Extensoes.ArmazenamentoImagem
{
    public sealed class ArmazenamentoImagem(
        string caminhoRaiz) : IArmazenamentoImagem
    {
        public async Task<string> ArmazenarAsync(ArquivoImagemDto imagem)
        {
            var extensao = Path
                .GetExtension(imagem.NomeArquivo)
                .ToLowerInvariant();

            var nomeGerado = $"{Guid.NewGuid()}{extensao}";

            var pastaImagem = Path.Combine(
                caminhoRaiz,
                "imagens",
                "seres-sobrenaturais"
            );

            Directory.CreateDirectory(pastaImagem);

            var caminhoCompleto = Path.Combine(
                pastaImagem,
                nomeGerado
            );

            //if (imagem.Conteudo.CanSeek)
            //    imagem.Conteudo.Position = 0;

            await using var arquivoDestino = new FileStream(
                caminhoCompleto,
                new FileStreamOptions
                {
                    Mode = FileMode.CreateNew,
                    Access = FileAccess.Write,
                    Share = FileShare.None,
                    Options = FileOptions.Asynchronous
                }
            );

            await imagem.Conteudo.CopyToAsync(arquivoDestino);

            return $"/imagens/seres-sobrenaturais/{nomeGerado}";
        }
    }
}
