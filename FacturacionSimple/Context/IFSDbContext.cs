using FacturacionSimple.Data;
using Microsoft.EntityFrameworkCore;

namespace FacturacionSimple.Context
{
    public interface IFSDbContext
    {
        DbSet<Factura> Facturas { get; set; }
        DbSet<FacturaDetalle> FacturasDetalles { get; set; }

        int SaveChanges();
    }
}