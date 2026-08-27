using ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Criar;
using ArquivoWinchester.Dominio.Enumeradores.SerSobrenaturalEnum;

namespace ArquivoWinchester.Dominio.Comandos.SerSobrenaturalComandos.Listar
{
    internal class SerSobrenaturalListarResponse(
        Guid id,
        string nomeEntidade,
        Guid cacadorCriadorId,
        Guid? cacadorAtualizadorId,
        string contraMedida,
        EnumNivelRiscoSerSobrenatural nivelRisco,
        string imagemUrl,
        string sinaisComuns,
        EnumStatusSerSobrenatural statusSerSobrenatural
    )
    {
        public Guid Id { get; } = id;
        public string NomeEntidade { get; set; } = nomeEntidade;
        public Guid CacadorCriadorId { get; set; } = cacadorCriadorId;
        public Guid? CacadorAtualizadorId { get; } = cacadorAtualizadorId;
        public string ContraMedida { get; set; } = contraMedida;
        public EnumNivelRiscoSerSobrenatural NivelRisco { get; set; } = nivelRisco;
        public string ImagemUrl { get; set; } = imagemUrl;
        public string SinaisComuns { get; set; } = sinaisComuns;
        public EnumStatusSerSobrenatural StatusSerSobrenatural { get; set; } = statusSerSobrenatural;
    }
}
