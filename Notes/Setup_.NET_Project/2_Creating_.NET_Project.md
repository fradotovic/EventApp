## Kreiraj naziv foldera u kojem ćeš raditi cijeli projekt

- Uđi u taj folder u kojem će biti i Client.(React.js) i Backend(.NET) projekti 

### dotnet --info 
-> da vidis koje SDK je instaliran

### dotnet new list 
--> da vidiš koje sve mogućnosti za kreiranje projekta imaš

- Mi ćemo kreirati projekt .sln i ASP.NET Core Web API(starting point)

## 1. Prvo kreiramo .sln file  
- dotnet new sln -> dobija ima prema folderu u kojem se nalazi App u ovom slučaju

- .sln fle je samo kontejner za druge projekte

### dotnet new sln 

## 2. Kreiramo projekt 

- nakon kreiranja .sln kreiramo webapi projekt prema tagovima Short Name koji si videl u dotnet new list

 - dotnet new webapi -n API -controllers -> naredba za kreiranje projekta API(naziv) i 
 
 da projekt zna da su to kontrolleri treba obavezno dodati -controllers

 ### dotnet new webapi -n API -controllers 

// SVE OVE Library dodajes u isti folder u kojem si kreiral projekt App u ovom slučaju a on je kreiran prema naredbi iznad 


 ## 3. Dodajemo neke class Library-je

 -- Trebamo jedan class Library za DOMAIN 
 
 ### dotnet new classlib -n DOMAIN

 -- Trebamo jedan class Library za APPLICATION LAYER

 ### dotnet new classlib -n Application

-- I jedan class Library za PERSISTENCE

 ### dotnet new classlib -n Persistence


## 4. Kada smo kreirali Kontrollere i Librarye treba ih dodati u .sln (solution)
-- ovo donje je naredba za add tih kreiranihu sln

### dotnet sln add API

### dotnet sln add Application

### dotnet sln add DOMAIN

### dotnet sln add Persistence


## 5. Potrebno još dodati reference 

- Potrebno dodati reference iz API koji idu  u Application 

--API(kontrolleri) trebaju referencu na Application Layer

### dotnet add reference ../Application/Application.csproj -> dodavanje ove reference u API projekt , moras prvo doći u folder u koji dodajes reference

--Application Layer treba referencu na DOMAIN i Persistence

### dotnet add reference ../DOMAIN/DOMAIN.csproj
### dotnet add reference ../Persistence/Persistence.csproj


-- Persistence treba referencu na DOMAIN (ovisi o DOMAINU) --> ući u folder PERSISTENCE i dodati isto kao i ostalo potrebno ući u folder

### dotnet add reference ../DOMAIN/DOMAIN.csproj


## STARTUP PROJECT JE API -> njegova obaveza je primanje i slanje HTTP zahtjeva i odgovora

### dotnet run -> za pokretanje projekta 
















