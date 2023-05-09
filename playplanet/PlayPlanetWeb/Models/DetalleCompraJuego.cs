using System;
using System.Collections.Generic;

namespace PlayPlanetWeb.Models;

public partial class DetalleCompraJuego
{
    public int Id { get; set; }

    public int VideojuegosId { get; set; }

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Videojuego Videojuegos { get; set; } = null!;
}
