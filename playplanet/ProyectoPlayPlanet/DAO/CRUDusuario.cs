using ProyectoPlayPlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPlayPlanet.DAO
{
	internal class CRUDusuario
	{

		private Usuario Usuario = new Usuario();
		private PlayPlanetContext db = new PlayPlanetContext();
	   

		public void Agregar(Usuario usuario)
		{
			db.Usuarios.Add(usuario);
			db.SaveChanges();
		}

	}
}
