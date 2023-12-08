 # Ebd
Sistema e aplicativo para gestão de alunos

## Adicionar um migration

`dotnet ef migrations add Initial -s  EscolaBiblicaDominical/Ebd.Presentation.Api/Ebd.Presentation.Api.csproj -c MainContext --project EscolaBiblicaDominical/Ebd.Infra.Data/Ebd.Infra.Data.csproj`

`dotnet ef database update -s EscolaBiblicaDominical/Ebd.Presentation.Api/Ebd.Presentation.Api.csproj -c MainContext`

## Atualizar EF Tools
`dotnet tool update --global dotnet-ef`

## Confiar no certiciado localhost
`dotnet dev-certs https --trust`