using System;
using System.Collections.Generic;

namespace ProyectoPlayPlanet.Models;

public partial class Videojuego
{
    public int Id { get; set; }

    public string? NombreJuego { get; set; }

    public double? PreciodelJuego { get; set; }

    public string? Clasificacion { get; set; }

    public int? Stock { get; set; }

    public int ProveedoresId { get; set; }

    public virtual ICollection<DetalleCompraJuego> DetalleCompraJuegos { get; set; } = new List<DetalleCompraJuego>();

    public virtual Proveedore Proveedores { get; set; } = null!;
}
