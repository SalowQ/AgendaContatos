# AgendaContatos

API REST para gerenciamento de contatos desenvolvida em .NET 8 com clean architecture.

## 🌐 Frontend

Este projeto possui um frontend complementar desenvolvido em Vue.js:

- **Repositório**: [AgendaContatosFront](https://github.com/SalowQ/AgendaContatosFront)
- **Deploy**: [agenda-contatos-front.vercel.app](https://agenda-contatos-front.vercel.app/)

### ⚠️ Configuração do Frontend

O frontend está configurado para apontar para a API local (`https://localhost:7289`). Para usar o frontend em produção com o backend local:

1. **Execute o backend localmente** (seguindo os passos abaixo)
2. **Acesse o frontend**: [agenda-contatos-front.vercel.app](https://agenda-contatos-front.vercel.app/)

> **Nota**: O backend não está configurado para deploy, então o frontend em produção só funcionará com o backend rodando localmente.

## 📋 Descrição

Sistema de agenda de contatos que permite realizar operações CRUD (Create, Read, Update, Delete) em contatos através de uma API REST.

## 🏗️ Arquitetura

O projeto segue os princípios da clean architecture, organizado em camadas bem definidas:

### Estrutura de Projetos

#### 📁 `src/` - Código Fonte

- **`AgendaContatos.Api`** - Camada de apresentação (Controllers, Middleware, Filters)
- **`AgendaContatos.Application`** - Camada de aplicação (Use Cases, Validators, AutoMapper)
- **`AgendaContatos.Domain`** - Camada de domínio (Entities, Interfaces)
- **`AgendaContatos.Infrastructure`** - Camada de infraestrutura (DbContext, Repositories)
- **`AgendaContatos.Communication`** - DTOs de Request/Response
- **`AgendaContatos.Exception`** - Tratamento de exceções customizadas

#### 📁 `tests/` - Testes

- **`Validators.Tests`** - Testes unitários dos validadores
- **`CommonTestUtilities`** - Utilitários para testes (Builders, Fakers)

## 🚀 Funcionalidades

### Endpoints da API

| Método   | Endpoint             | Descrição                |
| -------- | -------------------- | ------------------------ |
| `POST`   | `/api/contacts`      | Criar novo contato       |
| `GET`    | `/api/contacts`      | Listar todos os contatos |
| `GET`    | `/api/contacts/{id}` | Buscar contato por ID    |
| `PUT`    | `/api/contacts/{id}` | Atualizar contato        |
| `DELETE` | `/api/contacts/{id}` | Excluir contato          |

### Modelo de Dados

```csharp
public class Contact
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
```

## 🛠️ Tecnologias Utilizadas

### Frameworks e Bibliotecas

- **.NET 8** - Framework principal
- **ASP.NET Core** - Framework web
- **Entity Framework Core 8.0.18** - ORM para acesso a dados
- **Pomelo.EntityFrameworkCore.MySql 8.0.3** - Provider MySQL
- **AutoMapper 15.0.1** - Mapeamento de objetos
- **FluentValidation 12.0.0** - Validação de dados
- **Swashbuckle.AspNetCore 6.6.2** - Documentação Swagger

### Testes

- **xUnit 2.5.3** - Framework de testes
- **Shouldly 4.3.0** - Assertions mais legíveis
- **Bogus 35.6.3** - Geração de dados fake para testes

### Entity Framework Core

- **DbContext**: `AgendaContatosDbContext` configurado para MySQL
- **Migrations**: Sistema de versionamento do banco de dados
- **Repository Pattern**: Implementado com interfaces segregadas
- **Unit of Work**: Gerenciamento de transações

## 🏛️ Padrões Arquiteturais

### Clean Architecture

- **Separação de responsabilidades** entre camadas
- **Inversão de dependência** através de interfaces
- **Independência de frameworks** externos

### Design Patterns

- **Repository Pattern** - Abstração do acesso a dados
- **Unit of Work** - Gerenciamento de transações
- **Use Case Pattern** - Organização da lógica de negócio
- **DTO Pattern** - Transferência de dados entre camadas

## 🔧 Configuração

### Pré-requisitos

- .NET 8 SDK
- MySQL Server 8.0+
- Visual Studio 2022 ou VS Code

### Banco de Dados

O projeto utiliza **Entity Framework Core** com **MySQL** como banco de dados.

#### Configuração da Conexão

Adicione a string de conexão no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Connection": "Server=localhost;Database=AgendaContatos;Uid=root;Pwd=sua_senha;"
  }
}
```

#### Configuração do DbContext

O `AgendaContatosDbContext` está configurado no projeto `Infrastructure`:

```csharp
services.AddDbContext<AgendaContatosDbContext>(config =>
    config.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11))));
```

### Executando o Projeto

1. **Clone o repositório**

   ```bash
   git clone [url-do-repositorio]
   cd AgendaContatos
   ```

2. **Configure a conexão com o banco**

   - Edite `appsettings.json` com sua string de conexão MySQL

3. **Instale as ferramentas do Entity Framework (se necessário)**

   ```bash
   dotnet tool install --global dotnet-ef
   ```

4. **Execute as migrações**

   ```bash
   dotnet ef database update --project src/AgendaContatos.Infrastructure
   ```

5. **Execute a aplicação**

   ```bash
   dotnet run --project src/AgendaContatos.Api
   ```

6. **Acesse a documentação**
   - Swagger UI: `https://localhost:7289/swagger`

### 🚀 Usando com o Frontend

Para usar a aplicação completa com frontend e backend:

1. **Backend local**: Execute os passos acima para rodar a API
2. **Frontend em produção**: Acesse [agenda-contatos-front.vercel.app](https://agenda-contatos-front.vercel.app/)
3. **Desenvolvimento local**: Clone o [repositório do frontend](https://github.com/SalowQ/AgendaContatosFront) e execute `npm run dev`

> **💡 Dica**: O frontend em produção já está configurado para apontar para `https://localhost:7289`, então funcionará automaticamente com seu backend local.

## 🧪 Testes

### Executando os Testes

```bash
dotnet test
```

### Cobertura de Código

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 📚 Estrutura Detalhada

### Camada de Apresentação (API)

- **Controllers**: Endpoints REST
- **Middleware**: CultureMiddleware para internacionalização
- **Filters**: ExceptionFilter para tratamento global de exceções

### Camada de Aplicação

- **Use Cases**: Implementação da lógica de negócio
- **Validators**: Validação de entrada com FluentValidation
- **AutoMapper**: Mapeamento entre DTOs e entidades

### Camada de Domínio

- **Entities**: Modelos de domínio
- **Repositories**: Interfaces para acesso a dados

### Camada de Infraestrutura

- **DbContext**: Configuração do Entity Framework
- **Repositories**: Implementação concreta dos repositórios
- **Unit of Work**: Gerenciamento de transações

## 🔒 Segurança e Configurações

- **CORS** configurado para permitir todas as origens
- **HTTPS** redirection habilitado
- **Swagger** disponível apenas em ambiente de desenvolvimento
- **URLs em lowercase** para padronização

### 🌐 Configuração CORS para Frontend

Para permitir que o frontend em produção acesse o backend local, o CORS já está configurado para aceitar todas as origens. Se precisar de uma configuração mais específica, você pode modificar o CORS no `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

## 📝 Licença

Este projeto está sob a licença MIT.
