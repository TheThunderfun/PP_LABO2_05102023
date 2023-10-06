using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ESistema
{
    Binario,
    Decimal
}

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

        public List<string> Operaciones { get { return operaciones; } }
        public Numeracion PrimerOperando { get { return primerOperando; } set => primerOperando = value; }
        public Numeracion SegundoOperando { get { return segundoOperando; } set => segundoOperando = value; }
        public Numeracion Resultado { get { return resultado; } }
        public static ESistema Sistema { get { return Calculadora.sistema; } set => Calculadora.sistema = value; }



         public Calculadora() 
        {
            
           this.operaciones= new List<string>();
          
        }

        static Calculadora()
        {
           Calculadora.sistema= ESistema.Decimal;
        }

        public Calculadora(string nombreAlumno)
        {
            this.nombreAlumno=nombreAlumno;
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
                        this.resultado=MapeaResultado(this.primerOperando.ValorNumerico + this.segundoOperando.ValorNumerico);
                    }
                    else
                    {
                        this.resultado=new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;
                case '-':
                    if (this.primerOperando == this.segundoOperando)
                    {
                        this.resultado = MapeaResultado(this.primerOperando.ValorNumerico - this.segundoOperando.ValorNumerico);
                    }
                    else
                    {
                        this.resultado = new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;
                case '*':
                    if (this.primerOperando == this.segundoOperando)
                    {
                        this.resultado = MapeaResultado(this.primerOperando.ValorNumerico * this.segundoOperando.ValorNumerico); ;
                    }
                    else
                    {
                        this.resultado = new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;
                case '/':
                    if (this.primerOperando == this.segundoOperando)
                    {
                        this.resultado = MapeaResultado(this.primerOperando.ValorNumerico / this.segundoOperando.ValorNumerico);
                    }
                    else
                    {
                        this.resultado = new SistemaDecimal(double.MinValue.ToString());
                    }
                    break;


            }
        }

        public void ActualizaHistorialDeOperaciones(char operador)
        {
            StringBuilder sb = new StringBuilder();

            
            sb.Append(Calculadora.Sistema.ToString());
            sb.Append(this.PrimerOperando.Valor);
            sb.Append(this.SegundoOperando.Valor);
            sb.Append(operador);
            this.operaciones.Add(sb.ToString());
        }
        public void EliminarHistorialDeOperaciones()
        {
            this.operaciones.Clear();
        }

        private Numeracion MapeaResultado(double valor)
        {
            if (Calculadora.Sistema == ESistema.Binario)
            {
                return new SistemaBinario(valor.ToString());
            }
            else
            {
                return new SistemaDecimal(valor.ToString());
            }
        } 


    }
}
