# ITicket

## Descrição do Projeto
O projeto ITicket é uma aplicação de gerenciamento de eventos que permite aos usuários criar, visualizar, atualizar e excluir eventos. Ele foi desenvolvido usando ASP.NET Core para o backend, Entity Framework Core para interação com o banco de dados PostgreSQL e Swagger para documentação da API.

## Estrutura do Projeto
O projeto está dividido em três partes principais:

### ITicket.API
A camada de API que lida com as solicitações HTTP e fornece uma interface para interagir com os eventos. Usa o ASP.NET Core para criar a aplicação web.

### ITicket.Application
A camada de aplicação que contém a lógica de negócios da aplicação, incluindo os serviços para manipular os eventos.

### ITicket.Infra
A camada de infraestrutura que lida com a interação com o banco de dados, incluindo os repositórios e a configuração do DbContext.

## Configuração do Projeto
Certifique-se de ajustar as configurações de conexão com o banco de dados no arquivo `appsettings.json` de acordo com suas necessidades.

### Rodando o Projeto
1. Certifique-se de ter o .NET SDK instalado.
2. Execute `dotnet restore` para restaurar as dependências.
3. Execute `dotnet build` para compilar o projeto.
4. Execute `dotnet run` para iniciar a aplicação.

## Contribuição
Sinta-se à vontade para contribuir para o projeto abrindo issues, enviando pull requests ou fornecendo feedback. Toda contribuição é bem-vinda!
