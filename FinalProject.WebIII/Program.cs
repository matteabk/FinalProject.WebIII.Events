using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Services;
using FinalProject.WebIII.Data.Repository;
using FinalProject.WebIII.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityEventServices, CityEventServices>();
builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();
builder.Services.AddScoped<IEventReservationServices, EventReservationServices>();
builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();

builder.Services.AddScoped<CheckIdEventForReservation>();
builder.Services.AddScoped<CheckExistingIdEvent>();
builder.Services.AddScoped<CheckExistingIdReservation>();

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
