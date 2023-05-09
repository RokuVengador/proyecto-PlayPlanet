using ProyectoPlayPlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPlayPlanet.DAO
{
	internal class CRUDvideojuegos
	{

		private Videojuego Videojuego= new Videojuego();
		private PlayPlanetContext db = new PlayPlanetContext();
		


		public void agregar(Videojuego videojuego) 
		{
			videojuego.NombreJuego = Videojuego.NombreJuego;
			videojuego.PreciodelJuego = Videojuego.PreciodelJuego;
			videojuego.Clasificacion = Videojuego.Clasificacion;
			videojuego.Stock = Videojuego.Stock;
			videojuego.ProveedoresId = Videojuego.ProveedoresId;
			db.Videojuegos.Add(videojuego);
			db.SaveChanges(); 
            
		}

		public Videojuego Videojuegoindividual(int id) 
		{
			var videojuegoindividual = db.Videojuegos.FirstOrDefault(s => s.Id == id);

			return videojuegoindividual;
		}

		public void Actualizar(Videojuego videojuego, int lector)  
		{

			var Juego = Videojuegoindividual(videojuego.Id);

			if (Juego == null)
			{

				Console.WriteLine("El id que buscas no se encuentra dento de la base de datos");

			}
			else 
			{
				if (lector == 1)
				{
					Juego.NombreJuego = videojuego.NombreJuego;
				}
				else if (lector == 2)
				{
					Juego.PreciodelJuego = videojuego.PreciodelJuego;
				}
				else if (lector == 3)
				{
					Juego.Clasificacion = videojuego.Clasificacion;
				}
				else if (lector == 4)
				{
					Juego.Stock = videojuego.Stock;
				}
				else if (lector == 5)
				{
					Juego.ProveedoresId = videojuego.ProveedoresId;
				}
				else 
				{
					Console.WriteLine("El campo  que quieres actualizar no existe ");
				}
				db.Videojuegos.Update(Juego);
				db.SaveChanges();
			}
		
		}

		public string ElinminarJuego(int id)
		{
			var juego = Videojuegoindividual(id);
			if (juego == null)
			{
				return ("El videouego que buscas no existe");
			}
			else
			{
				try
				{
					db.Videojuegos.Remove(juego);
					db.SaveChanges();
					return("El Videojuego se ha eliminado exitosamente");
				}

				catch (Exception)
				{
					return("ups! algo falló y no se pudo eliminar");
				}
			}
		}

		public List<Videojuego> ListadeVideojuegos() 
		{
			return db.Videojuegos.ToList();
		}

	}
}
