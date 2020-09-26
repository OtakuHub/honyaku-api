# Honyaku

Connect readers and translators

## Database setup

At the root of the project, create a `.env` file with the database url:

```bash
# this will be used inside Models/honyakuapiContext
# set your database url to non-existent database
DATABASE_URL="Host=localhost;Database=honyaku-db;Username=user;Password=pass"

# run the migration to setup the database
dotnet ef database update
```

## Generate Controllers

You can generate controllers using the `dotnet-aspnet-codegenerator` package.

```bash
dotnet-aspnet-codegenerator \
  -p honyaku-api.csproj \
  controller -name UsersController -api \
  -m honyaku_api.Models.User \
  -dc honyakuapiContext \
  -outDir Controllers \
  -namespace honyaku_api.Controllers
```

## Tech Stack

- .net core 3.1
- postgresql
