using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Entidades
{

    public abstract class Numeracion
    {
        protected private string msgError;
        protected string valor;

        public string Valor
        {
            get { return valor; }
        }

        internal abstract double ValorNumerico { get; }


        protected Numeracion(string valor):this()
        {
            InicializarValor(valor);
        }

        private Numeracion()
        {
            this.msgError = "Numero Invalido";
        }
    
        private void InicializarValor(string valor)
        {
            if (EsNumeracionValida(valor) == true)
            {
                this.valor = valor;
            }
            else
            {
                this.valor = msgError;     
            }
        }

        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistema);


        protected bool EsNumeracionValida(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
     


        public static bool operator !=(Numeracion numeracion1, Numeracion numeracion2)
        {
            return !(numeracion1 == numeracion2);
        }

        public static bool operator ==(Numeracion numeracion1, Numeracion numeracion2)
        {
            bool retorno=false;

            if (numeracion1!=null && numeracion2!=null && numeracion1.GetType()==numeracion2.GetType())
            {
                retorno=true;
            }

            return retorno;
        }

        static public explicit operator double (Numeracion numeracion) {

            return Convert.ToDouble(numeracion.valor);
        }
        
    }
}