using ArquivoWinchester.Dominio.Entidades.Base;
using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Enumeradores.SerSobrenaturalEnum;

namespace ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade
{
    public class SerSobrenatural : EntidadeBase
    {
        public string NomeEntidade { get; private set; } = string.Empty;
        public Guid CacadorCriadorId { get; private set; }
        public Cacador Cacador { get; private set; } = null!;
        public List<Cacada> Cacadas { get; private set; } = new();
        public Guid? CacadorAtualizadorId { get; private set; }
        public string Contramedida { get; private set; } = string.Empty;
        public EnumNivelRiscoSerSobrenatural NivelRiscoSerSobrenatural { get; private set; }
        public string ImagemUrl { get; private set; } = string.Empty;
        public string SinaisComuns { get; private set; } = string.Empty;
        public EnumStatusSerSobrenatural StatusSerSobrenatural { get; private set; }

        public SerSobrenatural(
            string nomeEntidade,
            Guid cacadorCriadorId,
            string contramedida,
            EnumNivelRiscoSerSobrenatural nivelRiscoSerSobrenatural,
            string imagemUrl,
            string sinaisComuns
        )
        {
            Id = Guid.NewGuid();
            NomeEntidade = nomeEntidade;
            CacadorCriadorId = cacadorCriadorId;
            Contramedida = contramedida;
            NivelRiscoSerSobrenatural = nivelRiscoSerSobrenatural;
            ImagemUrl = imagemUrl;
            SinaisComuns = sinaisComuns;
            StatusSerSobrenatural = EnumStatusSerSobrenatural.Ativo;
        }

        public void Atualizar(
            string nomeEntidade,
            Guid cacadorAtualizadorId,
            string contramedida,
            EnumNivelRiscoSerSobrenatural nivelRiscoSerSobrenatural,
            string imagemUrl,
            string sinaisComuns
        )
        {
            NomeEntidade = nomeEntidade;
            CacadorAtualizadorId = cacadorAtualizadorId;
            Contramedida = contramedida;
            NivelRiscoSerSobrenatural = nivelRiscoSerSobrenatural;
            ImagemUrl = imagemUrl;
            SinaisComuns = sinaisComuns;
        }

        public void Ativar()
        {
            StatusSerSobrenatural = EnumStatusSerSobrenatural.Ativo;
        }

        public void Desativar()
        {
            StatusSerSobrenatural = EnumStatusSerSobrenatural.Inativo;
        }
    }
}
