# DotnetRestApi

## Add Migration

```
dotnet ef migrations add "InitialMigration" --project .\DotnetRestApi.WebApi
```
## Drop Database

```
dotnet ef database drop --project .\DotnetRestApi.WebApi
```

## Remove the last migration.

```
dotnet ef migrations remove --project .\DotnetRestApi.WebApi
```

## Acknowledgement and motivation

- [api-rest-con-net-5-jwt-y-entity-framework](https://gitlab.com/UAI-TCTD/api-rest-con-net-5-jwt-y-entity-framework)