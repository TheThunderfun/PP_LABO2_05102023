using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private static ESistema sistema;

        public string NombreAlumno
        {
            get { return nombreAlumno; }
            set { }
        }

        public List<string> Operaciones { get => operaciones;}
        public Numeracion PrimerOperando { get => primerOperando; set => primerOperando = value; }
        public Numeracion SegundoOperando { get => segundoOperando; set => segundoOperando = value; }
        public Numeracion Resultado { get => resultado; }
        public ESistema Sistema { get => sistema; set => sistema = value; }

        public void ActualizaHistorialDeOperaciones(char operador)
        {

        }

        public Calculadora()
        {
            this.Sistema = ESistema.Decimal;
        }

        private Calculadora()
        {

        }

        public Calculadora(string nombreAlumno)
        {

        }

        public void Calcular()
        {
            this.Calcular('+');
        }
        public void Calcular(char operador)
        {
            switch (operador)
            {
                case '+':
                    if (this.primerOperando == this.segundoOperando)
                    {
                        this.resultado=new SistemaDecimal((this.primerOperando.ValorNumerico + this.segundoOperando.ValorNumerico).ToString());
                    }
                    else
                    {
                        this.resultado=new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;
                case '-':
                    if (this.primerOperando == this.segundoOperando)
                    {
                        this.resultado = new SistemaDecimal((this.primerOperando.ValorNumerico - this.segundoOperando.ValorNumerico).ToString());
                    }
                    else
                    {
                        this.resultado = new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;
                case '*':
                    if (this.primerOperando == this.segundoOperando)
                    {
                        this.resultado = new SistemaDecimal((this.primerOperando.ValorNumerico * this.segundoOperando.ValorNumerico).ToString());
                    }
                    else
                    {
                        this.resultado = new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;
                case '/':
                    if (this.primerOperando == this.segundoOperando)
                    {
                        this.resultado = new SistemaDecimal((this.primerOperando.ValorNumerico / this.segundoOperando.ValorNumerico).ToString());
                    }
                    else
                    {
                        this.resultado = new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;


            }
        }

        public void EliminarHistorialDeOperaciones()
        {

        }

        private Numeracion MapeaResultado(double valor)
        {
            return new Numeracion(valor); 
        } 


    }
}
