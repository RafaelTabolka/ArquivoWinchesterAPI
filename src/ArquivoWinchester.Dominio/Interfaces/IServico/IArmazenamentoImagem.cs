using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Dto;

namespace ArquivoWinchester.Dominio.Interfaces.IServico
{
    public interface IArmazenamentoImagem
    {
        Task<string> ArmazenarImagemAsync(ArquivoImagemDto imagem);
        Task ExcluirImagemAsync(string imagemUrl);
    }
}
