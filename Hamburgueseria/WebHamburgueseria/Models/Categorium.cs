﻿using System;
using System.Collections.Generic;

namespace WebHamburgueseria.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
