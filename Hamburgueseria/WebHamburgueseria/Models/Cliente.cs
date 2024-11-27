using System;
using System.Collections.Generic;

namespace WebHamburgueseria.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Documento { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }
}
