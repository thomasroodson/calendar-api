# 📅 PROJETO CALENDAR - ESTRUTURA COMPLETA DO BACKEND

## 📋 INFORMAÇÕES GERAIS

**Framework:** .NET 10.0  
**Arquitetura:** Clean Architecture  
**Banco de Dados:** MongoDB 3.6.0  
**Padrões:** Repository Pattern, Use Cases, Dependency Injection  

---

## 🗂️ ESTRUTURA DE PASTAS

```
CalendarProject/
│
├── src/
│   ├── Backend/
│   │   ├── ProjectCalendar.API/              # Camada de Apresentação (Controllers, Middleware)
│   │   │   ├── Controllers/
│   │   │   │   └── EventController.cs
│   │   │   ├── Filters/
│   │   │   │   └── ExceptionFilter.cs
│   │   │   ├── Middleware/
│   │   │   │   └── CultureMiddleware.cs
│   │   │   ├── Properties/
│   │   │   │   └── launchSettings.json
│   │   │   ├── Program.cs
│   │   │   ├── appsettings.json
│   │   │   ├── appsettings.Development.json
│   │   │   └── ProjectCalendar.API.csproj
│   │   │
│   │   ├── ProjectCalendar.Application/      # Camada de Aplicação (Use Cases, Validators)
│   │   │   ├── UseCases/
│   │   │   │   └── Event/
│   │   │   │       └── Register/
│   │   │   │           ├── IRegisterEventUseCase.cs
│   │   │   │           ├── RegisterEventUseCase.cs
│   │   │   │           └── RegisterEventValidator.cs
│   │   │   ├── DependencyInjectionExtension.cs
│   │   │   └── ProjectCalendar.Application.csproj
│   │   │
│   │   ├── ProjectCalendar.Domain/           # Camada de Domínio (Entidades, Interfaces)
│   │   │   ├── Entities/
│   │   │   │   └── Event.cs
│   │   │   ├── Interfaces/
│   │   │   │   └── IEventRepository.cs
│   │   │   ├── ValueObjects/
│   │   │   │   ├── DateRange.cs
│   │   │   │   └── EventColor.cs
│   │   │   └── ProjectCalendar.Domain.csproj
│   │   │
│   │   └── ProjectCalendar.Infrastructure/   # Camada de Infraestrutura (MongoDB, Repositories)
│   │       ├── DataAccess/
│   │       │   ├── EventRepository.cs
│   │       │   ├── MongoDbConfiguration.cs
│   │       │   └── MongoDbContext.cs
│   │       ├── DependencyInjectionExtension.cs
│   │       └── ProjectCalendar.Infrastructure.csproj
│   │
│   └── Shared/
│       ├── ProjectCalendar.Communication/     # DTOs (Requests e Responses)
│       │   ├── Requests/
│       │   │   └── RequestRegisterEventJson.cs
│       │   ├── Responses/
│       │   │   ├── ResponseErrorJson.cs
│       │   │   └── ResponseRegisterEventJson.cs
│       │   └── ProjectCalendar.Communication.csproj
│       │
│       └── ProjectCalendar.Exceptions/        # Exceções Customizadas
│           ├── ExceptionsBase/
│           │   ├── CalendarProjectException.cs
│           │   ├── ErrorOnValidationException.cs
│           │   └── ProjectCalendarException.cs
│           ├── ResourceMessagesException.cs
│           ├── ResourceMessagesException.Designer.cs
│           ├── ResourceMessagesException.resx
│           └── ProjectCalendar.Exceptions.csproj
│
├── tests/                                     # Pasta de testes (vazia)
│
├── CalendarProject.slnx                       # Arquivo de solução
└── PROJETO_COMPLETO.txt                       # Arquivo com todos os códigos
```

---

## 🏗️ DESCRIÇÃO DAS CAMADAS

### 1️⃣ **API Layer** (`ProjectCalendar.API`)

**Responsabilidade:** Receber requisições HTTP, rotear para os Use Cases e retornar respostas.

