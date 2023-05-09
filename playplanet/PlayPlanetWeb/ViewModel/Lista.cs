using Microsoft.EntityFrameworkCore;
using PlayPlanetWeb.Models;

namespace PlayPlanetWeb.ViewModel
{
	public class Lista
	{

		public List<DetalleCompraViewModel> DetalleCompraViews { get; set; }
		{
		 
		 


			PlayPlanetContext db = new PlayPlanetContext();

		var query = db.DetalleCompraViews.FromSqlRaw($"Select U.NombreUsuario, U.ApellidoUsuario, V.NombreJuego, V.PreciodelJuego \r\nfrom DetalleCompraJuegos D inner join Usuarios U ON D.Usuario_Id = U.Id \r\n " +
			$" inner join Videojuegos V on  D.Videojuegos_id = V.Id\r\n").ToList();

        }


	}
}
