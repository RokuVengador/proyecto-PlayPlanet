using ProyectoPlayPlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPlayPlanet.DAO
{
	

	internal class CRUDProveedores
	{
		Proveedore Proveedore = new Proveedore();
		PlayPlanetContext db = new PlayPlanetContext();

		public void Agregar(Proveedore proveedor) 
		{ 
		   Proveedore.CodProveedor = proveedor.CodProveedor;
		   Proveedore.NombredelProveedor = proveedor.NombredelProveedor;
		   Proveedore.Contacto = proveedor.Contacto;
		   db.Proveedores.Add(Proveedore);
		   db.SaveChanges();
		}

		public Proveedore BuscarProveedor(int cod) 
		{
			var buscarproveedor = db.Proveedores.FirstOrDefault(s => s.CodProveedor == cod);

		    return buscarproveedor!;
		}


		public void actualizarProovedor(Proveedore cod, int actualizar) 
		{
			var buscarprovedor = BuscarProveedor(cod.CodProveedor);

			if (buscarprovedor == null)
			{
				Console.WriteLine("El proveedor que buscas no existe");
			}
			else
			{
				if (actualizar == 1)
				{
					buscarprovedor.CodProveedor = cod.CodProveedor;
				}
				else if (actualizar == 2)
				{
					buscarprovedor.NombredelProveedor = cod.NombredelProveedor;
				}
				else if (actualizar == 3)
				{
					buscarprovedor.Contacto = cod.Contacto;
				}
				else 
				{
					Console.WriteLine("El campo  que quieres actualizar no existe ");
				}
				db.Proveedores.Update(buscarprovedor);
				db.SaveChanges();
			}

		}


		public string Eliminar (int cod) 
		{
			var buscarprovedor = BuscarProveedor(cod);

			if (buscarprovedor == null)
			{
				return("El proveedor que buscas no existe");
			}
			else 
			{ 
			   db.Proveedores.Remove(buscarprovedor);
			   db.SaveChanges();

			  return "El proveedor se elimino correctamente";
			}

		}
		public List<Proveedore> ListaDeProveedores() 
		{
			return db.Proveedores.ToList();
		}
	}
}
