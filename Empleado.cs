/*
 * Created by SharpDevelop.
 * User: estudiante
 * Date: 8/6/2025
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Empleado.
	/// </summary>
	public class Empleado: Persona
	{
		protected string legajo,trabajo;
		protected double sueldo;
		
		//Constructor//
		
		public Empleado(string nomyape,string dni,string leg,string tjo, double sue) : base (nomyape,dni)
		{
			this.legajo=leg;
			this.trabajo=tjo;
			this.sueldo=sue;
		}
		
		//Properties//
		
		public string LEGAJO
		{
			get{return this.legajo;}
			
			set{this.legajo=value;}
		}
		
		public string TRABAJO
		{
			get{return this.trabajo;}
			
			set{this.trabajo=value;}
		}
		public double SUELDO
		{
			get{return this.sueldo;}
			
			set{this.sueldo=value;}
		}
		
		public virtual void VerDatos()
		{
			Console.WriteLine("Los Datos del empleado son: ");
			Console.WriteLine("Nombre Completo: {0}", this.nom_y_ape);
			Console.WriteLine("DNI: {0}",this.documento);
			Console.WriteLine("Legajo: {0}", this.legajo);
			Console.WriteLine("Trabajo: {0}",this.trabajo);
			Console.WriteLine("Sueldo: {0}",this.sueldo);
		}
	}
}
