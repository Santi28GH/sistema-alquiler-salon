/*
 * Created by SharpDevelop.
 * User: estudiante
 * Date: 8/6/2025
 * Time: 15:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Evento.
	/// </summary>
	public class Evento
	{
		private Persona cliente;
		private DateTime fecha;
		private Encargado encargado;
		private string tipo;
		private double costoTotal, senia;
		private ArrayList servicios;
		
		//Constructor//
		
		public Evento(Persona cl, DateTime fec, Encargado enc, string tip, double costT,double sen)
		{
			this.cliente=cl;
			this.fecha=fec;
			this.encargado=enc;
			this.tipo=tip;
			this.costoTotal=costT;
			this.senia=sen;
			this.servicios= new ArrayList();
		}
		
		//Properties//
		
		public Persona CLIENTE
		{
			get{return this.cliente;}
			
			set{this.cliente=value;}
		}
		public DateTime FECHA
		{
			get{return this.fecha;}
			
			set{this.fecha=value;}
		}
		public Encargado ENCARGADO
		{
			get{return this.encargado;}
			
			set{this.encargado=value;}
		}
		public string TIPO
		{
			get{return this.tipo;}
			
			set{this.tipo=value;}
		}
		public double COSTOTOTAL
		{
			get{return this.costoTotal;}
			
			set{this.costoTotal=value;}
		}
		public double SENIA
		{
			get{return this.senia;}
			
			set{this.senia=value;}
		}
		
		//Métodos de manipulación del arraylist "servicios"//
		
		public void Agregar(Servicio s)
		{this.servicios.Add(s);}
		public void Eliminar(Servicio s)
		{this.servicios.Remove(s);}
		public bool EsVacia()
		{return this.servicios.Count==0;}
		public int Cantidad()
		{return this.servicios.Count;}
		public bool Existe(string nombre)
		{
			bool flag= false;
			
			foreach(Servicio s in this.servicios)
			{
				if(nombre==s.NOMBRE)
				{
					flag=true;
					break;
				}
				
			}
			return flag;
		
		}
		public void VerServicio(Servicio s)
		{
			if (this.Existe(s.NOMBRE))
			{
				Console.WriteLine("Los datos del servicio son los siguentes:");
				Console.WriteLine("Servicio de {0}",s.NOMBRE);
				Console.WriteLine("Es un {0}",s.DESCRIPCION);
				Console.WriteLine("La cantidad del mismo contratada es {0}", s.CANTIDAD);
				Console.WriteLine("El costo unitario del servicio es de {0}", s.COSTUNITARIO);
			}
			else {Console.WriteLine("El servicio ingresado no existe");}
			
		}
		public Servicio ObtenerServicio(string nombre)
		{
			Servicio ser= null;
			
			foreach(Servicio s in servicios)
			{
				if (nombre==s.NOMBRE)
					return s;
			}
			return ser;
		}
		public ArrayList SERVICIOS
		{get{return this.servicios;}}
	
	
	}
}
