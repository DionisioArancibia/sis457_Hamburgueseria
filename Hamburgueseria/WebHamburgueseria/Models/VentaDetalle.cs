using System;
using System.Collections.Generic;

namespace WebHamburgueseria.Models;

public partial class VentaDetalle
{
    public int IdDetalleVenta { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal Cantidad { get; set; }

    public decimal SubTotal { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
