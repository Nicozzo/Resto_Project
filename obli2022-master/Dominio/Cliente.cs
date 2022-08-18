using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class Cliente : Persona, IEquatable<Cliente>, IValidable
    {
        //ATRIBUTOS
        private string mail;
        private string password;

        //PROPIEDADES
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        //CONSTRUCTOR
        public Cliente(string mail, string password, string nombre, string apellido) : base(nombre, apellido)
        {
            this.mail = mail;
            this.password = password;
        }

        //VALIDACIONES
        public bool Validar()
        {
            return 
                ValidarMail() && 
                ValidarPassword() && 
                base.Validar();
        }

        //VALIDA EL MAIL.
        //"System.ComponentModel.DataAnnotations" provee clases de atributos que
        //se usan para definir metadatos para controles de datos.
        //En este caso EmailAddressAtribute inicializa una nueva instancia de su clase
        //que valida direcciones de correo.
        public bool ValidarMail()
        {
            var testerDeEmail = new EmailAddressAttribute();
            bool exito = testerDeEmail.IsValid(this.mail);
            return exito;
        }

        //LLAMA A TODOS LOS METODOS PARA VALIDAR EL PASSWORD
        //LONGITUD DE PASSWORD, SI CONTIENE UNA MINUSCULA, UNA MAYUSCULA Y UN NUMERO.
        public bool ValidarPassword()
        {
            if (this.password.Length >= 6)
            {
                if (BuscarMinuscula())
                {
                    if (BuscarMayuscula())
                    {
                        if (BuscarNumero())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //VALIDA QUE EL PASSWORD TENGA AL MENOS UNA MINUSCULA.
        public bool BuscarMinuscula()
        {
            bool exito = false;
            int i = 0;
            do
            {
                char letra = this.password[i];
                if (letra >= 'a' && letra <= 'z')
                {
                    exito = true;
                }
                i++;
            } while (!exito && i < this.password.Length);
            return exito;
        }

        //VVALIDA QUE EL PASSWORD TENGA AL MENOS UNA MAYUSCULA.
        public bool BuscarMayuscula()
        {
            bool exito = false;
            int i = 0;
            do
            {
                char letra = this.password[i];
                if (letra >= 'A' && letra <= 'Z')
                {
                    exito = true;
                }
                i++;
            } while (!exito && i < this.password.Length);
            return exito;
        }

        //VALIDA QUE EL PASSWORD TENGA AL MENOS UN NUMERO.
        public bool BuscarNumero()
        {
            bool exito = false;
            int i = 0;
            do
            {
                char letra = this.password[i];
                if (letra >= '0' && letra <= '9')
                {
                    exito = true;
                }
                i++;
            } while (!exito && i < this.password.Length);
            return exito;
        }

        //EQUALS
        public bool Equals(Cliente unCliente)
        {
            return unCliente != null && Id == unCliente.Id;
        }

        //TOSTRING
        public override string ToString()
        {
            string cliente = "";
            cliente += $"APELLIDO: {base.Apellido}\n";
            cliente += $"NOMBRE:{base.Nombre}\n";
            cliente += $"ID: {base.Id}\n";
            cliente += $"EMAIL: {mail}\n";
            return cliente;
        }

    }
}
