using ProyectoPlayPlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPlayPlanet.DAO
{
	internal class CRUDDetallesCompra
	{
		DetalleCompraJuego Detallecompra = new DetalleCompraJuego();
		PlayPlanetContext db = new PlayPlanetContext();

		public void AgregarDetallle(DetalleCompraJuego detalle)
		{
			
			Detallecompra.UsuarioId = detalle.UsuarioId;
			Detallecompra.VideojuegosId = detalle.VideojuegosId;
			db.DetalleCompraJuegos.Add(Detallecompra);
			db.SaveChanges();
		}

		public List<DetalleCompraJuego> DetalleCompraJuegos()
		{
			return db.DetalleCompraJuegos.ToList();
		}



	}
}
