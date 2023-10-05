using Entidades;
namespace CalculadoraForm
{
    public partial class Form1 : Form
    {
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private Numeracion.ESistema sistema = Numeracion.ESistema.Decimal;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cmbOperacion.Items.Add('+');
            cmbOperacion.Items.Add('-');
            cmbOperacion.Items.Add('/');
            cmbOperacion.Items.Add('*');
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
            if (string.IsNullOrEmpty(txtPrimerOperador.Text) == false && string.IsNullOrEmpty(txtSegundoOperador.Text) == false)
            {
                primerOperando = new Numeracion(txtPrimerOperador.Text, sistema);
                segundoOperando = new Numeracion(txtSegundoOperador.Text, sistema);
                calculadora = new Operacion(primerOperando, segundoOperando);
                char operador = Convert.ToChar(cmbOperacion.SelectedItem);

                resultado = calculadora.Operar(operador);
                setResultado();
            }
            else
            {
                lblResultado.Text = "Numero invalido";
            }

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
            if (rdbBinario.Checked == true)
            {
                setResultado();
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked == true)
            {
                setResultado();
            }
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}