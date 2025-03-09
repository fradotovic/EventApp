## 1. Persistence dodaj novu klasu DbInitializer u koju ćeš seedati podatke


## 2. U tu klasu dodaš sljedeću metodu s obziorm koji entitet seedaš

public static async Task SeedData(AppDbContext context)
{

    if (context.Activities.Any()) return;


    var activities = new List<Activity>()
    {
       new()
            {
                Title = "Future Activity 8",
                Date = DateTime.Now.AddMonths(8),
                Description = "Activity 8 months in future",
                Category = "film",
                City = "London",
                Venue = "River Thames, England, United Kingdom",
                Latitude = 51.5575525,
                Longitude = -0.781404
            }
    };

    
    context.Activities.AddRange(activities); //--> ** Dodavanje da EF može pratiti u memoriji migraciju koja nije obavljena

    await context.SaveChangesAsync(); // -->izvodi sve ono što još nije u bazi odnosno gornji addRange

}

## 3. Zatim u Program.cs treba kreirati service scope i dodati ovaj kod prije app.run();


using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AppDbContext>();

    await context.Database.MigrateAsync(); // kreiranje baze ako nije kreirana

    await DbInitializer.SeedData(context);

}
catch (Exception ex )
{
    var logger = services.GetService<ILogger<Program>>();

    logger.LogError(ex, "An error occured during migration");

	throw;
}

### Ono što ovaj kod radi je da kreira migraciju ako je potrebna pri svakom izvođenju aplikacije ili javlja error ako migracija nije prošla
a trebalo je doći do migracije.