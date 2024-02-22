using FacturacionSimple;
using FacturacionSimple.Context;
using FacturacionSimple.Data;
using FacturacionSimple.Servicios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
Memoria.Facturas = new();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<IFSDbContext, FSDbContext>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IFacturaServices,FacturaServices>();

var app = builder.Build();
using var context = app.Services.CreateScope()
                     .ServiceProvider.GetRequiredService<FSDbContext>();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
