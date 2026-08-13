using ArquivoWinchester.Dominio.Entidades.CacadorEntidade;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadaRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.CacadorRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IRepositorio.SerSobrenaturalRepositorio;
using ArquivoWinchester.Dominio.Interfaces.IServico;
using ArquivoWinchester.Infra.CrossCutting.Extensoes.Seguranca;
using ArquivoWinchester.Infra.Dados.Contexto;
using ArquivoWinchester.Infra.Dados.Repositorio.CacadaRepositorio;
using ArquivoWinchester.Infra.Dados.Repositorio.CacadorRepositorio;
using ArquivoWinchester.Infra.Dados.Repositorio.SerSobrenaturalRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Obtém a chave utilizada para validar a assinatura do token.
// Em desenvolvimento, seu valor vem dos Segredos do Usuário.
var chaveJwt =
    builder.Configuration["Jwt:Chave"]
    ?? throw new InvalidOperationException(
        "A chave JWT não foi configurada."); //aluno

// Obtém o emissor esperado pela API.
var emissorJwt =
    builder.Configuration["Jwt:Emissor"]
    ?? throw new InvalidOperationException(
        "O emissor JWT não foi configurado."); //aluno

// Obtém a audiência esperada pela API.
var audienciaJwt =
    builder.Configuration["Jwt:Audiencia"]
    ?? throw new InvalidOperationException(
        "A audiência JWT não foi configurada."); //aluno

var config = builder.Configuration; //aluno
builder.Services //aluno
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                // Valida quem gerou o token.
                ValidateIssuer = true,

                // Valida para qual aplicação o token foi criado.
                ValidateAudience = true,

                // Valida se o token ainda não expirou.
                ValidateLifetime = true,

                // Valida a assinatura utilizando a chave configurada.
                ValidateIssuerSigningKey = true,

                // Emissor esperado.
                ValidIssuer = emissorJwt,

                // Audiência esperada.
                ValidAudience = audienciaJwt,

                // Chave utilizada para validar a assinatura.
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            chaveJwt!)
                    ),

                // Informa ao ASP.NET Core que a declaração
                // "papel" representa o papel do usuário.
                RoleClaimType = "papel"
            };
    }); //aluno

builder.Services.AddAuthorization();

//Adiciona suporte para lidar com referências circulares
builder.Services.AddControllers().AddJsonOptions(options => //aluno
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ArquivoWinchesterContexto>(opcoes =>
{
    opcoes.UseSqlServer(builder.Configuration.GetConnectionString("DoCondadoAMordorConnection"))
    .EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IRepositorioCacada, RepositorioCacada>();
builder.Services.AddScoped<IRepositorioCacador, RepositorioCacador>();
builder.Services.AddScoped<IRepositorioSerSobrenatural, RepositorioSerSobrenatural>();

builder.Services.AddScoped<IPasswordHasher<Cacador>, PasswordHasher<Cacador>>();
builder.Services.AddScoped<IServicoToken, ServicoToken>(); //aluno

var assemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => //aluno
{
    // Informa ao Swagger que a API utiliza
    // autenticação HTTP do tipo Bearer com JWT.
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "Informe somente o token JWT.",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        }
    );

    // Faz o Swagger enviar o token no cabeçalho
    // Authorization das requisições.
    options.AddSecurityRequirement(document => //aluno
        new OpenApiSecurityRequirement
        {
            [
                new OpenApiSecuritySchemeReference(
                    "Bearer",
                    document
                )
            ] = []
        }
    );
});

builder.Services.AddControllers() //aluno
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

// Lê e valida o token JWT enviado na requisição.
// Quando o token é válido, cria o usuário autenticado
// e disponibiliza suas declarações, incluindo "papel".
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
