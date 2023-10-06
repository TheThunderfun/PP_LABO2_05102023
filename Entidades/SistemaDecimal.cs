using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {
        public SistemaDecimal(string valor) : base(valor)
        {
            
        }

        internal override double ValorNumerico
        {
            get { return Convert.ToDouble(base.Valor); }
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
            if (string.IsNullOrWhiteSpace(valor) == false && EsSistemaDecimalValido(valor) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private SistemaBinario DecimalABinario()
        {
            string binary = string.Empty;
            if (this.ValorNumerico > 0 && EsNumeracionValida(this.valor)==true)
            {
                double valorBinario = this.ValorNumerico;
                double remainder;


                while (valorBinario > 0)
                {
                    remainder = valorBinario % 2;
                    valorBinario /= 2;
                    binary = remainder.ToString() + binary;
                }
            }
            return new SistemaBinario(binary);
        }

        private bool EsSistemaDecimalValido(string valor)
        {
            double tryParse;

            if (double.TryParse(valor, out tryParse) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static public implicit operator SistemaDecimal(double valor)
        {
            return new SistemaDecimal(valor.ToString());
        }
        static public implicit operator SistemaDecimal(string valor)
        {
            return new SistemaDecimal(valor);
        }
    }
}
