
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CadHamburgueseria
{

using System;
    using System.Collections.Generic;
    
public partial class VentaDetalle
{

    public int IdDetalleVenta { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal Cantidad { get; set; }

    public decimal SubTotal { get; set; }

    public string UsuarioRegistro { get; set; }

    public System.DateTime fechaRegistro { get; set; }

    public short estado { get; set; }



    public virtual Producto Producto { get; set; }

    public virtual Venta Venta { get; set; }

}

}
