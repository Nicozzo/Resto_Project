using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Repartidor : Persona, IEquatable<Repartidor>, IValidable
    {
        //ATRIBUTOS
        private string tipoDeVehiculo;

        //PROPERTYS
        public string TipoDeVehiculo
        {
            get { return tipoDeVehiculo; }
            set { tipoDeVehiculo = value; }
        }

        //CONSTRUCTOR
        public Repartidor(string tipoDeVehiculo, string nombre, string apellido) : base(nombre, apellido)
        {
            this.tipoDeVehiculo = tipoDeVehiculo;
        }

        //VALIDACIONES
        public bool Validar()
        {
            return
                base.Validar() &&
                ValidarTipoVehiculo();
        }

        private bool ValidarTipoVehiculo()
        {
            return this.tipoDeVehiculo == "Moto" ||
                    this.tipoDeVehiculo == "Bicicleta" ||
                    this.tipoDeVehiculo == "Pie";
        }

        //EQUALS
        public bool Equals(Repartidor unRepartidor)
        {  
            return unRepartidor != null && Id == unRepartidor.Id;
        }

        //TOSTRING
        public override string ToString()
        {
            return $"{base.Apellido} {base.Nombre} {base.Id} TIPO : {tipoDeVehiculo}";
        }
    }
}
