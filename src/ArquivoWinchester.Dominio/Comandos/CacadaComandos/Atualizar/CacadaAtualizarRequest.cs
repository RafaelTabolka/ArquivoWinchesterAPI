using ArquivoWinchester.Dominio.Enumeradores.CacadaEnum;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadaComandos.Atualizar
{
    public class CacadaAtualizarRequest : IRequest<CacadaAtualizarResponse>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public Guid CacadorAtualizadorId { get; set; }
        public EnumDificuldadeCacada DificuldadeCacada { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public Guid SerSobrenaturalId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataCacada { get; set; }
        public string Resumo { get; set; } = string.Empty;
    }
}
