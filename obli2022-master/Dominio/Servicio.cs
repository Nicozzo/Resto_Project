using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Servicio : IEquatable<Servicio>
    {
        //ATRIBUTOS
        private int id;
        private Cliente cliente;
        private DateTime fecha;
        private List<CantidadPlatos> cantidadPlatos = new List<CantidadPlatos>();

        //CONSTRUCTOR
        protected Servicio(int id, Cliente cliente, DateTime fecha, CantidadPlatos cantPlatos)
        {
            this.id = id;
            this.cliente = cliente;
            this.fecha = fecha;
            AgregarPlato(cantPlatos);
        }

        //PROPERTYS
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        
        public CantidadPlatos ObtenerCantidad(CantidadPlatos cantidad)
        {
            foreach (CantidadPlatos item in cantidadPlatos)
            {
                if (item.Plato.Id == cantidad.Plato.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //AGREGA EL PLATO A LA LISTA DE CANTIDAD DE PLATOS SI
        //NO ESTA. SI ESTA SE AGREGA LA CANTIDAD
        public bool AgregarPlato(CantidadPlatos cantPlato)
        {
            bool exito = true;
            CantidadPlatos aux = ObtenerCantidad(cantPlato);
            if (aux == null)
            {
                cantidadPlatos.Add(cantPlato);
            }
            else
            {
                aux.Cantidad += cantPlato.Cantidad;
            }

            return exito;
        }

        //EQUALS
        public bool Equals(Servicio unServicio)
        {
            return unServicio != null && Id == unServicio.id;
        }

        //TOSTRING
        public override string ToString()
        {
            return $"CLIENTE: {cliente.Nombre}\nPLATO: {cantidadPlatos[0].Plato}\nCANTIDAD: {cantidadPlatos[0].Cantidad}\nTOTAL: {cantidadPlatos[0].Plato.Precio * cantidadPlatos[0].Cantidad}\nFECHA: {fecha}";
        }

    }
}
