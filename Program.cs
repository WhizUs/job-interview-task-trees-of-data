using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TreesOfData.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddDbContextFactory<AppDbContext>(contextOptions => {
        contextOptions
            .UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext"))
            .EnableSensitiveDataLogging(true);
    })
    .AddTransient<IAppDbContext>(provider =>
        provider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext())
    .AddTransient(provider =>
        provider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    if (builder.Configuration.GetValue<bool>("Seed"))
    {
        await Seeder.Run(context);
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
