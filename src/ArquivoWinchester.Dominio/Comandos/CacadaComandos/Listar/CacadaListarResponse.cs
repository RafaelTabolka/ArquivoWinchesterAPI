using ArquivoWinchester.Dominio.Enumeradores.CacadaEnum;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Listar
{
    internal class CacadaListarResponse(
        Guid id,
        string titutlo,
        Guid cacadorCriadorId,
        Guid? cacadorAtualizadorId,
        EnumStatusCacada statusCacada,
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
        public Guid Id { get; } = id;
        public string Titulo { get; } = titutlo;
        public Guid CacadorCriadorId { get; } = cacadorCriadorId;
        public Guid? CacadorAtualizadorId { get; } = cacadorAtualizadorId;
        public EnumStatusCacada StatusCacada { get; } = statusCacada;
        public EnumDificuldadeCacada DificuldadeCacada { get; } = dificuldadeCacada;
        public string Cidade { get; } = cidade;
        public string Uf { get; } = uf;
        public Guid SerSobrenaturalId { get; } = serSobrenaturalId;
        public double Latitude { get; } = latitude;
        public double Longitude { get; } = longitude;
        public DateTime DataCacada { get; } = dataCacada;
        public string? Resumo { get; } = resumo;
    }
}
