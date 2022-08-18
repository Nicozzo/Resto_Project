using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Local : Servicio, IValidable
    {
        //ATRIBUTOS
        private int numeroMesa;
        private Mozo mozo;
        private int cantidadComensales;
        private decimal precioCubierto;

        //CONSTRUCTOR
        public Local(int id, Cliente cliente, DateTime fecha, CantidadPlatos cantidadPlatos, int numeroMesa, Mozo mozo, int cantidadComensales, decimal preciocubierto) : base(id, cliente, fecha, cantidadPlatos)
        {
            this.NumeroMesa = numeroMesa;
            this.Mozo = mozo;
            this.CantidadComensales = cantidadComensales;
            this.PrecioCubierto = precioCubierto;
        }

        //PROPERTYS
        public int NumeroMesa
        {
            get { return numeroMesa; }
            set { numeroMesa = value; }
        }

        public Mozo Mozo
        {
            get { return mozo; }
            set { mozo = value; }
        }

        public int CantidadComensales
        {
            get { return cantidadComensales; }
            set { cantidadComensales = value; }
        }

        public decimal PrecioCubierto
        {
            get { return precioCubierto; }
            set { precioCubierto = value; }
        }
        
        //VALIDACIONES
        public bool Validar()
        {
            return ValidarCantidadComensales() && ValidarNumeroDeMesa();
        }

        private bool ValidarCantidadComensales()
        {
            return Validaciones.MayorACero(cantidadComensales);
        }

        private bool ValidarNumeroDeMesa()
        {
            return Validaciones.MayorACero(numeroMesa);
        }
    }
}
