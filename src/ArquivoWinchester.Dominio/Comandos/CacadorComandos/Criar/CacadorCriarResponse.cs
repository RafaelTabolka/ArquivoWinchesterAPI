namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Criar
{
    internal class CacadorCriarResponse(Guid id, string tokenDeAcesso)
    {
        public Guid Id { get; } = id;
        public string TokenDeAcesso { get; } = tokenDeAcesso;
    }
}
