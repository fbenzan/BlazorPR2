using FacturacionSimple.Data;
using Microsoft.EntityFrameworkCore;

namespace FacturacionSimple.Context;

public class FSDbContext : DbContext, IFSDbContext
{
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<FacturaDetalle> FacturasDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=FSDbContext.db");
    }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
