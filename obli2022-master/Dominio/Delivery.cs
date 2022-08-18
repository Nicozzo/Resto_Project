using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Delivery : Servicio, IValidable
    {
        //ATRIBUTOS
        private string direccion;
        private Repartidor repartidor;
        private decimal distancia;

        //CONSTRUCTOR
        public Delivery(int id, Cliente cliente, DateTime fecha, CantidadPlatos cantidadPlatos, string Direccion, Repartidor repartidor, decimal distancia) : base(id, cliente, fecha, cantidadPlatos)
        {
            this.Direccion = direccion;
            this.Repartidor = repartidor;
            this.Distancia = distancia;
        }

        //PROPERTYS
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Repartidor Repartidor
        {
            get { return repartidor; }
            set { repartidor = value; }
        }

        public decimal Distancia
        {
            get { return distancia; }
            set { distancia = value; }
        }

        //VALIDACIONES
        public bool Validar()
        {
            return ValidarDireccion() && ValidarDistancia();
        }

        private bool ValidarDireccion()
        {
            return Validaciones.ValidarTexto(this.direccion);
        }

        private bool ValidarDistancia()
        {
            return Validaciones.MayorACero((int)distancia);
        }

        //TOSTRING
        public override string ToString()
        {
            return $"FECHA: {base.Fecha.ToShortDateString()} NOMBRE REPARTIDOR: {repartidor.Nombre}"; 
        }
    }
}
