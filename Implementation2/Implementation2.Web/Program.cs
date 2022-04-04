using Implementation2.Db;
using Implementation2.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<GeneratorService>();
builder.Services.AddDbContextFactory<I2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("I2Db")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetService<I2Context>()!.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
