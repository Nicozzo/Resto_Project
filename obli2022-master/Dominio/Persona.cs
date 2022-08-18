using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
            public abstract class Persona : IComparable<Cliente>, IValidable
    {
                //ID AUTONUMERICO
                private static int idAuto = 0;

                //ATRIBUTOS
                private int id;
                private string nombre;
                private string apellido;

                //PROPERTYS
                public int Id
                {
                    get { return id; }
                    set { id = value; }
                }

                public string Nombre
                {
                    get { return nombre; }
                    set { nombre = value; }
                }

                public string Apellido
                {
                    get { return apellido; }
                    set { apellido = value; }
                }

                //CONSTRUCTOR
                public Persona(string nombre, string apellido)
                {
                    this.id = ++idAuto;
                    this.nombre = nombre;
                    this.apellido = apellido;
                }

                //VALIDACIONES
                public bool Validar()
                {
                    return ValidarNombrePersona() && ValidarApellido();
                }

                private bool ValidarNombrePersona()
                {
                    return Validaciones.ValidarTexto(this.nombre) && EncontrarNumero(this.Nombre);
                }

                public bool ValidarApellido()
                {
                    return Validaciones.ValidarTexto(this.apellido) && EncontrarNumero(this.apellido);
                }

                //CERCIORA QUE UN TEXTO NO TENGA NUMEROS.
                public bool EncontrarNumero(string palabra)
                {
                    bool exito = true;
                    int i = 0;
                    do
                    {
                        char letra = palabra[i];
                        if (letra >= '0' && letra <= '9')
                        {
                            exito = false;
                        }
                        i++;
                    } while (exito && i < palabra.Length);

                    return exito;
                }

                //COMPARA LOS CLIENTES POR APELLIDO
                //SI EL APELLIDO EMPIEZA POR LA MISMA LETRA
                //LOS ORDENA POR NOMBRE
                public int CompareTo(Cliente unCliente)
                {
                    int orden = Apellido.CompareTo(unCliente.Apellido);
                    if (orden == 0)
                    {
                        orden = Nombre.CompareTo(unCliente.Nombre);
                    }
                    return orden;
                }

            }
     } 
  

