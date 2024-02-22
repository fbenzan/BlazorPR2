using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionSimple.Data;

public class FacturaDetalle
{
    [Key]
    public int Id { get; set; }
    public int IdFactura { get; set; }

    [ForeignKey(nameof(IdFactura))]
    public virtual Factura? Factura { get; set; }

    public string Producto { get; set; } = "";
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    [NotMapped]
    public decimal SubTotal => Cantidad * Precio;
}
