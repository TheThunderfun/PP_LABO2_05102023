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
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar la aplicacion?", "Cerrar", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.No)
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
            this.GetOperador(this.txtPrimerOperando.Text);
            calculadora.SegundoOperando =
            this.GetOperador(this.txtSegundoOperando.Text);
            operador = (char)this.cmbOperacion.SelectedItem;
            this.calculadora.Calcular(operador);
            this.calculadora.ActualizaHistorialDeOperaciones(operador)
            ;
            this.lblResultado.Text = $"Resultado:{calculadora.Resultado.Valor}"; this.MostrarHistorial();


        }

        private void setResultado()
        {
            if (rdbBinario.Checked == true && string.IsNullOrEmpty(txtPrimerOperador.Text) == false && string.IsNullOrEmpty(txtSegundoOperador.Text) == false)
            {
                lblResultado.Text = $"Resultado:{resultado.ConvertirA(Numeracion.ESistema.Binario)}";
            }
            else if (rdbDecimal.Checked == true && string.IsNullOrEmpty(txtPrimerOperador.Text) == false && string.IsNullOrEmpty(txtSegundoOperador.Text) == false)
            {
                lblResultado.Text = $"Resultado:{resultado.valor}";
            }
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

        private void MostrarHistorial() 
        {
            this.lstHistorial.DataSource = null;
            this.lstHistorial.DataSource =
            this.calculadora.Operaciones;

        }
    }
}