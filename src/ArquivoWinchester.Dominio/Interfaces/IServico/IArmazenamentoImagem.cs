using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar;

namespace ArquivoWinchester.Dominio.Interfaces.IServico
{
    public interface IArmazenamentoImagem
    {
        Task<string> ArmazenarAsync(ArquivoImagemDto imagem);
    }
}
