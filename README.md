📘 Feitep

Feitep é um sistema web desenvolvido em C# (.NET) utilizando Blazor e Entity Framework Core, com banco de dados SQLite.
O objetivo é permitir o gerenciamento de Professores e Equipamentos, possibilitando realizar operações de cadastro, edição, consulta e exclusão via interface Blazor.
------------------

🚀 Tecnologias Utilizadas

.NET

Blazor

C#

Entity Framework Core

SQLite

Bootstrap

----------------------------------------------------




Feitep/
 ├── Areas/
 │    └── Identity/
 ├── Data/
 ├── Models/
 │    ├── Professor.cs
 │    └── Equipamento.cs
 ├── Pages/
 ├── wwwroot/
 ├── app.db
 ├── appsettings.json
 ├── Program.cs
 ├── Feitep.csproj
 └── Feitep.sln


-------------
🖥️ Funcionalidades

✔️ CRUD de Professores

✔️ CRUD de Equipamentos

✔️ Persistência em SQLite

✔️ Interface Blazor intuitiva

✔️ Autenticação via Identity (estrutura já disponível)

-----------------------------------------------------
COMO EXECUTAR EM SUA MAQUINA LOCAL:

git clone https://github.com/marlonagner/Feitep.git
cd Feitep
dotnet restore
dotnet ef database update
dotnet run

----------------------
🛢 Banco de Dados

Banco: SQLite

Arquivo: app.db

Configuração: appsettings.json

---------------------------------
🔮 Melhorias Futuras

Sistema de reservas

Dashboard

Busca avançada

API REST

Testes automatizados

Interface mais moderna

------------------
🙌 Contribuição

Fork no projeto

Crie uma branch (git checkout -b minha-feature)

Commit → Push

Abra um Pull Request

-----------------------



