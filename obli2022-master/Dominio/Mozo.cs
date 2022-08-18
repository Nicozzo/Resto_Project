using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Mozo : Persona, IEquatable<Mozo>, IValidable
    {
        //NUMFUNCIONARIO AUTO NUMERICO
        private static int numFuncionarioAuto = 0;

        //ATRIBUTOS
        private int numFuncionario;

        //PROPERTYS
        public int NumFuncionario
        {
            get { return numFuncionario; }
            set { numFuncionario = value; }
        }

        //CONSTRUCTOR
        public Mozo(string nombre, string apellido) : base(nombre, apellido)
        {
            this.numFuncionario = ++numFuncionarioAuto;
        }

        //VALIDACIONES
        public bool Validar()
        {
            return base.Validar();
        }

        //TOSTRING
        public override string ToString()
        {
            return $" {base.Apellido} {base.Nombre} {base.Id} Funcionario Numero : {numFuncionario}";
        }

        //EQUALS
        public bool Equals(Mozo unMozo)
        {
            return unMozo != null && numFuncionario == unMozo.numFuncionario;
        }
    }
}
