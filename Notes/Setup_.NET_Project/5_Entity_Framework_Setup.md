## 1. Instalacija 2 dodatna nuget paketa

-- microsoft.entityframework.Sqlite -> u Perisistence layer

--  microsoft.entityframework.design ->u startup API projekt treba instalirati

## 2.u Persistence složi novu klasu AppDbContext

-- ta klasa nasljeđuje DbContext (AppDbContext:DbContext)

### AppDbContext : DbContext

## 3. zatim u tu klasu dodaješ npr. DbSet<Activity> Activities od one klase koju si posložio prije

## 4. Potrebno registrirati korištenje DbContexta za EF
---
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

## 5. S obzirom da smo u 4. koraku stavili opt, potrebno je u klasi AppDbContext postaviti options

 ### public class AppDbContext(DbContextOptions options) : DbContext(options)
 {
     public required DbSet<Activity> Activites { get; set; }

 }


 ## 6. S obziorm da smo u builder stavili da je connection string na Configuration -> DefaultConnection

 -- u našem projektu imamo 2 settings filea u kojima postavljamo taj configuration u API folderu ili folderu controllera

 ### appsettings.json -- za produkciju
 #### appsettings.Development.json -- u development modu  samo 

 -- oboje ovih fileova mogu primiti Configuration za projekt 

 -- sve dok nisu neke tajne informacije može se koristiti appsettings.Development.json

 -- ako imam API keyeve koje ne želim koristiti javno onda ih stavljamo u appsettings.json i isključujemo ih iz committa na github repozitorij

#### Ovako se specificira u appsettings.Development.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data source=App.db"
  }
}


## 7. Nakon postavljanja ovog treba još instalirati neke nugete u startup Projecta(API) da se može provesti migracija

#### dotnet tool install --global dotnet-ef --version 9.0.2

-- EF će pogledati sve ove configuracije i setove koje ima i koje mora kreirati

--Id automatski će biti prepoznati kao primary Key ili moras koristiti DataAnotation [Key] ako se drugačije zove aribut

[Key]
public string Title(get;set;)   --> ako nije ID a hoćeš da to bude primary key

## 8. Odeš u folder iznad svega App u ovom slučaju i pozoveš migraciju

daješ naredbu

-p -> projekt koji sadrži naš data context

-s -> projekt koji je naš startup projekt

  ### - dotnet ef migrations add InitialCreate -p Persistence -s API

  ## 9. Nakon što se kreira migracija potrebno je još ažurirati migraciju

  ### - dotnet ef database update -p Persistence -s API

  ## 10. Brisanje baze koju si kreirao

  ### - dotnet ef database drop -p Persistence -s API


  ## 11. Ako želiš s MSSQL se spojiti moras samo dodati jos par nugeta za MSSQL i 
  postaviti u App.settings.Development.json neki drugi Connection string te u Program cs promijeniti da nije 
  SQL lite nego  SQL server services

  

  

