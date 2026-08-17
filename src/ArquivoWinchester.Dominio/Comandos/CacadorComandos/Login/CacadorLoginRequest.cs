using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Login
{
    public class CacadorLoginRequest : IRequest<CacadorLoginResponse>
    {
        public string NomeCacador { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
