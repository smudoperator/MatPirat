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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
