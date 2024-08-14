using Dinners2.CommandHandlers;
using Dinners2.Database;
using Dinners2.QueryHandlers;
using Dinners2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContexts
//builder.Services.AddDbContext<DinnerDb>(options =>
//    options.UseSqlite("Data Source=dinners.db"));
//builder.Services.AddDbContext<DinnerDb>(options =>
//    options.UseSqlite("Data Source=D:\\home\\site\\wwwroot\\data\\dinners.db"));

// Testing to add DbContext without connection string
builder.Services.AddDbContext<DinnerDb>();

// Add services to the container
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