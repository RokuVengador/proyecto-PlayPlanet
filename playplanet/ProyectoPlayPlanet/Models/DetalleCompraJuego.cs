using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPlayPlanet.Models;

public partial class DetalleCompraJuego
{


	public int Id { get; set; }

	public int VideojuegosId { get; set; }
	
	public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual Videojuego Videojuegos { get; set; } = null!;
}
