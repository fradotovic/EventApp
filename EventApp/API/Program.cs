using Microsoft.EntityFrameworkCore;

using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

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



app.Run();
