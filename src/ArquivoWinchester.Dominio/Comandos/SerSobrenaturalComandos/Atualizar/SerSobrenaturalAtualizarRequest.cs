using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar;
using ArquivoWinchester.Dominio.Enumeradores.SerSobrenaturalEnum;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Atualizar
{
    public class SerSobrenaturalAtualizarRequest :
        IRequest<SerSobrenaturalAtualizarResponse>
    {
        public Guid Id { get; }
        public string NomeEntidade { get; set; } = string.Empty;
        public Guid CacadorAtualizadorId { get; set; }
        public string ContraMedida { get; set; } = string.Empty;
        public EnumNivelRiscoSerSobrenatural NivelRisco { get; set; }
        public string SinaisComuns { get; set; } = string.Empty;
    }
}
