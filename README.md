# AgendaContatos

API REST para gerenciamento de contatos desenvolvida em .NET 8 com clean architecture.

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

4. **Crie as migrations (primeira execução)**

   ```bash
   dotnet ef migrations add InitialCreate --project src/AgendaContatos.Infrastructure
   ```

5. **Execute as migrações**

   ```bash
   dotnet ef database update --project src/AgendaContatos.Infrastructure
   ```

6. **Execute a aplicação**

   ```bash
   dotnet run --project src/AgendaContatos.Api
   ```

7. **Acesse a documentação**
   - Swagger UI: `https://localhost:7000/swagger`

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

## 📝 Licença

Este projeto está sob a licença MIT.
