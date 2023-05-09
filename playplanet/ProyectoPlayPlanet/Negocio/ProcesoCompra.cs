using ProyectoPlayPlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPlayPlanet.Negocio
{
	internal class ProcesoCompra
	{
		//Metodo1
		////public double[] Precio { get; set; }

		////public double CalcularTotalCompra()
		////{
		////    double total = 0;
		////    foreach (double precio in Precio)
		////    {
		////        total += precio;
		////    }
		////    return total;
		////}
		///
		public double Calculo(double Precio, int cantidad)
		{
	
			double totales = cantidad * Precio;
			return totales;

		}
	}





}
