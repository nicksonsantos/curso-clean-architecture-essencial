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
cd CleanArchMvc.Domain.Tests
dotnet add package FluentAssertions --version 6.8.0
cd ..
dotnet sln CleanArchMvc.sln add CleanArchMvc.Domain.Tests/CleanArchMvc.Domain.Tests.csproj
```