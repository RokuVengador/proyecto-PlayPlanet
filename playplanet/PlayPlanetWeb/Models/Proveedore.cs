using System;
using System.Collections.Generic;

namespace PlayPlanetWeb.Models;

public partial class Proveedore
{
    public int CodProveedor { get; set; }

    public string? NombredelProveedor { get; set; }

    public int? Contacto { get; set; }

    public virtual ICollection<Videojuego> Videojuegos { get; set; } = new List<Videojuego>();
}
