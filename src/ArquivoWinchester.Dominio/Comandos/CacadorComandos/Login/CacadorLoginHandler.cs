using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IServico;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ValidationException = FluentValidation.ValidationException;

namespace ArquivoWinchester.Dominio.Comandos.CacadorComandos.Login
{
    internal class CacadorLoginHandler(
        IRepositorioCacador repositorioCacador,
        IPasswordHasher<Cacador> senhaHasher,
        IServicoToken servicoToken
    ) : IRequestHandler<CacadorLoginRequest, CacadorLoginResponse>

    {
        public async Task<CacadorLoginResponse> Handle(
            CacadorLoginRequest request, CancellationToken cancellationToken)
        {
            var validacao = new CacadorLoginValidation();

            var validacaoResponse = validacao.Validate(request);

            if (!validacaoResponse.IsValid)
                throw new ValidationException(validacaoResponse.Errors);

            var cacador = await repositorioCacador
                .ObterCacadorPorNomeAsync(request.NomeCacador);

            if (cacador == null)
                throw new UnauthorizedAccessException("Usuário ou senha incorretos");

            var resultadoSenha = senhaHasher.VerifyHashedPassword(
                cacador,
                cacador.Senha,
                request.Senha
            );

            if (resultadoSenha == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Usuário ou senha incorretos");

            var token = servicoToken.GerarToken(cacador);

            return new CacadorLoginResponse(cacador.Id, token);
        }
    }
}
