using Dinners2.CommandHandlers;
using Dinners2.Database;
using Dinners2.QueryHandlers;
using Dinners2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContexts
builder.Services.AddDbContext<DinnerDb>(options =>
    options.UseSqlite("Data Source=dinners.db"));

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Handlers
builder.Services.AddTransient<GetDinnerQueryHandler>();
builder.Services.AddScoped<AddDinnerCommandHandler>();
builder.Services.AddScoped<EditDinnerCommandHandler>();
builder.Services.AddScoped<DeleteDinnerCommandHandler>();
builder.Services.AddScoped<PlanDinnersCommandHandler>();

// Add Services
builder.Services.AddTransient<DinnerService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
