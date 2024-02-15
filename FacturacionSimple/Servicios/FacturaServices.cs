using FacturacionSimple.Data;
using Microsoft.AspNetCore.Mvc;
namespace FacturacionSimple.Servicios;

public class FacturaServices : IFacturaServices
{
    public bool Crear(Factura datos)
    {
        var proxima_factura =
            (Memoria.Facturas != null && Memoria.Facturas.Any()) ?
            Memoria.Facturas.Max(f => f.Numero) + 1 : 1;
        datos.Numero = proxima_factura;
        datos.Fecha = DateTime.Now;
        try
        {
            Memoria.Facturas!.Add(datos);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public List<Factura> Consultar(string filtro = "")
    {
        return Memoria.Facturas
            .Where(f => f.Cliente.Contains(filtro))
            .ToList();
    }
}
