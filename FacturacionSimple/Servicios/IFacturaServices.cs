using FacturacionSimple.Data;

namespace FacturacionSimple.Servicios
{
    public interface IFacturaServices
    {
        List<Factura> Consultar(string filtro = "");
        bool Crear(Factura datos);
    }
}