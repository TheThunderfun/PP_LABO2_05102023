using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {
        internal override double ValorNumerico
        {
            get { return Convert.ToDouble(base.Valor); }
        }
        public SistemaBinario(string valor) : base(valor)
        {
            
        }
        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (sistema == ESistema.Binario)
            {
                return new SistemaBinario(base.Valor);
            }
            else
            {
                return new SistemaDecimal(base.Valor);
            }
        }

        protected bool EsNumeracionValida(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) == false && EsSistemaBinarioValido(valor) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private SistemaDecimal BinarioADecimal()
        {
            if (EsNumeracionValida(this.Valor)==true) 
            {
                return new SistemaDecimal(this.Valor);
            }
            else
            {
                return new SistemaDecimal(double.MinValue.ToString());
            }
        }

        public bool EsSistemaBinarioValido(string valor)
        {

            foreach (char c in valor)
            {
                if (c != '0' || c != '1')
                {
                    return false;
                }

            }

            return true;
        }


        public static implicit operator SistemaBinario (string valor) {
            return new SistemaBinario(valor);
        }

    }
}
