using app.repo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region connect database

builder.Services.AddDbContext<AppContext1>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("con"));
}
);
#endregion

#region builder services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region app pipeline
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
#region auto migration
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>(); //!show exception of dbContext
try
{
	var dbContext = services.GetRequiredService<AppContext1>();
	await dbContext.Database.MigrateAsync();
	await AppSeeding.SeedAsync(dbContext);
}
catch (Exception ex)
{

	var logger = loggerFactory.CreateLogger<Program>();
	logger.LogError(ex, "error occured while migration");
}
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();
