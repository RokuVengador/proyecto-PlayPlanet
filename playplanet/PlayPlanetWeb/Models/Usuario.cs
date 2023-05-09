using System;
using System.Collections.Generic;

namespace PlayPlanetWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }

    public int? Edad { get; set; }

    public int? Dui { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public int? Contacto { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<DetalleCompraJuego> DetalleCompraJuegos { get; set; } = new List<DetalleCompraJuego>();
}
