using ArquivoWinchester.Dominio.Enumeradores.CacadaEnum;
using ArquivoWinchester.Dominio.Enumeradores.CacadorEnum;
using ArquivoWinchester.Dominio.Enumeradores.SerSobrenaturalEnum;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Obter
{
    internal class CacadorObterResponse(
        Guid id,
        string nomeCacador,
        EnumRegiaoBaseCacador regiaoBaseCacador,
        EnumEspecialidadeCacador especialidadeCacador,
        string telefone,
        string? anotacoes,
        EnumStatusCacador statusCacador,
        List<CacadaDto> cacadas,
        List<SerSobrenaturalCadastradoDto> seresSobrenaturaisCadastrados,
        EnumPapelCacador papelCacador
    )
    {
        public Guid Id { get; } = id;
        public string NomeCacador { get; } = nomeCacador;
        public EnumRegiaoBaseCacador RegiaoBaseCacador { get; } = regiaoBaseCacador;
        public EnumEspecialidadeCacador EspecialidadeCacador { get; } = especialidadeCacador;
        public string Telefone { get; } = telefone;
        public string? Anotacoes { get; } = anotacoes;
        public EnumStatusCacador StatusCacador { get; } = statusCacador;
        public List<CacadaDto> Cacadas { get; } = cacadas;
        public List<SerSobrenaturalCadastradoDto> SeresSobrenaturaisCadastrados { get; } = seresSobrenaturaisCadastrados;
        public EnumPapelCacador PapelCacador { get; } = papelCacador;

    }

    internal class CacadaDto(
        Guid id,
        string titulo,
        Guid? cacadorAtualizadorId,
        EnumStatusCacada statusCacada,
        EnumDificuldadeCacada dificuldade,
        string cidade,
        string uf,
        SerSobrenaturalDaCacadaDto serSobrenaturalDto,
        double latitude,
        double longitude,
        DateTime dataCacada,
        string? resumo
    )
    {
        public Guid Id { get; } = id;
        public string Titulo { get; } = titulo;
        public Guid? CacadorAtualizadorId { get; } = cacadorAtualizadorId;
        public EnumStatusCacada StatusCacada { get; } = statusCacada;
        public EnumDificuldadeCacada Dificuldade { get; } = dificuldade;
        public string Cidade { get; } = cidade;
        public string Uf { get; } = uf;
        public SerSobrenaturalDaCacadaDto SerSobrenaturalDto { get; } = serSobrenaturalDto;
        public double Latitude { get; } = latitude;
        public double Longitude { get; } = longitude;
        public DateTime DataCacada { get; } = dataCacada;
        public string? Resumo { get; } = resumo;
    }

    internal class SerSobrenaturalDaCacadaDto(
        Guid id,
        string nome
    )
    {
        public Guid Id { get; } = id;
        public string Nome { get; } = nome;
    }

    internal class SerSobrenaturalCadastradoDto(
        Guid id,
        string nome,
        Guid? cacadorAtualizadorId,
        EnumStatusSerSobrenatural statusSerSobrenatural
    )
    {
        public Guid Id { get; } = id;
        public string Nome { get; } = nome;
        public Guid? CacadorAtualizadorId { get; } = cacadorAtualizadorId;
        public EnumStatusSerSobrenatural StatusSerSobrenatural { get; } = statusSerSobrenatural;
    }
}
