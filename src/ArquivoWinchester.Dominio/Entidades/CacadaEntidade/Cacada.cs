using ArquivoWinchester.Dominio.Entidades.Base;
using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Enumeradores.CacadaEnum;

namespace ArquivoWinchester.Dominio.Entidades.CacadaEntidade
{
    public class Cacada : EntidadeBase
    {
        public string Titulo { get; private set; } = string.Empty;
        public Guid CacadorCriadorId { get; private set; }
        public Cacador Cacador { get; set; } = null!;
        public Guid? CacadorAtualizadorId { get; private set; }
        public EnumStatusCacada StatusCacada { get; private set; }
        public EnumDificuldadeCacada DificuldadeCacada { get; private set; }
        public string Cidade { get; private set; } = string.Empty;
        public string Uf { get; private set; } = string.Empty;
        public Guid SerSobrenaturalId { get; private set; }
        public SerSobrenatural SerSobrenatural { get; private set; } = null!;
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime DataCacada { get; private set; }
        public string? Resumo { get; private set; }

        public Cacada(
            string titulo,
            Guid cacadorCriadorId,
            EnumDificuldadeCacada dificuldadeCacada,
            string cidade,
            string uf,
            Guid serSobrenaturalId,
            double latitude,
            double longitude,
            DateTime dataCacada,
            string? resumo
        )
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            CacadorCriadorId = cacadorCriadorId;
            StatusCacada = EnumStatusCacada.Aberto;
            DificuldadeCacada = dificuldadeCacada;
            Cidade = cidade;
            Uf = uf;
            SerSobrenaturalId = serSobrenaturalId;
            Latitude = latitude;
            Longitude = longitude;
            DataCacada = dataCacada;
            Resumo = resumo;
        }

        public void Atualizar(
            string titulo,
            Guid cacadorAtualizadorId,
            EnumDificuldadeCacada dificuldadeCacada,
            string cidade,
            string uf,
            Guid serSobrenaturalId,
            double latitude,
            double longitude,
            DateTime dataCacada,
            string? resumo
        )
        {
            Titulo = titulo;
            CacadorAtualizadorId = cacadorAtualizadorId;
            DificuldadeCacada = dificuldadeCacada;
            Cidade = cidade;
            Uf = uf;
            SerSobrenaturalId = serSobrenaturalId;
            Latitude = latitude;
            Longitude = longitude;
            DataCacada = dataCacada;
            Resumo = resumo;
        }

        public void Resolver()
        {
            StatusCacada = EnumStatusCacada.Resolvido;
        }

        public void Arquivar()
        {
            StatusCacada = EnumStatusCacada.Arquivado;
        }

        public void Reabrir()
        {
            StatusCacada = EnumStatusCacada.Aberto;
        }

        public void IniciarInvestigacao()
        {
            StatusCacada = EnumStatusCacada.Investigando;
        }
    }
}
