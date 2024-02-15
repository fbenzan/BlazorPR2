using FacturacionSimple;
using FacturacionSimple.Data;
using FacturacionSimple.Servicios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
Memoria.Facturas = new()
{
    new Factura()
    {
        Cliente = "Felix Benzan",
        Numero = 1,
        Fecha = DateTime.Now,
        Detalles = new List<FacturaDetalle>
        {
            new FacturaDetalle(){ Producto="Yuca", Cantidad = 2, Precio = 50}
        }
    },
    new Factura()
    {
        Cliente = "Jorge Luis Velazquez",
        Numero = 2,
        Fecha = DateTime.Now.AddDays(1),
        Detalles = new List<FacturaDetalle>
        {
            new FacturaDetalle(){ Producto="Queso", Cantidad = 3, Precio = 150}
        }
    }
};
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IFacturaServices,FacturaServices>();

var app = builder.Build();

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
