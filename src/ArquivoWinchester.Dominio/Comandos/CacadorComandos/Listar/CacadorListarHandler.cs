using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using MediatR;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Listar
{
    internal class CacadorListarHandler(IRepositorioCacador repositorioCacador) :
        IRequestHandler<CacadorListarRequest, List<CacadorListarResponse>>
    {
        public async Task<List<CacadorListarResponse>> Handle(
            CacadorListarRequest request, CancellationToken cancellationToken)
        {
            var cacadores = await repositorioCacador.ListarCacadoresAsync();

            var cacadoresResponse = cacadores
                .Select(cacador => new CacadorListarResponse(
                    cacador.Id,
                    cacador.NomeCacador,
                    cacador.RegiaoBaseCacador,
                    cacador.EspecialidadeCacador,
                    cacador.Telefone,
                    cacador.Anotacoes,
                    cacador.StatusCacador,
                    cacador.Cacadas
                        .Select(cacada => new CacadaDto(
                            cacada.Id,
                            cacada.Titulo,
                            cacada.CacadorAtualizadorId,
                            cacada.StatusCacada,
                            cacada.DificuldadeCacada,
                            cacada.Cidade,
                            cacada.Uf,
                            new SerSobrenaturalDaCacadaDto(
                                cacada.SerSobrenatural.Id,
                                cacada.SerSobrenatural.NomeSerSobrenatural
                            ),
                            cacada.Latitude,
                            cacada.Longitude,
                            cacada.DataCacada,
                            cacada.Resumo
                        )).ToList(),
                    cacador.SeresSobrenaturais
                    .Select(ser => new SerSobrenaturalCadastradoDto(
                        ser.Id,
                        ser.NomeSerSobrenatural,
                        ser.CacadorAtualizadorId,
                        ser.StatusSerSobrenatural
                    )).ToList(),
                    cacador.Papel
                )).ToList();

            return cacadoresResponse;
        }
    }
}
