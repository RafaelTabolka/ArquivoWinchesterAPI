using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Obter
{
    internal class CacadorObterHandler(IRepositorioCacador repositorioCacador) :
        IRequestHandler<CacadorObterRequest, CacadorObterResponse>
    {
        public async Task<CacadorObterResponse> Handle(
            CacadorObterRequest request, CancellationToken cancellationToken)
        {
            //var validacao = new CacadorObterValidation();

            //var validacaoResponse = validacao.Validate(request);

            //if (!validacaoResponse.IsValid)
            //    throw new ValidationException(validacaoResponse.Errors);

            var cacador = await repositorioCacador.ObterCacadorPorIdAsync(request.Id);

            if (cacador == null)
                throw new Exception("Caçador não encontrado");

            var cacadorResponse = new CacadorObterResponse(
                cacador.Id,
                cacador.NomeCacador,
                cacador.RegiaoBaseCacador,
                cacador.EspecialidadeCacador,
                cacador.Telefone,
                cacador.Anotacoes,
                cacador.StatusCacador,
                cacador.Cacadas
                    .Select(cacada => new CacadaDto(
                        cacador.Id,
                        cacada.Titulo,
                        cacada.CacadorAtualizadorId,
                        cacada.StatusCacada,
                        cacada.DificuldadeCacada,
                        cacada.Cidade,
                        cacada.Uf,
                        new SerSobrenaturalDaCacadaDto(
                            cacada.SerSobrenatural.Id,
                            cacada.SerSobrenatural.NomeEntidade
                        ),
                        cacada.Latitude,
                        cacada.Longitude,
                        cacada.DataCacada,
                        cacada.Resumo
                    )).ToList(),
                cacador.SeresSobrenaturais
                    .Select(ser => new SerSobrenaturalCadastradoDto(
                        ser.Id,
                        ser.NomeEntidade,
                        ser.CacadorAtualizadorId,
                        ser.StatusSerSobrenatural
                    )).ToList(),
                cacador.Papel
            );

            return cacadorResponse;
        }
    }
}
