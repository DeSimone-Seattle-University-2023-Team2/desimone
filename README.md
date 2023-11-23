# DCE WEB

## Database
### Migrations
To create a new migration, locate to ``Infrastructure`` project and run migration
```bash
cd src
dotnet ef migrations add "SampleMigration2" --startup-project Presentation --project Infrastructure --output-dir Data/Migrations
cd Presentation
dotnet ef database update
``` 