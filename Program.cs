/*
 * Created by SharpDevelop.
 * User: estudiante
 * Date: 8/6/2025
 * Time: 14:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TP_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Evento creado a modo de simulación//
			
			
			Persona cliente = new Persona("Juan Pérez", "12345678");
			Encargado enc = new Encargado("Ana Gómez", "87654321", "E123", "encargado", 50000, 10000);
			DateTime fechaEvento = new DateTime(2025, 7, 15);
			string tipoEvento = "Cumpleaños";
			double costoTotal = 0;
			double senia = 1000;
			Evento even = new Evento(cliente, fechaEvento, enc, tipoEvento, costoTotal, senia);
			
			
			//Salon de fiesta a utilizar//
			
			
			SalonDeFiesta salon= new SalonDeFiesta();
			salon.AgregarEvento(even);
			salon.AgregarEmpleado(enc);
			
			bool flag= true;
			
			//Menu Principal controlado por "flag"//
			
			while (flag==true)
			{
				Console.WriteLine("-----------------------------------");
				Console.WriteLine("Elija una opción: ");
				Console.WriteLine("1- Agregar servicio");
				Console.WriteLine("2- Eliminar servicio");
				Console.WriteLine("3- Dar de alta un empleado");
				Console.WriteLine("4- Dar de alta un encargado");
				Console.WriteLine("5- Dar de baja un empleado");
				Console.WriteLine("6- Dar de baja un encargado");
				Console.WriteLine("7- Reservar salón para un evento");
				Console.WriteLine("8- Cancelar evento");
				Console.WriteLine("9- Submenú de impresión");
				Console.WriteLine("10- Salir");
				string opcion= Console.ReadLine();
				Console.WriteLine("-----------------------------------");
				
				switch (opcion)
				{
					case "1":
						{
							//Creo un evento vacio//
							
							Evento agregarSer= null;
							
							//Compruebo mediante el DNI del cliente que el evento se encuentra registrado//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el DNI del cliente del evento al que desea añadirle servicios:");
							string dni=Console.ReadLine();
							
							foreach (Evento ev in salon.EVENTOS)
							{
								Persona cl = ev.CLIENTE;
								
								if (dni == cl.DOCUMENTO)
								{
									agregarSer=ev;
									break;
								}
							}
							
							if (agregarSer==null)
							{
								Console.WriteLine("...");
								Console.WriteLine("El evento no ha sido encontrado.");
								break;
							}
							
							//Solicito los datos del servicio que quiero añadir//	
							
							string nom,desc;
							int cant;
							double costUnit;
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el nombre del servicio: ");
							nom=Console.ReadLine().ToLower();
							Console.WriteLine("...");
							Console.WriteLine("Ingrese la descripción del servicio: ");
							desc=Console.ReadLine();
							
							
							//Utilizo excepciones para asegurar que se ingrese un número válido.//
							
							try
							{
								Console.WriteLine("...");
								Console.WriteLine("Ingrese la cantidad del mismo servicio que desea agregar: ");
								cant=int.Parse(Console.ReadLine());
								if (cant<=0)
									throw new MenorOIgualACeroException();
							}
							catch(MenorOIgualACeroException)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado una cantidad menor o igual a cero, inténtelo de nuevo.");
								break;
							}
							catch(FormatException)
							{ 
								Console.WriteLine("...");
								Console.WriteLine("No ha ingresado un número.");
								break;
							}
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error");
								break;
							}
							
							
							try
							{
								Console.WriteLine("...");
								Console.WriteLine("Ingrese el costo unitario del servicio: ");
								costUnit=double.Parse(Console.ReadLine());
								if (costUnit<=0)
									throw new MenorOIgualACeroException();
							}
							catch(MenorOIgualACeroException)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado un número menor o igual a cero, inténtelo de nuevo.");
								break;
							}
							catch(FormatException)
							{
								Console.WriteLine("...");
								Console.WriteLine("No ha ingresado un número.");
								break;
							}
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error");
								break;
							}
							
							//Compruebo si el servicio ya se encuentra en el evento para no generar servicios con el mismo nombre//
							
							if (agregarSer.Existe(nom))
							{
								Console.WriteLine("...");
								Console.WriteLine("Ya hay un servicio con este nombre añadido al evento.");
								Console.WriteLine("Si desea realizar cambios, elimine el servicio y vuélvalo a añadir");
								break;
							}
							
							
							//Finalmente, añado el servicio al evento correspodiente y verifico un posible fallo//
							
							try
							{
								Servicio s= new Servicio(nom,desc,cant,costUnit);
								agregarSer.Agregar(s);
							}
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error al agregar el servicio.");
								break;
							}
							
							
							Console.WriteLine("...");
							Console.WriteLine("El servicio ha sido añadido correctamente");
							
							double total= costUnit*cant;
							double sen= 0.20*total;
							
							agregarSer.COSTOTOTAL+=total;
							agregarSer.SENIA+=sen;
							
							Console.WriteLine("...");
							Console.WriteLine("Ahora el costo total del evento es de: ${0}",agregarSer.COSTOTOTAL);
							Console.WriteLine("Y la seña a pagar es de: {0}", agregarSer.SENIA);
						
							break;
						}
						
					case "2":
						{
							//Creo un evento vacio//
							
							Evento eliminarSer=null;
							
							//Compruebo mediante el DNI del cliente que el evento se encuentra registrado//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el DNI del cliente del evento al que desea eliminarle servicios:");
							string dni=Console.ReadLine();
							
							foreach (Evento ev in salon.EVENTOS)
							{
								Persona cl= ev.CLIENTE;
								if (dni == cl.DOCUMENTO)
								{
									eliminarSer=ev;
									break;
								}
							}
							if (eliminarSer==null)
							{
								Console.WriteLine("...");
								Console.WriteLine("El evento no ha sido encontrado.");
								break;
							}
							
							
							//Utilizo el nombre para verificar que el servicio se encuentre registrado en el evento y si es asi, lo elimino//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el nombre del servicio que desea eliminar");
							string nom=Console.ReadLine().ToLower();
							
							Servicio SerAEliminar=eliminarSer.ObtenerServicio(nom);
							
							if (SerAEliminar==null)
							{
								Console.WriteLine("...");
								Console.WriteLine("El servicio no ha sido encontrado");
								break;
							}
							
							try
							{
								eliminarSer.Eliminar(SerAEliminar);
								
								//Le resto el valor del servicio al evento//
								
								double totalServicio = SerAEliminar.COSTUNITARIO * (double) SerAEliminar.CANTIDAD;
								
								eliminarSer.COSTOTOTAL-=totalServicio;
								eliminarSer.SENIA-=totalServicio*0.20;
							}
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error al eliminar el servicio.");
								break;
							}
							
							Console.WriteLine("...");
							Console.WriteLine("El servicio ha sido eliminado correctamente.");
							
							Console.WriteLine("...");
							Console.WriteLine("El nuevo costo del evento es: ${0}",eliminarSer.COSTOTOTAL);
							Console.WriteLine("Y la seña es de: ${0}", eliminarSer.SENIA);
							break;	
						}
						
					case "3":
						{
							//Utilizo el legajo para comprobar que el empleado no se encuentra ya en el arraylist//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el legajo del empleado que desea añadir: ");
							string leg= Console.ReadLine();
							
							if (salon.Existe(leg))
							{
								Console.WriteLine("...");
								Console.WriteLine("Ya se encuentra un empleado con ese legajo añadido.");
								break;
							}
							
							//Añado los demás datos de empleado//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el nombre completo del empleado: ");
							string nom=Console.ReadLine();
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el DNI del empleado: ");
							string dni= Console.ReadLine();
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el trabajo que realizará el empleado: ");
							string trab=Console.ReadLine().ToLower();
							
							double sue;
							
							//Utilizo excepciones para asegurar que se ingrese un número válido.//
							
							try
							{
								Console.WriteLine("...");
								Console.WriteLine("Ingrese el sueldo del empleado: ");
								sue=double.Parse(Console.ReadLine());
								if (sue<=0)
									throw new MenorOIgualACeroException();
							}
							catch(MenorOIgualACeroException)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado un número menor o igual a cero, inténtelo de nuevo.");
								break;
							}
							catch(FormatException)
							{
								Console.WriteLine("...");
								Console.WriteLine("No ha ingresado un número.");
								break;
							}
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error.");
								break;
							}
							
							
							//Aseguro que el empleado se añada de forma correcta.//
							
							try
							{
								Empleado emp= new Empleado(nom,dni,leg,trab,sue);
								salon.AgregarEmpleado(emp);
							}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error al añadir al empleado.");
								break;
							}
							
							Console.WriteLine("...");
							Console.WriteLine("El empleado se ha añadido correctamente.");
							
							break;
						}
					case "4":
						{
							//Utilizo el legajo para comprobar que el empleado no se encuentra ya en el arraylist//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el legajo del empleado que desea añadir: ");
							string leg= Console.ReadLine();
							
							if (salon.Existe(leg))
							{
								Console.WriteLine("...");
								Console.WriteLine("Ya se encuentra un empleado con ese legajo añadido.");
								break;
							}
							
							//añado los demás datos//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el nombre completo del encargado: ");
							string nom=Console.ReadLine();
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el DNI del encargado: ");
							string dni=Console.ReadLine();
							
							//Añado de forma predeterminada que su tipo de trabajo sea encargado.//
							
							string trab="encargado";
							
							//Utilizo excepciones para asegurar que se ingrese un número válido//
							
							double sue,psue;
							
							try
							{
								Console.WriteLine("...");
								Console.WriteLine("Ingrese el sueldo del encargado: ");
								sue=double.Parse(Console.ReadLine());
								
								if (sue<=0)
									throw new MenorOIgualACeroException();
							}
							
							catch(MenorOIgualACeroException)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado un número menor o igual a cero, inténtelo de nuevo.");
								break;
							}
							
							catch(FormatException)
							{
								Console.WriteLine("...");
								Console.WriteLine("No ha ingresado un número.");
								break;
							}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error.");
								break;
							}
							
							
							try
							{
								Console.WriteLine("...");
								Console.WriteLine("Ingrese el plus de sueldo. ej: 0.15 equivale al 15% de plus de sueldo.");
								psue=double.Parse(Console.ReadLine());
								
								if (psue<=0)
									throw new MenorOIgualACeroException();
							}
							
							catch(MenorOIgualACeroException)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado un número menor o igual a cero, inténtelo de nuevo.");
								break;
							}
							
							catch(FormatException)
							{
								Console.WriteLine("...");
								Console.WriteLine("No ha ingresado un número.");
								break;
							}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error.");
								break;
							}
							
							//Aseguro que el encargado se añada de forma correcta.//
							
							Encargado encar;
							
							try
							{
								encar= new Encargado(nom,dni,leg,trab,sue,psue);
								salon.AgregarEmpleado(encar);
							}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error al intentar añadir al encargado.");
								break;
							}
							
							
							Console.WriteLine("...");
							Console.WriteLine("El encargado ha sido añadido correctamente.");
							break;
						}
						
					case "5":
						{
							//Utilizo el legajo para comprobar que el empleado se encuentra ya en el arraylist//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el legajo del empleado que desea dar de baja: ");
							string leg= Console.ReadLine();
							
							if (!salon.Existe(leg))
							{
								Console.WriteLine("...");
								Console.WriteLine("No se encontró un empleado con ese legajo.");
								break;
							}
							
							Empleado emp= salon.ObtenerEmpleado(leg);
							
							if (emp==null)
							{
								Console.WriteLine("...");
								Console.WriteLine("No se pudo encontrar al empleado.");
								break;
							}
							
							//Verifico que el empleado no sea un encargado.//
							
							if(emp.TRABAJO =="encargado")
							{
								Console.WriteLine("...");
								Console.WriteLine("El empleado que desea dar de baja es un encargado, inténtelo con otra opción.");
								break;
							}
							
							//Elimino el empleado del arraylist.//
							
							try
							{salon.EliminarEmpleado(emp);}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error al intentar dar de baja al empleado.");
								break;
							}
							
							Console.WriteLine("...");
							Console.WriteLine("El empleado ha sido dado de baja correctamente.");
						
							break;
						}
					case "6":
						{
							//Utilizo el legajo para comprobar que el encargado se encuentra ya en el arraylist//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el legajo del encargado que desea dar de baja: ");
							string leg= Console.ReadLine();
							
							if (!salon.Existe(leg))
							{
								Console.WriteLine("...");
								Console.WriteLine("No se encontró un encargado con ese legajo.");
								break;
							}
							
							Empleado emp = salon.ObtenerEmpleado(leg);
							
							if (emp==null)
							{
								Console.WriteLine("...");
								Console.WriteLine("No se pudo encontrar al encargado.");
								break;
							}
							
							//Verifico que el empleado sea un encargado.//
							
							if(emp.TRABAJO !="encargado")
							{
								Console.WriteLine("...");
								Console.WriteLine("El empleado con este legajo no es un encargado.");
								break;
							}
							
							//Convierto de tipo empleado a tipo encargado.//
							
							Encargado encar = (Encargado) emp;
							
							//Compruebo y realizo algun cambio si es que el encargado pertenece ya a un evento//
							
							string rta= "n";
							bool AsignadoAEvento= false;
							bool PuedeEliminarse= true;
							
							
							foreach (Evento ev in salon.EVENTOS)
							{
								if(encar==ev.ENCARGADO)
								{
									AsignadoAEvento=true;	
									
									Console.WriteLine("...");
									Console.WriteLine("El encargado está asignado al siguiente evento: ");
									salon.VerEvento(ev);
									Console.WriteLine("...");
									Console.WriteLine("Si aún quiere darlo de baja debe añadir otro encargado para el evento.");
									Console.WriteLine("(Puede consultar la lista de encargados libres en el submenú de impresión)");
									Console.WriteLine("Desea dar de baja el encargado? s/n");
									try
									{rta=Console.ReadLine().ToLower();}
									catch
									{
										Console.WriteLine("...");
										Console.WriteLine("Ha ocurrido algún tipo de error.");
										break;
									}
									
									
									//Realizo el cambio de encargado//
									
									if (rta=="s")
									{
										Console.WriteLine("...");
										Console.WriteLine("Ingrese el legajo del nuevo encargado para el evento");
										string lega=Console.ReadLine();
										
										bool nuevoEncargado= false;
										
										foreach (Empleado emple in salon.EMPLEADOS)
										{
											bool seguir= true;
											
											if (emple.TRABAJO=="encargado" && lega==emple.LEGAJO)
											{
												foreach (Evento e in salon.EVENTOS)
												{
													Encargado actual= e.ENCARGADO;
													
													if (emple.LEGAJO==actual.LEGAJO)
													{
														Console.WriteLine("...");
														Console.WriteLine("El encargado que estás intentando añadir se encuentra ya asignado.");
														Console.WriteLine("Volviendo al menú principal...");
														seguir=false;
													}
												}
												
												if (!seguir)
												{
													PuedeEliminarse=false;
													break;
												}
												ev.ENCARGADO= (Encargado) emple;
												
												Console.WriteLine("...");
												Console.WriteLine("Se ha asignado el nuevo encargado correctamente.");
												nuevoEncargado=true;
												AsignadoAEvento=false;
												break;
											}
											if (nuevoEncargado)
												break;
										}
										
										if(!nuevoEncargado)
											Console.WriteLine("No se encontró al encargado.");
										break;
									}
									
								}
							}
							if (rta=="n")
							{
								Console.WriteLine("...");
								Console.WriteLine("Volviendo al menú principal...");
								break;
							}
							
							if (rta!="s")
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado algún valor inválido.");
								break;
							}
							
							if (AsignadoAEvento)
								break;
							
							if (!PuedeEliminarse)
								break;
							
							//Elimino al encargado del arraylist.//
							
							try
							{salon.EliminarEmpleado(encar);}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error al intentar dar de baja al encargado.");
								break;
							}
							
							Console.WriteLine("...");
							Console.WriteLine("El encargado ha sido dado de baja correctamente.");
							
							break;
						}
						
					case "7":
						{
							//Verifico que la fecha no se encuentre ocupada.//
							
							DateTime fec;
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese la fecha para reservar el salón. Formato: dd/mm/aaaa");
							Console.WriteLine("(Puede consultar en el submenú de impresión las fechas ocupadas.)");
							
							try
							{
								fec=DateTime.Parse(Console.ReadLine());
								
								foreach(Evento e in salon.EVENTOS)
								{
									if(e.FECHA.Date == fec.Date)
									{
										throw new FechaOcupadaException();
									}
								}
							}
							
							catch(FechaOcupadaException)
							{
								Console.WriteLine("...");
								Console.WriteLine("La fecha ingresada se encuentra actualmente ocupada por otro evento.");
								break;
							}
							
							catch(FormatException)
							{
								Console.WriteLine("...");
								Console.WriteLine("Los datos ingresados son inválidos.");
								break;
							}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error.");
								break;
							}
							
							//Pido los datos del cliente y verifico que no se encuentre en otro evento.//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el nombre completo del cliente: ");
							string nom=Console.ReadLine();
							
							
							string dni;
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el DNI del cliente");
							
							try
							{
								dni=Console.ReadLine();
								foreach (Evento ev in salon.EVENTOS)
								{
									Persona cl= ev.CLIENTE;
									if (cl.DOCUMENTO==dni)
										throw new ClienteAsignadoException();
								}
							}
							
							catch(ClienteAsignadoException)
							{
								Console.WriteLine("...");
								Console.WriteLine("Esta persona ya tiene reservado un evento.");
								Console.WriteLine("Solo puede haber una reserva por persona.");
								break;
							}
							
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error.");
								break;
							}
							
							Persona nuevoCliente= new Persona(nom,dni);
							Console.WriteLine("...");
							Console.WriteLine("Datos registrados correctamente.");
							
							//Asigno un encargado que se encuentre libre//
							
							Encargado encLibre= null;
							
							foreach (Empleado emp in salon.EMPLEADOS)
							{
								bool asignado=false;
								
								if (emp.TRABAJO=="encargado")
								{
									Encargado encar= (Encargado) emp;
									
									foreach(Evento ev in salon.EVENTOS)
									{
										if (encar==ev.ENCARGADO)
										{
											asignado=true;
											break;
										}
									}
									if (!asignado)
									{
										encLibre=encar;
										break;
									}
								}
							}
							
							if(encLibre==null)
							{
								Console.WriteLine("...");
								Console.WriteLine("No se encuentra ningún encargado libre.");
								break;
							}
							
							//Pedimos el tipo de evento//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el tipo de evento que realizará: ");
							string tipo= Console.ReadLine();
							
							//inicializo y añado el costo total y la seña en 0 para que aumente en otra opcion del menú//
							
							double cost=0;
							double sen=0;
							
							//Reservo el evento//
							
							try
							{
								Evento nuevoEvento= new Evento(nuevoCliente,fec,encLibre,tipo,cost,sen);
								salon.AgregarEvento(nuevoEvento);
							}
							catch(Exception)
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ocurrido un error al intentar reservar el evento.");
								break;
							}
							
							Console.WriteLine("...");
							Console.WriteLine("El evento ha sido reservado correctamente.");
							Console.WriteLine("Ahora use la opción del menú para agregar servicios.");
							Console.WriteLine("Luego podrá ver el costo total y la seña del evento en el submenú de impresión.");
							Console.WriteLine("Si ingresó algún dato erróneo, puede cancelar ya mismo el evento sin costo.");
							
							break;
						}
						
					case "8":
						{
							//Busco el evento mediante el dni del cliente.//
							
							Console.WriteLine("...");
							Console.WriteLine("Ingrese el DNI del cliente: ");
							string dni=Console.ReadLine();
							
							Evento eventoACancelar=null;
							
							foreach (Evento ev in salon.EVENTOS)
							{
								Persona cl=ev.CLIENTE;
								
								if(cl.DOCUMENTO==dni)
								{
									eventoACancelar=ev;
									break;
								}
							}
							
							if (eventoACancelar==null)
							{
								Console.WriteLine("...");
								Console.WriteLine("No se encontró ningún evento con ese DNI asignado");
								break;
							}
							
							//Calculo la diferencia de dias.//
							
							int diasDiferencia = (eventoACancelar.FECHA.Date - DateTime.Today).Days;
							
							string rta="s";
							
							//El evento tiene fecha en menos de un mes//
							
							if (diasDiferencia<30 && diasDiferencia>0)
							{
								Console.WriteLine("...");
								Console.WriteLine("El evento debe abonarse en su totalidad.");
								Console.WriteLine("Esto se debe a que falta menos de un mes para el evento.");
								Console.WriteLine("...");
								salon.VerEvento(eventoACancelar);
								Console.WriteLine("Desea cancelar el evento igualmente? s/n");
								rta=Console.ReadLine().ToLower();
								
								if (rta=="s")
								{
									Console.WriteLine("...");
									Console.WriteLine("El evento se abona completamente con el costo previamente mostrado.");
									
									try
									{salon.EliminarEvento(eventoACancelar);}
									
									catch(Exception)
									{
										Console.WriteLine("...");
										Console.WriteLine("Ha ocurrido un error al intentar cancelar el evento.");
										break;
									}
									
									Console.WriteLine("El evento ha sido cancelado exitosamente.");
									break;
									
								}
							}
							
							if (rta=="n")
							{
								Console.WriteLine("...");
								Console.WriteLine("Volviendo al menú...");
								break;
							}
							
							if (rta!="s")
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado un dato inválido.");
								break;
							}
							
							//El evento tiene fecha en más de un mes//
							
							if (diasDiferencia>30)
							{
								Console.WriteLine("...");
								Console.WriteLine("Deberá abonar la seña del evento para cancelarlo.");
								Console.WriteLine("Seña: ${0}", eventoACancelar.SENIA);
								Console.WriteLine("Desea cancelarlo igualmente? s/n");
								rta=Console.ReadLine().ToLower();
								
								if (rta=="s")
								{
									Console.WriteLine("...");
									Console.WriteLine("Se abonará la seña previamente mostrada.");
									
									try
									{salon.EliminarEvento(eventoACancelar);}
									
									catch(Exception)
									{
										Console.WriteLine("...");
										Console.WriteLine("Ha ocurrido un error al intentar cancelar el evento.");
										break;
									}
									
									Console.WriteLine("El evento ha sido cancelado exitosamente.");
									break;
								}
							}
							
							if (rta=="n")
							{
								Console.WriteLine("...");
								Console.WriteLine("Volviendo al menú...");
								break;
							}
							
							if (rta!="s")
							{
								Console.WriteLine("...");
								Console.WriteLine("Ha ingresado un dato inválido.");
								break;
							}
							
							//El evento ya ha pasado//
							
							if (diasDiferencia<=0)
							{
								Console.WriteLine("...");
								Console.WriteLine("El evento ya ha pasado, se eliminará de la lista de eventos.");
								try
								{salon.EliminarEvento(eventoACancelar);}
									
								catch(Exception)
									{
										Console.WriteLine("...");
										Console.WriteLine("Ha ocurrido un error al intentar eliminar el evento.");
										break;
									}
									
								Console.WriteLine("El evento ha sido eliminado exitosamente.");
								break;
							}
							
							break;
						}
					case "9":
						{
							//Realizo un submenu para imprimir datos en pantalla.//
							
							bool sub=true;
							
							while (sub==true)
							{
								Console.WriteLine("-----------------------------------");
								Console.WriteLine("Elija una opción de impresión: ");
								Console.WriteLine("1- Ver evento mediante DNI");
								Console.WriteLine("2- Ver listado de eventos con su tipo de evento, cliente y fecha");
								Console.WriteLine("3- Ver listado de empleados del salón");
								Console.WriteLine("4- Ver listado de encargados del salón");
								Console.WriteLine("5- Ver listado de encargados libres del salón");
								Console.WriteLine("6- Ver listado de eventos de un mes determinado");
								Console.WriteLine("7- Ver listado de servicios contratados de un evento");
								Console.WriteLine("8- Ver datos de un empleado/encargado mediante legajo");
								Console.WriteLine("9- Volver al menú principal");
								string op= Console.ReadLine();
								Console.WriteLine("-----------------------------------");
								
								switch (op)
								{
									case "1":
										{
											bool encontrado=false;
											
											Console.WriteLine("...");
											Console.WriteLine("Ingrese el DNI del cliente: ");
											string dni=Console.ReadLine();
											
											foreach (Evento e in salon.EVENTOS)
											{
												Persona cl=e.CLIENTE;
												
												if (cl.DOCUMENTO==dni)
												{
													salon.VerEvento(e);
													encontrado=true;
													break;
												}
											}
											
											if (!encontrado)
											{
												Console.WriteLine("...");
												Console.WriteLine("No se ha encontrado el cliente.");
												break;
											}
											
											Console.WriteLine("...");
											Console.WriteLine("Volviendo al submenú de impresión...");
											break;
										}
										
									case "2":
										{
											Console.WriteLine("...");
											
											if (salon.EsVaciaEventos())
											{
												Console.WriteLine("No hay ningún evento asignado al salón.");
												break;
											}
											
											foreach (Evento e in salon.EVENTOS)
											{
												Persona cl=e.CLIENTE;
												DateTime d= e.FECHA;
												
												Console.WriteLine("...");
												Console.WriteLine("tipo de evento: {0}", e.TIPO);
												Console.WriteLine("Nombre del cliente: {0}",cl.NOM_Y_APE);
												Console.WriteLine("DNI del cliente: {0}",cl.DOCUMENTO);
												Console.WriteLine("fecha del evento: {0}", d.Date);
											}
											
											break;
										}
										
									case "3":
										{
											if (salon.EsVaciaEmpleados())
											{
												Console.WriteLine("...");
												Console.WriteLine("El salón no tiene asignado ningún empleado");
												break;
											}
											
											foreach (Empleado emp in salon.EMPLEADOS)
											{
												Console.WriteLine("...");
												emp.VerDatos();
											}
											
											break;
										}
										
									case "4":
										{
											if (salon.EsVaciaEmpleados())
											{
												Console.WriteLine("...");
												Console.WriteLine("El salón no tiene asignado ningún empleado");
												break;
											}
											
											bool encontrado = false;
											
											foreach(Empleado emp in salon.EMPLEADOS)
											{
												if (emp.TRABAJO=="encargado")
												{
													salon.VerEmpleado(emp);
													encontrado=true;
												}
											}
											
											if (encontrado==false)
											{
												Console.WriteLine("...");
												Console.WriteLine("El salón no tiene asignado ningún encargado");
												break;
											}
											
											break;
										}
									case "5":
										{
											
											if (salon.EsVaciaEmpleados())
											{
												Console.WriteLine("...");
												Console.WriteLine("El salón no tiene asignado ningún empleado");
												break;
											}
											
											bool encontrado = false;
											
											foreach(Empleado emp in salon.EMPLEADOS)
											{
												if (emp.TRABAJO=="encargado")
												{
													bool estaAsignado=false;
													
													foreach (Evento e in salon.EVENTOS)
													{
														Encargado encar=e.ENCARGADO;
														if (encar.LEGAJO==emp.LEGAJO)
														{
															estaAsignado=true;
															break;
														}
															
													}
													
													if (!estaAsignado)
													{
														encontrado=true;
														Console.WriteLine("...");
														salon.VerEmpleado(emp);
													}
												}
											}
											
											if (!encontrado)
											{
												Console.WriteLine("...");
												Console.WriteLine("Todos los encargados actuales se encuentran asignados a algún evento.");
											}
											
											break;
										}
										
									case "6":
										{
											int mes;
											
											Console.WriteLine("...");
											Console.WriteLine("Ingrese el número del mes (1-12) para listar eventos del mismo:");
											
											try 
											{
												mes=int.Parse(Console.ReadLine());
												if (mes<=0 || mes > 12)
													throw new NumeroValidoException();
											}
											
											catch (NumeroValidoException)
											{
												Console.WriteLine("...");
												Console.WriteLine("Tiene que ingresar un número entre el 1 y el 12");
												break;
											}
											
											catch (FormatException)
											{
												Console.WriteLine("...");
												Console.WriteLine("Debe ingresar un número.");
												break;
											}
											
											catch(Exception)
											{
												Console.WriteLine("...");
												Console.WriteLine("Ha ocurrido un error");
												break;
											}
											
											bool eventoEncontrado= false;
											
											foreach (Evento ev in salon.EVENTOS)
											{
												if (ev.FECHA.Month==mes)
												{
													eventoEncontrado=true;
													Console.WriteLine("...");
													salon.VerEvento(ev);
												}
											}
											
											if (!eventoEncontrado)
											{
												Console.WriteLine("...");
												Console.WriteLine("No se encontró ningún evento que este organizado ese mes.");
												break;
											}
											
											break;
										}
									case "7":
										{
											bool encontrado=false;
											
											Console.WriteLine("...");
											Console.WriteLine("Ingrese el DNI del cliente del evento:");
											string dni=Console.ReadLine();
											
											foreach (Evento ev in salon.EVENTOS)
											{
												if (dni==ev.CLIENTE.DOCUMENTO)
												{
													encontrado=true;
													
													foreach (Servicio ser in ev.SERVICIOS)
													{
														Console.WriteLine("...");
														ev.VerServicio(ser);
													}
													break;
												}
											}
											
											if (!encontrado)
											{
												Console.WriteLine("...");
												Console.WriteLine("No se ha encontrado ningún evento asignado con este DNI.");
												break;
											}
											
											break;
										}
										
									case "8":
										{
											bool encontrado=false;
											
											Console.WriteLine("...");
											Console.WriteLine("Ingrese el legajo del empleado/encargado del que desea ver información");
											string leg=Console.ReadLine();
											
											foreach(Empleado emp in salon.EMPLEADOS)
											{
												if (leg==emp.LEGAJO)
												{
													encontrado=true;
													Console.WriteLine("...");
													salon.VerEmpleado(emp);
													break;
												}
											}
											
											if(!encontrado)
											{
												Console.WriteLine("...");
												Console.WriteLine("El empleado/encargado no ha sido encontrado.");
												break;
											}
											
											break;
										}
									case "9":
										{
											sub=false;
											break;
										}
								}
								
							}
						
							break;
						}
					case "10":
						{
							Console.WriteLine("Saliendo");
							flag=false;
							break;
						}
					default:
						{
							Console.WriteLine("La opción ingresada es inválida");
							break;
						}
					
				}
			}
		}
		
		public class NumeroValidoException: Exception
		{
			public NumeroValidoException()
			{}
		}
		public class MenorOIgualACeroException: Exception
		{
			public MenorOIgualACeroException()
			{}
		}
		
		public class FechaOcupadaException: Exception
		{
			public FechaOcupadaException()
			{}
		}
		
		public class ClienteAsignadoException: Exception
		{
			public ClienteAsignadoException()
			{}
		}
		
			
	}
}