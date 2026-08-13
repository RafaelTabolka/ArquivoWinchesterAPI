using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IServico;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Criar
{
    internal class CacadorCriarHandler(
        IRepositorioCacador repositorioCacador,
        IPasswordHasher<Cacador> senhaHasher,
        IServicoToken servicoToken) :
        IRequestHandler<CacadorCriarRequest, CacadorCriarResponse>
    {
        public async Task<CacadorCriarResponse> Handle(
            CacadorCriarRequest request, CancellationToken cancellationToken)
        {
            var validacao = new CacadorCriarValidation();
            var validacaoResponse = validacao.Validate(request);

            if (!validacaoResponse.IsValid)
                throw new ValidationException(validacaoResponse.Errors);

            var existeNome = await repositorioCacador.ExisteNomeCadastrarAsync(request.NomeCacador);

            if (existeNome)
                throw new Exception("Nome do caçador já está em uso");

            var cacador = new Cacador(
                request.NomeCacador,
                request.RegiaoBaseCacador,
                request.EspecialidadeCacador,
                request.Telefone,
                request.Anotacoes
            );

            var senhaHash = senhaHasher.HashPassword(
                cacador,
                request.Senha
            );

            cacador.DefineSenhaHash(senhaHash);

            var token = servicoToken.GerarToken(cacador);

            await repositorioCacador.AdicionarAsync(cacador);
            await repositorioCacador.CommitAsync();

            return new CacadorCriarResponse(cacador.Id, token);
        }
    }
}
