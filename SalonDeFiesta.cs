/*
 * Created by SharpDevelop.
 * User: estudiante
 * Date: 16/6/2025
 * Time: 14:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TP_Integrador
{
	/// <summary>
	/// Description of SalonDeFiesta.
	/// </summary>
	public class SalonDeFiesta
	{
		private ArrayList eventos;
		private ArrayList empleados;
		
		public SalonDeFiesta()
		{
			this.eventos= new ArrayList();
			this.empleados= new ArrayList();
		}
		
		// Metodos de manipulacion del array //
		
        public void AgregarEvento(Evento e)
        {
        	this.eventos.Add(e);
        }
        public void EliminarEvento(Evento e)
        {
            this.eventos.Remove(e);
        }
        public bool EsVaciaEventos()
        {
            return this.eventos.Count == 0;
        }
        public int CantidadEventos()
        {
            return this.eventos.Count;
        }
        public bool Existe(Persona p)
        {
            foreach (Evento e in this.eventos)
            {
                if (p == e.CLIENTE)
                {
                    return true;
                }
            }
            return false;
        }
        public Evento ObtenerEvento(Persona p)
        {
        	Evento ev= null;
        	
            foreach (Evento e in eventos)
            {	
                if (p == e.CLIENTE)
                    return e;
            }
            return ev;
        }
        public void VerEvento(Evento e)
         {
            if (this.Existe(e.CLIENTE))
            {
                Console.WriteLine("Los datos del evento son:");
                Console.WriteLine("Tipo: {0}", e.TIPO);
                Console.WriteLine("Fecha: {0}", e.FECHA.ToString("dd/MM/yyyy"));
                Console.WriteLine("Costo Total: {0}", e.COSTOTOTAL);
                Console.WriteLine("Seña: {0}", e.SENIA);
                Console.WriteLine("Cliente: {0} , DNI: {1}", e.CLIENTE.NOM_Y_APE,e.CLIENTE.DOCUMENTO);
                Console.WriteLine("Encargado: {0} , legajo: {1}", e.ENCARGADO.NOM_Y_APE,e.ENCARGADO.LEGAJO);
            }
            else
            {
                Console.WriteLine("El evento ingresado no existe.");
            }
        }
        
        public ArrayList EVENTOS
        {get {return this.eventos;}}
       
        
        //Metodos manipulacion de empleados//
        
        public void AgregarEmpleado(Empleado e)
        {this.empleados.Add(e);}
        
        public void EliminarEmpleado(Empleado e)
        {this.empleados.Remove(e);}
        
        public bool EsVaciaEmpleados()
        {return this.empleados.Count == 0;}
        
        public int CantidadEmpleados()
        {return this.empleados.Count;}
        
        public bool Existe(string legajo)
        {
            foreach(Empleado e in this.empleados)
            {
                if (legajo == e.LEGAJO)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void VerEmpleado(Empleado em)
        {
        	if (this.Existe(em.LEGAJO))
        	{
        		em.VerDatos();
        	}
        }
        
        public Empleado ObtenerEmpleado(string legajo)
        {
        	Empleado em = null;
        	
            foreach(Empleado e in empleados)
            {
                if (legajo == e.LEGAJO)
                    return e;
            }
            return em;
        }
        
        public ArrayList EMPLEADOS
        {get{return this.empleados;}}
       
    }
	
}
