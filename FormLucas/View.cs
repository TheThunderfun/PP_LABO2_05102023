using Entidades;
using System.Runtime.CompilerServices;

namespace CalculadoraForm
{
    public partial class view : Form
    {
        private Calculadora calculadora;



        public view()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.cmbOperacion.DataSource = new char[] { '+', '-', '*', '/' };
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrimerOperador.Text = null;
            txtSegundoOperador.Text = null;
            lblResultado.Text = "Resultado:";

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cerrar lacalculadora ? ", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPrimerOperador.Text, "^[\\-]?[0-9]{0,15}([\\.][0-9][0-9])?$"))
            {
                MessageBox.Show("Erorr");
                txtPrimerOperador.Text = string.Empty;
            }
        }
        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSegundoOperador.Text, "^[\\-]?[0-9]{0,15}([\\.][0-9][0-9])?$"))
            {
                MessageBox.Show("Error");
                txtSegundoOperador.Text = string.Empty;
            }
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            char operador;
            calculadora.PrimerOperando =
            this.getOperador(this.txtPrimerOperador.Text);
            calculadora.SegundoOperando =
            this.getOperador(this.txtSegundoOperador.Text);
            operador = (char)this.cmbOperacion.SelectedItem;
            this.calculadora.Calcular(operador);
            this.calculadora.ActualizaHistorialDeOperaciones(operador);
            this.lblResultado.Text = $"Resultado:{calculadora.Resultado.Valor}"; this.MostrarHistorial();


        }


        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            Calculadora.Sistema = ESistema.Binario;
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            Calculadora.Sistema = ESistema.Decimal;

        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Numeracion getOperador(string value)
        {
            if (Calculadora.Sistema == ESistema.Binario)
            {
                return new SistemaBinario(value);
            }
            return new SistemaDecimal(value);
        }

        private void MostrarHistorial()
        {
            this.listBox1.DataSource = null;
            this.listBox1.DataSource =
            this.calculadora.Operaciones;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}