**Componentes:**
- **EventController.cs**: Controller REST com endpoint POST para criar eventos
- **ExceptionFilter.cs**: Filtro global para tratamento de exceções
- **CultureMiddleware.cs**: Middleware para internacionalização
- **Program.cs**: Configuração da aplicação (DI, MongoDB, Mapster, Swagger)

**Dependências:**
- Mapster.DependencyInjection 1.0.1
- Microsoft.AspNetCore.OpenApi 10.0.2
- Swashbuckle.AspNetCore 10.1.1
- MongoDB.Driver (via Infrastructure)

**Porta:** http://localhost:5294 | https://localhost:7023

---

### 2️⃣ **Application Layer** (`ProjectCalendar.Application`)

**Responsabilidade:** Implementar regras de negócio através de Use Cases.

**Componentes:**
- **RegisterEventUseCase.cs**: Lógica para criar um novo evento
- **IRegisterEventUseCase.cs**: Interface do Use Case
- **RegisterEventValidator.cs**: Validações usando FluentValidation

**Dependências:**
- FluentValidation 12.1.1
- FluentValidation.DependencyInjectionExtensions 12.1.1
- Mapster 7.4.0

**Padrão:** Use Case Pattern + Validator Pattern

---

### 3️⃣ **Domain Layer** (`ProjectCalendar.Domain`)

**Responsabilidade:** Definir entidades, value objects e interfaces do domínio.

**Entidades:**
- **Event.cs**: Entidade principal com Id, Title, DateRange, Color, Description

**Value Objects:**
- **DateRange.cs**: Encapsula StartDate e EndDate
- **EventColor.cs**: Encapsula a cor do evento

**Interfaces:**
- **IEventRepository.cs**: Contrato para operações CRUD de eventos

**Sem dependências externas** (Clean Architecture)

---

### 4️⃣ **Infrastructure Layer** (`ProjectCalendar.Infrastructure`)

**Responsabilidade:** Implementar acesso a dados e integrações externas.

**Componentes:**
- **MongoDbContext.cs**: Contexto do MongoDB com coleção de Events
- **MongoDbConfiguration.cs**: Configurações de serialização do MongoDB
- **EventRepository.cs**: Implementação do IEventRepository com operações:
  - CreateAsync
  - GetByIdAsync
  - GetAllAsync
  - GetByDateRangeAsync
  - UpdateAsync
  - DeleteAsync

**Dependências:**
- MongoDB.Driver 3.6.0
- Microsoft.Extensions.Configuration 10.0.2
- Microsoft.Extensions.Options 10.0.2

**Configuração MongoDB:**
- Connection String: `mongodb://localhost:27017`
- Database: `calendar_db`
- Collection: `events`

---

### 5️⃣ **Shared Layer** (`ProjectCalendar.Communication` e `ProjectCalendar.Exceptions`)

**Communication:**
- **RequestRegisterEventJson.cs**: DTO para criar evento
- **ResponseRegisterEventJson.cs**: DTO de resposta com evento criado
- **ResponseErrorJson.cs**: DTO para erros

**Exceptions:**
- **ProjectCalendarException.cs**: Exceção base
- **ErrorOnValidationException.cs**: Exceção para erros de validação
- **ResourceMessagesException**: Mensagens de erro internacionalizadas

---

## 🔌 ENDPOINTS IMPLEMENTADOS

### **POST /Event**
Cria um novo evento no calendário.

**Request Body:**
```json
{
  "title": "Reunião",
  "startDate": "2026-02-05T10:00:00",
  "endDate": "2026-02-05T11:00:00",
  "color": "#FF5733",
  "description": "Reunião de planejamento"
}
```

**Response (201 Created):**
```json
{
  "id": "507f1f77bcf86cd799439011",
  "title": "Reunião",
  "startDate": "2026-02-05T10:00:00",
  "endDate": "2026-02-05T11:00:00",
  "color": "#FF5733",
  "description": "Reunião de planejamento"
}
```

