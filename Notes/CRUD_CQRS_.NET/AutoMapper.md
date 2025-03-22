## za mapiranje jednog objekta u drugi

## 1. U Nuget paketima potrazis Automapper i instaliras ga u Application.csproj

## 2. Injectas u Handler IMapper maper u handler one klase s kojom radis

--- public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
 {
     public async Task Handle(Command request, CancellationToken cancellationToken)
     {

         var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken);

         if (activity == null) throw new Exception("Cannot find activity");


        ** mapper.Map(request.Activity, activity);

          
         await context.SaveChangesAsync(cancellationToken);

     }
 }
## 3. Potrebno je još dodatno i konfigurirati Automapper da zna što mapira, napravis u Application još jedan folder CORE
koji će sadržavati sve dijeljene konfiguracije i fileove za razne funkcionalnosti

### U tom folderu kreiras klasu i nazoves je npr. MappingProfiles i napravis klasu unutar klase i pozoves funkcijue CreateMap koja kaže
da mapiras activity u activity

namespace Application.Core
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
        }
    }
}

## 4. S obzirom da Injectamo ovo treba ga registrirati u Program.cs ovu donju naredbu u koja iz Application.dll vuče taj asembly za mapiranje

### builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);




