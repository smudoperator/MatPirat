using Dinners2.Database;
using Dinners2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContexts with the updated configuration
builder.Services.AddDbContext<DinnerDb>(options =>
{
    var environment = builder.Environment.EnvironmentName;

    // Check if the environment is Development
    if (environment == "Development")
    {
        // Local development path
        options.UseSqlite($"Data Source={Path.Combine("C:\\Users\\simhal\\source\\repos\\MatPirat\\Data", "dinners.db")}");
    }
    else
    {
        // Azure production path (persistent storage)
        options.UseSqlite($"Data Source={Path.Combine("D:\\home\\data", "dinners.db")}");
    }
});


// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Services
builder.Services.AddScoped<IDinnerService, DinnerService>();
builder.Services.AddScoped<IDinnerPlanService, DinnerPlanService>();


// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Replace with actual frontend URL
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());
});

// Add Controllers
builder.Services.AddControllers();


var app = builder.Build();


// Apply database migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DinnerDb>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure Swagger UI in production as well
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
});

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();
app.MapControllers();
app.Run();