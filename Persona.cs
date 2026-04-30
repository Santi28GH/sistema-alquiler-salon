/*
 * Created by SharpDevelop.
 * User: estudiante
 * Date: 8/6/2025
 * Time: 14:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
	{
		protected string nom_y_ape;
		protected string documento;
		
		//Constructor//
		
		public Persona(string nomyape, string dni)
		{
			this.nom_y_ape=nomyape;
			this.documento=dni;
		}
		
		//Properties//
		
		public string NOM_Y_APE
		{
			get{return this.nom_y_ape;}
			
			set{this.nom_y_ape=value;}
		}
		
		public string DOCUMENTO
		{
			get{return this.documento;}
			
			set{this.documento=value;}
		}
		
		
	}
}
