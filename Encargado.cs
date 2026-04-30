/*
 * Created by SharpDevelop.
 * User: estudiante
 * Date: 8/6/2025
 * Time: 15:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Encargado.
	/// </summary>
	public class Encargado: Empleado
	{
	    private double Psueldo;
	    
	    //Constructor//

        public Encargado(string nomyape, string dni, string leg, string tjo, double sue, double plusSueldo): base(nomyape, dni, leg, tjo, sue)
        {
            this.Psueldo = plusSueldo;
        }
        
        //Properties//
        
        public double PSUELDO
        {
            get{return this.Psueldo;}
            set{this.Psueldo = value;}
        }
        
		public override void VerDatos()
		{
			base.VerDatos();
			Console.WriteLine("Al ser encargado, tiene un aumento de sueldo de: {0}",this.Psueldo);
		}
	}
}
