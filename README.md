# curso-clean-architecture-essencial
Clean Architecture Essencial - ASP .NET Core com C# - Macoratti

Comandos utilizados:

```
dotnet new sln --name CleanArchMvc
dotnet new classlib --name CleanArchMvc.Domain
dotnet new classlib --name CleanArchMvc.Application
dotnet new classlib --name CleanArchMvc.Infra.Data
dotnet new classlib --name CleanArchMvc.Infra.IoC
dotnet new mvc --name CleanArchMvc.WebUI

dotnet sln CleanArchMvc.sln add CleanArchMvc.Application/CleanArchMvc.Application.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.Domain/CleanArchMvc.Domain.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj

dotnet add CleanArchMvc.Application reference CleanArchMvc.Domain/CleanArchMvc.Domain.csproj
dotnet add CleanArchMvc.Infra.Data reference CleanArchMvc.Domain/CleanArchMvc.Domain.csproj
dotnet add CleanArchMvc.Infra.IoC reference CleanArchMvc.Domain/CleanArchMvc.Domain.csproj
dotnet add CleanArchMvc.Infra.IoC reference CleanArchMvc.Application/CleanArchMvc.Application.csproj
dotnet add CleanArchMvc.Infra.IoC reference CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj
dotnet add CleanArchMvc.WebUI reference CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj

dotnet new xunit --name CleanArchMvc.Domain.Tests
dotnet add CleanArchMvc.Domain.Tests reference CleanArchMvc.Domain/CleanArchMvc.Domain.csproj
dotnet add CleanArchMvc.Domain.Tests/CleanArchMvc.Domain.Tests.csproj package FluentAssertions --version 6.8.0
dotnet sln CleanArchMvc.sln add CleanArchMvc.Domain.Tests/CleanArchMvc.Domain.Tests.csproj

dotnet tool install --global dotnet-ef
dotnet add CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add Inicial --project CleanArchMvc.Infra.Data -s CleanArchMvc.WebUI --verbose
dotnet ef database update --project CleanArchMvc.Infra.Data --startup-project CleanArchMvc.WebUI --verbose
dotnet ef migrations add SeedProducts --project CleanArchMvc.Infra.Data -s CleanArchMvc.WebUI --verbose
dotnet ef database update --project CleanArchMvc.Infra.Data --startup-project CleanArchMvc.WebUI --verbose

dotnet add CleanArchMvc.Application/CleanArchMvc.Application.csproj package AutoMapper --version 12.0.0
dotnet add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.0
dotnet add CleanArchMvc.Application/CleanArchMvc.Application.csproj package MediatR --version 11.1.0
dotnet add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj package MediatR.Extensions.Microsoft.DependencyInjection --version 11.0.0

dotnet add CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj package Microsoft.AspNetCore.Identity --version 2.2.0
dotnet add CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 6.0.13
dotnet ef migrations add AddIdentityTables --project CleanArchMvc.Infra.Data -s CleanArchMvc.WebUI --verbose
dotnet ef database update --project CleanArchMvc.Infra.Data --startup-project CleanArchMvc.WebUI --verbose

dotnet new "webapi" -lang "C#" -n "CleanArchMvc.API" -o "CleanArchMvc.API"
dotnet sln "/workspaces/curso-clean-architecture-essencial/CleanArchMvc.sln" add "/workspaces/curso-clean-architecture-essencial/CleanArchMvc.API/CleanArchMvc.API.csproj"
dotnet add CleanArchMvc.API reference CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj

dotnet add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj package Microsoft.AspNetCore.Authentication.JwtBearer --version 6.0.13
dotnet add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj package Swashbuckle.AspNetCore.Swagger --version 6.5.0
dotnet add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj package Swashbuckle.AspNetCore.SwaggerGen --version 6.5.0
dotnet add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj package Swashbuckle.AspNetCore.SwaggerUI --version 6.5.0
```