using Implementation3.WebAPI;
using Implementation3.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();

builder.Services.AddTransient<IDividerService, DividerService>();
builder.Services.AddTransient<ICalculator, CalculatorService>();
builder.Services.AddTransient<IIteratorService, IteratorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapEndpoints();
app.MapHub<SignalRUpdater>("/calculator");
app.Run();