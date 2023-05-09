using ProyectoPlayPlanet.DAO;
using ProyectoPlayPlanet.Models;
using ProyectoPlayPlanet.Negocio;
using System.Timers;

CRUDusuario cu = new CRUDusuario();
Usuario usuario = new Usuario();
CRUDvideojuegos cRU = new CRUDvideojuegos();
CRUDDetallesCompra crudCompra = new CRUDDetallesCompra();
DetalleCompraJuego detalle = new DetalleCompraJuego();
ProcesoCompra compra = new ProcesoCompra();
Proveedore proveedore = new Proveedore();
CRUDProveedores crudP = new CRUDProveedores();
Videojuego videojuego = new Videojuego();






Console.WriteLine("Pulsa 1 si eres	Comprador ");
Console.WriteLine("Pulsa 2 si eres	un Vendedor ");
int tipo = Convert.ToInt32(Console.ReadLine());


switch (tipo)
{
	case 1:
		bool continuar = true;
		while (continuar)
		{

			Console.WriteLine("Pulsa  1 si quieres registrarte Como Usuario");
			Console.WriteLine("Pulsa  2 si quieres registrar una Compra");
			int RegistroU = Convert.ToInt32(Console.ReadLine());

			switch (RegistroU)
			{

				case 1:
					bool usu = true;
					while (usu)
					{
						Console.WriteLine("nombre usuario");
						usuario.NombreUsuario = Console.ReadLine();

						Console.WriteLine("Apellido:");
						usuario.ApellidoUsuario = Console.ReadLine();

						Console.WriteLine("Edad:");
						usuario.Edad = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("DUI");
						usuario.Dui = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("Telefono:");
						usuario.Contacto = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("Dirrecion:");
						usuario.Direccion = Console.ReadLine();

						Console.WriteLine("Correo:");
						usuario.Email = Console.ReadLine();

						Console.WriteLine("Contraseña: ");
						usuario.Contraseña = Console.ReadLine();

						cu.Agregar(usuario);
						Console.Write("Su numero de usuario es: ");
					
						Console.WriteLine("Usuario creado existosamente");
						Console.WriteLine("*****************************************");
						Console.WriteLine("Por favor recuerde su numero de Usuario");
						Console.WriteLine("******************************************");
						Console.WriteLine("----------------------------------------");
						Console.WriteLine(usuario.Id);
						Console.WriteLine("----------------------------------------");

						Console.WriteLine("¿Escriba R Para Regresar al menú pincipal");
						var b = Console.ReadLine();
						if (b == "R")
						{
							usu = false;
						}

					}
					break;

				case 2:
					var Listar = cRU.ListadeVideojuegos();
					foreach (var listaJuego in Listar)
					{
						Console.WriteLine("*******************************************************************************************************");
						Console.WriteLine($" Numero de orden del juego {listaJuego.Id}  Nombre del juego:{listaJuego.NombreJuego},  Precio del juego:{listaJuego.PreciodelJuego},  Clasificacion:{listaJuego.Clasificacion}");
						Console.WriteLine("*******************************************************************************************************");
					}

					List<string> NombreJuego = new List<string>();
		
					double total = 0;

					bool seguir = true;
					while (seguir)
					{

						Console.WriteLine("¿Ingrese su  numero de usuario: ");
						detalle.UsuarioId = Convert.ToInt32(Console.ReadLine());
						
						Console.WriteLine("¿Que juegos va a comprar?  ");
						string Juegos = Console.ReadLine();
						NombreJuego.Add(Juegos);

						Console.WriteLine("ingresa el numero de orden del juego: ");
						detalle.VideojuegosId = Convert.ToInt32(Console.ReadLine());
					
						
						Console.WriteLine("Ingrese el precio:");
						double Precio = Convert.ToDouble(Console.ReadLine());

						Console.WriteLine("¿Cuantos juegos va a comprar?");
						int Cantidad = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("¿Quieres  seguir comprando más juegos?");
						Console.WriteLine("Presiona Enter para continuar y no para detener");

					
						double total1 = compra.Calculo(Precio, Cantidad);

						total = total + total1;

						String p = Console.ReadLine();
						if (p == "no")
						{
							seguir = false;
							foreach (var juego in NombreJuego)
							{
								
								Console.WriteLine($"Los juegos que compro(No hay devolucion) :\n{juego} ");
							}
							Console.WriteLine($"su total a pagar es: ${total}");
						}
						else
						{
							seguir = true;
							crudCompra.AgregarDetallle(detalle);
						}
					}
						
					break;
			}
			Console.WriteLine("¿Quieres regresa al menu principal y poder realizar una compra?");
			Console.WriteLine("Escribe si para continuar o no para salir");
			var respuesta = Console.ReadLine();
			if (respuesta == "no")
			{
				continuar = false;
			}
			else
			{
				continuar = true;
			}
		}
		break;

	case 2:

		bool Continuar = true;
		while (Continuar)
		{
			Console.WriteLine("Menú Administrativo");
			Console.WriteLine("*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
			Console.WriteLine("Pulsa 1 Si Quieres Acceder a los Registros  Provedores");
			Console.WriteLine("Pulsa 2 Si Quieres Acceder a los Registros de Productos");
			Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
			int opcionesM = Convert.ToInt32(Console.ReadLine());

			switch (opcionesM)
			{
				case 1:
					Console.WriteLine("Menú Provedores");
					Console.WriteLine("************************************************");
					Console.WriteLine("Pulsa 1 Si Quieres Agregar Un Provedor");
					Console.WriteLine("Pulsa 2 Si Quieres Eliminar Un Provedor");
					Console.WriteLine("Pulsa 3 Si Quieres Actualizar Un Provedor");
					Console.WriteLine("Pulsa 4 Si Quieres Ver Los Proveedores que existen Un Provedor");
					Console.WriteLine("*************************************************");

					int Menu = Convert.ToInt32(Console.ReadLine());
					if (Menu == 1)
					{
						Console.WriteLine("Agregar Proveedor");
						Console.WriteLine("Ingrese el codigo del proveedor");
						proveedore.CodProveedor = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Ingrese el nombre del proveedor");
						proveedore.NombredelProveedor = Console.ReadLine();
						Console.WriteLine("Ingrese el contacto del proveedor");
						proveedore.Contacto = Convert.ToInt32(Console.ReadLine());
						crudP.Agregar(proveedore);
					}
					else if (Menu == 2)
					{
						Console.WriteLine("Ingresa un ID de un producto a eliminar");
						var Proveedor = crudP.BuscarProveedor(Convert.ToInt32(Console.ReadLine()));
						if (Proveedor == null)
						{
							Console.WriteLine("Ese proveedor no existe no existe");
						}
						else
						{
							Console.WriteLine("Producto que se va eliminar");
							Console.WriteLine($"Codigo : {Proveedor.CodProveedor} Nombre: {Proveedor.NombredelProveedor}  Contacto:{Proveedor.Contacto}");
							Console.WriteLine("El proveedor selecccionado es correcto?");
							Console.WriteLine("presiona 1 si es correcto.");
							var Lector = Convert.ToInt32(Console.ReadLine());
							if (Lector == 1)
							{
								var p = Convert.ToInt32(Proveedor.CodProveedor);
								Console.WriteLine(crudP.Eliminar(p));
							}
							else
							{
								Console.WriteLine("Inicia nuevamente");
							}
						}

					}
					else if (Menu == 3)
					{
						Console.WriteLine("Actualizar Proveedor");
						var actu = crudP.BuscarProveedor(Convert.ToInt32(Console.ReadLine()));
						if (actu == null)
						{
							Console.WriteLine("El producto no existe");
						}
						else
						{
							Console.WriteLine($"Codigo : {actu.CodProveedor} Nombre: {actu.NombredelProveedor}  Contacto:{actu.Contacto}");

							Console.WriteLine("Para actualizar El codigo presiona 1");

							Console.WriteLine("Para actuaalizar nombre presiona 2");

							Console.WriteLine("Para actualizar El Contacto presiona 3");

							var actualizar = Convert.ToInt32(Console.ReadLine());
							if (actualizar == 1)
							{
								Console.WriteLine("Ingrese el nuevo Codigo");
								actu.CodProveedor = Convert.ToInt32(Console.ReadLine());
							}
							else if (actualizar == 2)
							{
								Console.WriteLine("Ingrese El nuevo Nombre ");
								actu.NombredelProveedor = Console.ReadLine();
							}
							else
							{

								Console.WriteLine("Ingrese El nuevo numero de Contacto ");
								actu.Contacto = Convert.ToInt32(Console.ReadLine());
							}
							crudP.actualizarProovedor(actu, actualizar);
							Console.WriteLine("Actualizacion exitosa...");
						}


					}
					else
					{
						Console.WriteLine("Espere mientras Los datos se cargan desde la base de datos...");
						Console.WriteLine("------------------------------------------------");
						var lista = crudP.ListaDeProveedores();
						foreach (var item in lista)
						{
							Console.WriteLine($"Codigo : {item.CodProveedor} Nombre: {item.NombredelProveedor}  Contacto:{item.Contacto}");
						}
						Console.WriteLine("-------------------------------------------------");
					}
					Console.WriteLine("¿Quieres regresar al menu principal y poder seguir haciendo cambios en el registro");
					Console.WriteLine("Presiona Enter para continuar o no para salir");
					var b = Console.ReadLine();
					if (b == "no")
					{
						Continuar = false;
					}
					else
					{
						Continuar = true;
					}
					break;


				case 2:
					Console.WriteLine("Menú De los Productos");
					Console.WriteLine("***************************************************");
					Console.WriteLine("Pulsa 1 Si Quieres Agregar Un Producto");
					Console.WriteLine("Pulsa 2 Si Quieres Eliminar Un Producto");
					Console.WriteLine("Pulsa 3 Si Quieres Actualizar Un Producto");
					Console.WriteLine("Pulsa 4 Si Quieres ver Los Productos en existencia que existen ");
					Console.WriteLine("****************************************************");
					int Menu2 = Convert.ToInt32(Console.ReadLine());


					if (Menu2 == 1)
					{
						Console.WriteLine("Ingresa el nombre del videojuego");
						videojuego.NombreJuego = Console.ReadLine();

						Console.WriteLine("Ingresa el precio de el videojuego");
						videojuego.PreciodelJuego = Convert.ToDouble(Console.ReadLine());

						Console.WriteLine("Ingresa la clasificacion del videojuego");
						videojuego.Clasificacion = Console.ReadLine();

						Console.WriteLine("Ingresa el stock de el videojuego");
						videojuego.Stock = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine("Ingresa el codigo del el proovedor");
						videojuego.ProveedoresId = Convert.ToInt32(Console.ReadLine());

						cRU.agregar(videojuego);

					}
					else if (Menu2 == 2)
					{
						Console.WriteLine("Ingresa un ID de un producto a eliminar");
						var Videojuego = cRU.Videojuegoindividual(Convert.ToInt32(Console.ReadLine()));
						if (Videojuego == null)
						{
							Console.WriteLine("Ese VideoJuego  no existe no existe");
						}
						else
						{
							Console.WriteLine("Producto que se va eliminar");
							Console.WriteLine($"Nombre: {Videojuego.NombreJuego} Precio:{Videojuego.PreciodelJuego} Clasificacion{Videojuego.Clasificacion}");
							Console.WriteLine("El Videojuego selecccionado es correcto?");
							Console.WriteLine("presiona 1 si es correcto.");
							var Lector = Convert.ToInt32(Console.ReadLine());
							if (Lector == 1)
							{
								var p = Convert.ToInt32(Videojuego.Id);
								Console.WriteLine(cRU.ElinminarJuego(p));
							}
							else
							{
								Console.WriteLine("Inicia nuevamente");
							}
						}
					}
					else if (Menu2 == 3)
					{
						Console.WriteLine("Actualizar Videojuego");
						var game = cRU.Videojuegoindividual(Convert.ToInt32(Console.ReadLine()));
						if (game == null)
						{
							Console.WriteLine("El videojuego  no existe");
						}
						else
						{
							Console.WriteLine($"Nombre: {game.NombreJuego} Precio:{game.PreciodelJuego} Clasificacion{game.Clasificacion}");
							Console.WriteLine("Para actualizar El nombre presiona 1");
							Console.WriteLine("Para actuaalizar precio presiona 2");
							Console.WriteLine("Para actualizar La clasificacion presiona 3");
							var actualizar = Convert.ToInt32(Console.ReadLine());
							if (actualizar == 1)
							{
								Console.WriteLine("Ingrese el nuevo nombre");
								game.NombreJuego = Console.ReadLine();
							}
							else 
							{
								Console.WriteLine("Ingrese El nuevo precio ");
								game.PreciodelJuego = Convert.ToDouble(Console.ReadLine());
							}
							cRU.Actualizar(game, actualizar);
							Console.WriteLine("Actualizacion exitosa...");
						}
					}
					else 
					{ 
					   Console.WriteLine("Espere mientras Los datos se cargan desde la base de datos...");
						Console.WriteLine("------------------------------------------------");
						var lista = cRU.ListadeVideojuegos();
						foreach (var item in lista)
						{
							Console.WriteLine($"Nombre: {item.NombreJuego} Precio:{item.PreciodelJuego} Clasificacion{item.Clasificacion}");
						}
						Console.WriteLine("-------------------------------------------------");
					}

					Console.WriteLine("¿Quieres regresar al menu principal y poder seguir haciendo cambios en el registro?");
					Console.WriteLine("Presiona Enter para continuar o no para salir");
					var a = Console.ReadLine();
					if (a == "no")
					{
						Continuar = false;
					}
					else
					{
						Continuar = true;
					}

					break;
			}

			Console.WriteLine("¿Quieres regresar al menu principal");
			Console.WriteLine("Presiona Enter para continuar o no para salir");
			var respuesta= Console.ReadLine();
			if (respuesta == "no")
			{
				Continuar = false;
			}
			else
			{
				Continuar = true;
			}


		}
		break;


}
































#region proveedor
//CRUDProveedores crudP = new CRUDProveedores();

//Proveedore proveedore = new Proveedore();

//Console.WriteLine("Ingresa el codigo de el proveedor");
//proveedore.CodProveedor = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine("Ingresa el nombre de el proveedor");
//proveedore.NombredelProveedor = Console.ReadLine();

//Console.WriteLine("Ingresa el contacto de el proveedor");
//proveedore.Contacto = Convert.ToInt32(Console.ReadLine());

//crudP.Agregar(proveedore);








//Console.WriteLine("INGRESA EL ID DE BUSQUEDA");
//videojuego.Id = Convert.ToInt32(Console.ReadLine());
//int id = videojuego.Id;

//crudv.videojuegoindividual(id);
#endregion
#region registros

//Formasdepago fmp = new Formasdepago();
//CRUDFormaPago cfp = new CRUDFormaPago();

//Console.WriteLine("Ingresa el numero de tarjeta");
//fmp.NumerodeTargeta = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine("fechavecimi: ");
//fmp.FechadeVencimiento = Convert.ToDateTime(Console.ReadLine());

//Console.WriteLine("Codigo de seguridad: ");
//fmp.Cvv = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine("Ingrse su numero de usuario:  ");
//fmp.UsuarioId = Convert.ToInt32(Console.ReadLine());

//cfp.Agregar(fmp);

#endregion
















