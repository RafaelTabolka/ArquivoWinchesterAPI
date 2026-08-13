using ArquivoWinchester.Dominio.Enumeradores.CacadorEnum;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Criar
{
    public class CacadorCriarRequest : IRequest<CacadorCriarResponse>
    {
        public string NomeCacador { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmaSenha { get; set; } = string.Empty;
        public EnumRegiaoBaseCacador RegiaoBaseCacador { get; set; }
        public EnumEspecialidadeCacador EspecialidadeCacador { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string? Anotacoes { get; set; }
    }
}
