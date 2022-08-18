using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Administrativa
    {
        //===================================LISTAS CON TODA LA INFORMACION===============================
        private List<Plato> platos = new List<Plato>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<Mozo> mozos = new List<Mozo>();
        private List<Repartidor> repartidores = new List<Repartidor>();
        private List<Local> locales = new List<Local>();
        private List<Delivery> deliverys = new List<Delivery>();
        private List<CantidadPlatos> cantidadPlatos = new List<CantidadPlatos>();

        public Administrativa()
        {
            PreCargaPlatos();
            PreCargaClientes();
            PreCargaMozos();
            PreCargaRepartidores();
            PreCargaServicios();
        }

        //===================================PRECARGA DE LOS DATOS===============================
        private void PreCargaPlatos()
        {
            //CASOS POSITIVOS
            CargarPlato(1, "Milanesa", 500);
            CargarPlato(2, "Hamburguesa", 250);
            CargarPlato(3, "Fideos con pesto", 200);
            CargarPlato(4, "Pollo al spiedo", 500);
            CargarPlato(5, "Lasagna", 400);
            CargarPlato(6, "Papas al horno", 600);
            CargarPlato(7, "Gramajo", 700);
            CargarPlato(8, "Nuggets", 200);
            CargarPlato(9, "Pizza con Muzzarella", 430);
            CargarPlato(10, "Chop Suey", 230);
            //CASOS CON ERROR
            CargarPlato(10, "Gramajo", 700); // ID IGUAL AL PLATO ANTERIOR
            CargarPlato(8, "Nuggets", 90); // PRECIO MENOR AL PRECIO MINIMO ESTABLECIDO (PRECMIN:$200)
            CargarPlato(9, "", 430); // PLATO SIN NOMBRE
        }

        private void PreCargaClientes()
        {
            //CASOS POSITIVOS
            CargarCliente("cliente1@gmail.com", "Ab.12345", "Alfredo", "Gomez");
            CargarCliente("cliente2@gmail.com", "Ab.12345", "Lorenzo", "Ansuate");
            CargarCliente("cliente3@gmail.com", "Ab.12345", "Beatriz", "Pereyra");
            CargarCliente("cliente4@gmail.com", "Ab.12345", "Fiorella", "Rodriguez");
            CargarCliente("cliente5@gmail.com", "Ab.12345", "Pepe", "Argento");
            //CASOS CON ERROR
            CargarCliente("cliente1gmail.com", "Ab.12345", "Alfredo", "Gomez");// MAIL SIN @
            CargarCliente("cliente2@gmail.com", "Ab.14", "Lorenzo", "Ansuate");// PASSWORD CON LONGITUD MENOR A 6
            CargarCliente("cliente3@gmail.com", "Ab.12345", "", "Pereyra");// CLIENTE SIN NOMBRE
        }

        private void PreCargaMozos()
        {
            //CASOS POSITIVOS
            CargarMozo("Raquel", "Suarez");
            CargarMozo("Ramon", "Fagundez");
            CargarMozo("Rosario", "Figueroa");
            CargarMozo("Raul", "Mauro");
            CargarMozo("Roman", "Couste");
            //CASOS NEGATIVOS
            CargarMozo("", "Mauro"); // SIN NOMBRE
            CargarMozo("Roman", "");// SIN APELLIDO
        }

        private void PreCargaRepartidores()
        {
            //CASOS POSITIVOS
            CargarRepartidor("Moto", "Federico", "Baston");
            CargarRepartidor("Bicicleta", "Nahuel", "Larrosa");
            CargarRepartidor("Pie", "Paola", "De los santos");
            CargarRepartidor("Bicicleta", "Penelope", "Cruz");
            CargarRepartidor("Moto", "Federico", "Baston");
            //CASOS NEGATIVOS
            CargarRepartidor("", "Federico", "Baston"); // SIN TIPO DE VEHICULO
            CargarRepartidor("Bicicleta", "", "Larrosa");// SIN NOMBRE
            CargarRepartidor("Pie", "Paola", "");// SIN APELLIDO
        }

        private void PreCargaServicios()
        {
            //CASOS POSITIVOS
            //Locales
            CantidadPlatos unaCantidad;

            Plato unPlato = BuscarPlato(2);
            Cliente unCliente = BuscarCliente(2);
            Mozo unMozo = BuscarMozo(9);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal(1, unCliente, new DateTime(2022, 07, 15), unaCantidad, 4, unMozo, 2, 70);

            unPlato = BuscarPlato(5);
            unCliente = BuscarCliente(5);
            unMozo = BuscarMozo(10);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarLocal(2, unCliente, new DateTime(2022, 08, 12), unaCantidad, 4, unMozo, 2, 70);

            unPlato = BuscarPlato(6);
            unCliente = BuscarCliente(2);
            unMozo = BuscarMozo(13);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarLocal(3, unCliente, new DateTime(2022, 04, 19), unaCantidad, 4, unMozo, 2, 70);


            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(1);
            unMozo = BuscarMozo(11);
            unaCantidad = CargarCantidadPlatos(unPlato, 5);
            CargarLocal(4, unCliente, new DateTime(2022, 07, 29), unaCantidad, 4, unMozo, 2, 70);

            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(5);
            unMozo = BuscarMozo(12);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal(5, unCliente, new DateTime(2022, 03, 20), unaCantidad, 4, unMozo, 2, 70);

            //Deliverys
            Repartidor unRepartidor;

            unRepartidor = BuscarRepartidor(16);
            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(3);
            unaCantidad = CargarCantidadPlatos(unPlato, 5);
            CargarDelivery(6, unCliente, new DateTime(2021, 01, 31), unaCantidad, "Rivera", unRepartidor, 10);

            unRepartidor = BuscarRepartidor(17);
            unPlato = BuscarPlato(4);
            unCliente = BuscarCliente(1);
            unaCantidad = CargarCantidadPlatos(unPlato, 8);
            CargarDelivery(7, unCliente, new DateTime(2022, 05, 21), unaCantidad, "18 de julio", unRepartidor, 15);

            unRepartidor = BuscarRepartidor(18);
            unPlato = BuscarPlato(2);
            unCliente = BuscarCliente(3);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarDelivery(8, unCliente, new DateTime(2022, 08, 12), unaCantidad, "Bulevar Artigas", unRepartidor, 30);

            unRepartidor = BuscarRepartidor(19);
            unPlato = BuscarPlato(5);
            unCliente = BuscarCliente(4);
            unaCantidad = CargarCantidadPlatos(unPlato, 1);
            CargarDelivery(9, unCliente, new DateTime(2022, 03, 24), unaCantidad, "Orinoco", unRepartidor, 50);

            unRepartidor = BuscarRepartidor(20);
            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(3);
            unaCantidad = CargarCantidadPlatos(unPlato, 8);
            CargarDelivery(10, unCliente, new DateTime(2022, 09, 10), unaCantidad, "Rivera", unRepartidor, 20);

            //CASOS NEGATIVOS

        }

        //===================================METODOS PARA CARGAR LOS OBJETOS===============================
        public bool CargarPlato(int id, string nombre, decimal precio)
        {
            Plato unPlato;
            unPlato = new Plato(id, nombre, precio);
            return AgregarPlato(unPlato);
        }

        public bool CargarCliente(string mail, string password, string nombre, string apellido)
        {
            Cliente unCliente;
            //If de agregar cliente
            unCliente = new Cliente(mail, password, nombre, apellido);
            return AgregarCliente(unCliente);
        }

        public bool CargarMozo(string nombre, string apellido)
        {
            Mozo unMozo;
            unMozo = new Mozo(nombre, apellido);
            return AgregarMozo(unMozo);
        }

        public bool CargarRepartidor(string tipoVehiculo, string nombre, string apellido)
        {
            Repartidor unRepartidor;
            unRepartidor = new Repartidor(tipoVehiculo, nombre, apellido);
            return AgregarRepartidor(unRepartidor);
        }

        public bool CargarDelivery(int id, Cliente UnCliente, DateTime unaFecha, CantidadPlatos unaCantidad, string Direccion, Repartidor unRepartidor, decimal distancia)
        {
            Delivery unDelivery;
            unDelivery = new Delivery(id, UnCliente, unaFecha, unaCantidad, Direccion, unRepartidor, distancia);
            return AgregarDelivery(unDelivery, unaCantidad);
        }

        public bool CargarLocal(int id, Cliente UnCliente, DateTime unaFecha, CantidadPlatos unaCantidad, int nuemroMesa, Mozo unMozo, int cantComensales, decimal precioCubierto)
        {
            Local unLocal;
            unLocal = new Local(id, UnCliente, unaFecha, unaCantidad, nuemroMesa, unMozo, cantComensales, precioCubierto);
            return AgregarLocal(unLocal, unaCantidad);
        }

        public CantidadPlatos CargarCantidadPlatos(Plato unPlato, int cantidad)
        {
            if (cantidad > 0)
            {
                CantidadPlatos unaCantidad;
                unaCantidad = new CantidadPlatos(cantidad, unPlato);
                return unaCantidad;
            }
            return null;
        }

        //===================================METODOS PARA AGREGAR OBJETOS EN LAS LISTAS===============================

        public bool AgregarPlato(Plato unPlato)
        {
            bool exito = false;
            if (unPlato != null && unPlato.Validar() && !platos.Contains(unPlato))
            {
                platos.Add(unPlato);
                exito = true;
            }
            return exito;
        }

        public bool AgregarDelivery(Delivery unDelivery, CantidadPlatos unaCantidad)
        {
            if (unDelivery != null && unaCantidad != null && !deliverys.Contains(unDelivery))
            {
                deliverys.Add(unDelivery);
                return true;
            }
            else
            {
                BuscarLocal(unDelivery.Id).AgregarPlato(unaCantidad);
            }
            return true;
        }

        public bool AgregarLocal(Local unLocal, CantidadPlatos unaCantidad)
        {
            if (unLocal != null && unLocal.Validar()  && unaCantidad != null && !locales.Contains(unLocal))
            {
                locales.Add(unLocal);
                return true;
            }
            else
            {
                BuscarLocal(unLocal.Id).AgregarPlato(unaCantidad);
            }
            return true;
        }

        public bool AgregarCliente(Cliente unCliente)
        {
            bool exito = false;
            if (unCliente != null && unCliente.Validar() && !clientes.Contains(unCliente))
            {
                clientes.Add(unCliente);
                exito = true;
            }
            return exito;
        }

        public bool AgregarMozo(Mozo unMozo)
        {
            bool exito = false;
            if (unMozo != null && unMozo.Validar() && !mozos.Contains(unMozo))
            {
                mozos.Add(unMozo);
                exito = true;
            }
            return exito;
        }

        public bool AgregarRepartidor(Repartidor unRepartidor)
        {
            bool exito = false;
            if (unRepartidor != null && unRepartidor.Validar() && !repartidores.Contains(unRepartidor))
            {
                repartidores.Add(unRepartidor);
                exito = true;
            }
            return exito;
        }

        //===================================METODOS PARA BUSCAR OBJETOS EN LAS LISTAS===============================

        //Busca un servicio local en la lista de los servicios locales
        public Local BuscarLocal(int id)
        {
            foreach (Local item in locales)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un cliente en la lista de los clientes
        public Cliente BuscarCliente(int id)
        {
            foreach (Cliente item in clientes)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un repartidor en la lista de los repartidores
        public Repartidor BuscarRepartidor(int id)
        {
            foreach (Repartidor item in repartidores)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un mozo en la lista de los mozos
        public Mozo BuscarMozo(int id)
        {
            foreach (Mozo item in mozos)
            {
                if (id == item.NumFuncionario)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un plato en la lista de los platos
        public Plato BuscarPlato(int id)
        {
            foreach (Plato item in platos)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un servicio de delivery en la lista de los deliverys
        //dependiendo de que repartidor lo entrego y entre que rango de fechas 
        //se realizo la entrega.
        public List<Delivery> BuscarServiciosDeRepartidor(Repartidor unRepartidor, DateTime inicial, DateTime final)
        {
            List<Delivery> aux = new List<Delivery>();
            foreach (Delivery item in deliverys)
            {
                if (item.Repartidor.Id == unRepartidor.Id && item.Fecha.CompareTo(inicial) == 1 && item.Fecha.CompareTo(final) == -1)
                {
                    aux.Add(item);
                }
            }

            if(aux.Count == 0)
            {
                return null;
            }
            else
            {
                return aux;
            }
            
        }

        //===================================METODOS QUE DEVUELVEN LISTAS===============================
        public List<Delivery> ListarDeliverys()
        {
            List<Delivery> aux = new List<Delivery>();
            foreach (Delivery item in deliverys)
            {
                aux.Add(item);
            }
            return aux;
        }

        public List<Local> ListarLocales()
        {
            List<Local> aux = new List<Local>();
            foreach (Local item in locales)
            {
                aux.Add(item);
            }
            return aux;
        }

        public List<Plato> ListarPlatos()
        {
            List<Plato> aux = new List<Plato>();
            foreach (Plato item in platos)
            {
                aux.Add(item);
            }

            if(aux.Count == 0)
            {
                return null;
            }
            return aux;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> aux = new List<Cliente>();
            foreach (Cliente item in clientes)
            {
                aux.Add(item);
            }

            if(aux.Count == 0)
            {
                return null;
            }
            else
            {
                aux.Sort();
                return aux;
            }
        }

        //===================================METODO QUE MODIFICA EL PRECIO MINIMO DE LOS PLATOS===============================
        public bool ModificarPrecio(decimal nuevoPrecio)
        {
            return Plato.ModificarPrecioMinimo(nuevoPrecio);
        }

        //====================================LISTAS DE TODOS LOS DATOS PRECARGADOS==========================
        public List<Mozo> ListarMozo()
        {
            List<Mozo> aux = new List<Mozo>();
            foreach (Mozo item in mozos)
            {
                aux.Add(item);
            }

            return aux;
        }

        public List<Repartidor> ListarRepartidores()
        {
            List<Repartidor> aux = new List<Repartidor>();
            foreach (Repartidor item in repartidores)
            {
                aux.Add(item);
            }
            return aux;
        }
    }
}
