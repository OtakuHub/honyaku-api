# Honyaku

Connect readers and translators

## Database setup

```bash
# inside Models/honyakuapiContext
# set your database url to non-existent database
"Host=localhost;Database=honyaku-db;Username=user;Password=pass"

# run the migration to setup the database
dotnet ef database update
```

## Tech Stack

- .net core 3.1
- postgresql