**Response (400 Bad Request):**
```json
{
  "errorMessages": [
    "Title is required",
    "Start date must be before end date"
  ]
}
```

---

## ⚙️ CONFIGURAÇÕES

### **appsettings.json**
```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "calendar_db"
  },
  "AllowedHosts": "*"
}
```

### **Injeção de Dependências**

**Program.cs:**
```csharp
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration["MongoDbSettings:ConnectionString"];
    return new MongoClient(connectionString);
});

builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
```

---

## 📦 PACOTES NUGET UTILIZADOS

| Pacote | Versão | Camada | Finalidade |
|--------|--------|--------|------------|
| MongoDB.Driver | 3.6.0 | Infrastructure | Driver oficial do MongoDB |
| FluentValidation | 12.1.1 | Application | Validação de dados |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 | Application | Integração com DI |
| Mapster | 7.4.0 | Application | Mapeamento de objetos |
| Mapster.DependencyInjection | 1.0.1 | API | Integração Mapster com DI |
| Swashbuckle.AspNetCore | 10.1.1 | API | Documentação Swagger |
| Microsoft.AspNetCore.OpenApi | 10.0.2 | API | Suporte OpenAPI |

---

## ❌ O QUE ESTÁ FALTANDO

### **Endpoints CRUD Completos**
- ❌ GET /Event (listar todos os eventos)
- ❌ GET /Event/{id} (buscar evento por ID)
- ❌ GET /Event/week?startDate=... (buscar eventos por semana)
- ❌ PUT /Event/{id} (atualizar evento - drag & drop, cor)
- ❌ DELETE /Event/{id} (deletar evento)

### **Docker/Containerização**
- ❌ Dockerfile para o backend
- ❌ docker-compose.yml com 3 containers (Frontend, Backend, MongoDB)
- ❌ Frontend Svelte (não existe ainda)

### **Configurações**
- ❌ CORS configurado (necessário para frontend em porta diferente)
- ❌ Variáveis de ambiente para Docker
- ❌ MongoDB sem persistência (volumes não montados)

### **Funcionalidades Específicas**
- ❌ Endpoint para drag & drop (atualizar datas)
- ❌ Endpoint para alterar cores
- ❌ Endpoint para navegação semanal
- ❌ Notificação visual de sucesso (frontend)

---

## 🚀 COMO EXECUTAR (ATUALMENTE)

### **Pré-requisitos:**
- .NET 10.0 SDK
- MongoDB rodando em localhost:27017

### **Comandos:**
```bash
cd src/Backend/ProjectCalendar.API
dotnet restore
dotnet run
```

### **Acessar Swagger:**
```
http://localhost:5294/swagger
```

---

## 📝 PRÓXIMOS PASSOS RECOMENDADOS

1. **Completar endpoints CRUD** (GET, PUT, DELETE)
2. **Criar Dockerfile** para o backend
3. **Criar projeto Svelte** para o frontend
4. **Criar docker-compose.yml** com os 3 containers
5. **Configurar CORS** no backend
6. **Ajustar connection string** para usar variável de ambiente
7. **Implementar endpoints específicos** para navegação semanal
8. **Adicionar testes unitários** e de integração

---

## 📄 ARQUIVO COMPLETO

Todos os códigos-fonte estão disponíveis no arquivo:
**`PROJETO_COMPLETO.txt`**

Este arquivo contém todos os arquivos .cs, .csproj e .json do projeto com seus respectivos caminhos e códigos completos.

---

## 🔗 REFERÊNCIAS

- **Clean Architecture:** https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
- **MongoDB Driver .NET:** https://www.mongodb.com/docs/drivers/csharp/
- **FluentValidation:** https://docs.fluentvalidation.net/
- **Mapster:** https://github.com/MapsterMapper/Mapster

---

**Última atualização:** 05/02/2026  
**Versão do .NET:** 10.0  
**Status:** Backend parcialmente implementado (apenas POST /Event)
