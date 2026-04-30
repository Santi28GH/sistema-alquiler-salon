/*
 * Created by SharpDevelop.
 * User: estudiante
 * Date: 8/6/2025
 * Time: 15:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Servicio.
	/// </summary>
	public class Servicio
	{
		private string nombre;
        private string descripcion;
        private int cantidad;
        private double costunitario;
        
        //Constructor//

        public Servicio(string nomb, string desc, int cant, double costUnit)
        {
            this.nombre = nomb;
            this.descripcion = desc;
            this.cantidad = cant;
            this.costunitario = costUnit;
        }
        
        //Properties//
        
        public string NOMBRE
        {
            get{return this.nombre;}
            set{this.nombre = value;}
        }
        public string DESCRIPCION
        {
            get{return this.descripcion;}
            set{this.descripcion = value;}
        }
        public int CANTIDAD
        {
            get{return this.cantidad;}
            set{this.cantidad = value;}
        }
        public double COSTUNITARIO
        {
            get{return this.costunitario;}
            set{this.costunitario = value;}
        }
	}
}
