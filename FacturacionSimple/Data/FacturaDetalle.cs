namespace FacturacionSimple.Data;

public class FacturaDetalle
{
    public string Producto { get; set; } = "";
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal SubTotal => Cantidad * Precio;
}
