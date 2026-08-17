namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Login
{
    internal class CacadorLoginResponse(Guid id, string tokenDeAcesso)
    {
        public Guid Id { get; set; } = id;
        public string TokenDeAcesso { get; set; } = tokenDeAcesso;
    }
}
