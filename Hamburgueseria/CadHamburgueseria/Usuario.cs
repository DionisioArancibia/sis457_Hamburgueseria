
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
    
public partial class Usuario
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Usuario()
    {

        this.Venta = new HashSet<Venta>();

    }


    public int IdUsuario { get; set; }

    public string usuario1 { get; set; }

    public string clave { get; set; }

    public string UsuarioRegistro { get; set; }

    public System.DateTime fechaRegistro { get; set; }

    public short estado { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Venta> Venta { get; set; }

}

}
