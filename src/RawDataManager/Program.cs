using FinalProjectLibrary;
using FinalProjectLibrary.Contexts;
using FinalProjectLibrary.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using RawDataManager.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WarmFinalProjectContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDBWarm")));

builder.Services.AddDbContext<ColdFinalProjectContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDBCold")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IColdUnitOfWork, ColdUnitOfWork>();

builder.Services.AddScoped<IRawDataHandler, RawDataHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
