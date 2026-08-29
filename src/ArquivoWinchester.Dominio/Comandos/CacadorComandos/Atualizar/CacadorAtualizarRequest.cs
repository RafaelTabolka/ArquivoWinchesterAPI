using ArquivoWinchester.Dominio.Enumeradores.CacadorEnum;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Atualizar
{
    public class CacadorAtualizarRequest : IRequest<CacadorAtualizarResponse>
    {
        public Guid Id { get; set; }
        public string NomeCacador { get; set; } = string.Empty;
        public EnumRegiaoBaseCacador RegiaoBaseCacador { get; set; }
        public EnumEspecialidadeCacador EspecialidadeCacador { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string Anotacoes { get; set; } = string.Empty;
    }
}
