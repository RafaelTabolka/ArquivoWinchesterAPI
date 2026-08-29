# Arquivo Winchester

API REST desenvolvida em C# e ASP.NET Core para gerenciar caçadores, caçadas e seres sobrenaturais.

O projeto foi inspirado no universo da série *Sobrenatural* e no arquivo do bunker dos Homens de Letras. Foi criado para praticar desenvolvimento back-end utilizando DDD, arquitetura em camadas, CQRS, MediatR, Entity Framework Core, autenticação JWT e boas práticas de APIs REST.

## Funcionalidades

* Cadastro, consulta, edição, ativação, desativação e exclusão de caçadores;
* Autenticação de caçadores com JWT;
* Controle de acesso por autenticação e papel administrativo;
* Cadastro, consulta, edição e exclusão de caçadas;
* Controle do fluxo das caçadas pelos status aberto, investigando, resolvido e arquivado;
* Reabertura de caçadas resolvidas ou arquivadas;
* Registro da localização das caçadas por cidade, UF, latitude e longitude;
* Registro dos caçadores responsáveis pela criação e atualização das caçadas;
* Cadastro, consulta, edição, ativação, desativação e exclusão de seres sobrenaturais;
* Upload e atualização da imagem dos seres sobrenaturais;
* Registro de contramedidas, nível de risco e sinais comuns dos seres sobrenaturais;
* Preenchimento automático das datas de criação e edição;
* Documentação e testes dos endpoints pelo Swagger.

## Regras de negócio

### Caçador

* O nome do caçador deve ser único;
* Um caçador inativo não pode realizar login;
* Somente administradores podem ativar ou desativar outro caçador;
* Somente administradores podem excluir caçadores;
* Um caçador sem caçadas ou seres sobrenaturais cadastrados pode ser excluído fisicamente;
* Um caçador que possui caçadas ou seres sobrenaturais cadastrados deve ser desativado para preservar seu histórico.

### Caçada

* Uma nova caçada inicia com o status `Aberto`;
* Uma caçada somente pode ser cadastrada ou atualizada com um ser sobrenatural ativo;
* A investigação somente pode ser iniciada quando a caçada estiver aberta;
* Uma caçada somente pode ser resolvida quando estiver em investigação;
* Uma caçada somente pode ser arquivada quando estiver resolvida;
* Somente caçadas resolvidas ou arquivadas podem ser reabertas;
* Caçadas resolvidas ou arquivadas não podem ser atualizadas;
* Somente caçadas abertas ou em investigação podem ser excluídas;
* A latitude deve estar entre `-90` e `90`;
* A longitude deve estar entre `-180` e `180`.

### Ser sobrenatural

* O nome do ser sobrenatural deve ser único;
* A imagem é obrigatória no cadastro;
* A imagem deve possuir no máximo 5 MB;
* Os formatos de imagem permitidos são JPG, JPEG, PNG e WEBP;
* Um ser sobrenatural não pode ser desativado enquanto estiver associado a uma caçada aberta ou em investigação;
* Um ser sobrenatural sem caçadas pode ser excluído fisicamente;
* Um ser sobrenatural associado somente a caçadas resolvidas ou arquivadas deve ser desativado para preservar o histórico;
* Um ser sobrenatural utilizado em alguma caçada não pode ser excluído fisicamente.

## Arquitetura

A aplicação utiliza DDD, CQRS e arquitetura em camadas.

### WebApi

Responsável pelos controllers, endpoints, códigos HTTP, Swagger, autenticação, autorização e injeção de dependência.

### Domínio

Contém as entidades, enums, regras de negócio, interfaces dos repositórios, Commands, Queries, Handlers, Requests, Responses e validadores.

### Infra.Dados

Responsável pelo `DbContext`, configurações do Entity Framework Core, repositórios, migrations, relacionamentos e acesso ao SQL Server.

### Infra.CrossCutting

Contém recursos compartilhados, como geração de token JWT, armazenamento de imagens, segurança, extensões e serviços auxiliares.

## Fluxo da aplicação

Controller → MediatR → Handler → Repositório → Entity Framework Core → SQL Server

## Tecnologias utilizadas

* C#;
* ASP.NET Core Web API;
* Entity Framework Core;
* SQL Server;
* DDD;
* CQRS;
* MediatR;
* FluentValidation;
* JWT Bearer;
* Swagger/OpenAPI;
* Injeção de dependência;
* Upload e armazenamento de arquivos.

## Segurança

A autenticação é realizada com JWT.

As senhas são transformadas em hash com `IPasswordHasher<Cacador>` antes de serem armazenadas. A senha original e seu hash nunca são retornados pela API.

O papel do caçador é armazenado no token pela declaração `papel`. As rotas administrativas utilizam autorização baseada no papel `Admin`.

Somente administradores podem ativar, desativar ou excluir caçadores. As demais rotas protegidas exigem um caçador autenticado.

## Entidades principais

* `Cacador`: representa um usuário autenticado, seu papel, situação, região-base, especialidade e registros criados;
* `Cacada`: representa uma ocorrência sobrenatural, sua localização, dificuldade, situação, caçadores responsáveis e ser sobrenatural relacionado;
* `SerSobrenatural`: representa uma entidade sobrenatural, sua imagem, contramedida, nível de risco, sinais comuns e situação.

## Autor

Desenvolvido por **Rafael Tabolka** como projeto de estudo e prática de desenvolvimento back-end com C# e .NET.
