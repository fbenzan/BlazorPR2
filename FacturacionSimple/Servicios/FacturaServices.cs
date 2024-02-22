using FacturacionSimple.Context;
using FacturacionSimple.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FacturacionSimple.Servicios;

public class FacturaServices : IFacturaServices
{
    private readonly IFSDbContext dbContext;

    public FacturaServices(IFSDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public bool Crear(Factura datos)
    {
        var proxima_factura =
            (dbContext.Facturas.Any()) ?
            dbContext.Facturas.Max(f => f.Numero) + 1 : 1;
        datos.Numero = proxima_factura;
        datos.Fecha = DateTime.Now;
        try
        {
            dbContext.Facturas!.Add(datos);
            dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public List<Factura> Consultar(string filtro = "")
    {
        return dbContext.Facturas
            .Include(f=>f.Detalles)
            .Where(f => f.Cliente.Contains(filtro))
            .ToList();
    }
}
