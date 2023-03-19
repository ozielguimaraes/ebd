 # Ebd
Sistema e aplicativo para gestão de alunos

## Adicionar um migration

`dotnet ef migrations add ResponsavelAluno -s  EscolaBiblicaDominical/Ebd.Presentation.Api/Ebd.Presentation.Api.csproj -c MainContext --project EscolaBiblicaDominical/Ebd.Infra.Data/Ebd.Infra.Data.csproj`

`dotnet ef database update -s EscolaBiblicaDominical/Ebd.Presentation.Api/Ebd.Presentation.Api.csproj -c MainContext`