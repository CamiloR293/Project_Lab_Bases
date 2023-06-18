using Streaming.logica;
using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Streaming
{
    public partial class AgregarTarjeta : Form
    {   
        Panel panelContainer = new Panel();
        Cliente cliente;
        Form registerClient = null;
        private String txtUsuario;
        private String txtPNombre;
        private String txtPApellido;
        private String txtSNombre;
        private String txtSApellido;
        private String txtPasswordRegistro;
        private String txtFechaNacimiento;
        private String txtTelefono;
        private String txtCorreo;

        public AgregarTarjeta(Panel panelContainer, Form register,String txtUsuario, String txtPNombre, String txtPApellido,
                String txtSNombre, String txtSApellido, String txtPasswordRegistro, String txtFechaNacimiento, String txtTelefono
                , String txtCorreo)
        {
            InitializeComponent();
            this.txtCorreo = txtCorreo;
            this.txtFechaNacimiento = txtFechaNacimiento;
            this.txtPApellido = txtPApellido;
            this.txtPNombre = txtPNombre;
            this.txtSApellido = txtSApellido;
            this.txtSNombre = txtSNombre;
            this.txtPasswordRegistro = txtPasswordRegistro;
            this.txtTelefono = txtTelefono;
            this.txtUsuario = txtUsuario;
            this.panelContainer = panelContainer;
            registerClient = register;
            btnRegistrar.Visible = false;
            btnRegistrarme.Visible = true;
            picBoxReturnTo.Visible = true;
            bloquearBoton();
            cmbBoxTipoTarjeta.SelectedIndex = 0;//inicializar combobox
        }
        public AgregarTarjeta (Cliente cliente)
        {
            this.cliente = cliente;

            InitializeComponent();
            btnRegistrar.Visible = true;
            btnRegistrarme.Visible = false;
            picBoxReturnTo.Visible = false;
            bloquearBoton();
            cmbBoxTipoTarjeta.SelectedIndex = 0;//inicializar combobox
        }

        public AgregarTarjeta()
        {
            InitializeComponent();
            btnRegistrar.Visible = true;
            btnRegistrarme.Visible = false;
            picBoxReturnTo.Visible = false;
            bloquearBoton();
            cmbBoxTipoTarjeta.SelectedIndex = 0;//inicializar combobox
        }

        public void bloquearBoton()
        {
            // Manejar el evento TextChanged para cada caja de texto
            txtNombre.TextChanged += VerificarCamposTexto;
            txtNumero.TextChanged += VerificarCamposTexto;
            txtFechaExpedicion.TextChanged += VerificarCamposTexto;
            txtCVV.TextChanged += VerificarCamposTexto;

            btnRegistrar.Enabled = false;//inhabilitar boton
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picBoxReturnTo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Form activeForm = null;

        private void openForms(Form newForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = newForm;

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(newForm);
            panelContainer.Tag = newForm;

            newForm.BringToFront();
            newForm.Show();

        }
        /**
         * Validaciones
         */
        private void VerificarCamposTexto(object sender, EventArgs e)
        {
            // Verificar si todas las cajas de texto están vacías
            bool todasVacias = !string.IsNullOrEmpty(txtNombre.Text) &&
                               !string.IsNullOrEmpty(txtNumero.Text) &&
                               !string.IsNullOrEmpty(txtFechaExpedicion.Text) &&
                               !string.IsNullOrEmpty(txtCVV.Text);

            // Habilitar el boton si todas las cajas de texto estan llenas  
            btnRegistrar.Enabled = todasVacias;
        }
        private static bool NoEsNumero(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                return false;
            }
            return true;
        }
        private static bool EsNumero(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return true;
            }
            else
            {
                //e.Handled = true;
                return false;
            }
        }
        private static bool ValidarFecha(TextBox textBoxFecha)
        {
            string dateString = textBoxFecha.Text;
            string format = "dd/MM/yyyy";
            DateTime dateTime;

            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime))
            {
                if (dateTime < DateTime.Now)
                {
                    MessageBox.Show(textBoxFecha, "Tu tarjeta esta vencida jaja");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                //error.SetError(textBoxFecha, "Fecha no válida");
                return false;
            }
        }
        static ErrorProvider error = new ErrorProvider();//para mostrar mensaje de advertencia o error en caja de texto
        /**
         * KeyPress
         */
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = AgregarTarjeta.NoEsNumero(e);
            if (!valida || txtNombre.Text.Contains("  "))
            {
                error.SetError(txtNombre, "NO se admiten números " + "o mas de dos espacios");
                txtNombre.Clear();
            }
            else
                error.Clear();
        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = EsNumero(e);

            if (valida && txtNumero.Text.Length >= 16 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                error.SetError(txtNumero, "Solo se permiten 16 dígitos");
            }
            else if (!valida)
            {
                e.Handled = true;
                error.SetError(txtNumero, "Solo se permiten números");
            }
            else
            {
                error.Clear();
            }
        }
        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = EsNumero(e);
            if (valida && txtCVV.Text.Length >= 3 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                error.SetError(txtCVV, "Sólo se admiten Tres números");
            }
            else if (!valida)
            {
                e.Handled = true;
                error.SetError(txtCVV, "Solo se permiten números");
            }
            else
            {
                e.Handled = false;
                error.Clear();
            }
        }
        /**
         * Leave
         */
        private void txtFechaExpedicion_Leave(object sender, EventArgs e)
        {
            bool valida = ValidarFecha(txtFechaExpedicion);

            if (!valida || txtFechaExpedicion.Text.Contains("  "))
            {
                error.SetError(txtFechaExpedicion, "La fecha está mal escrita");
                txtFechaExpedicion.Clear();
            }
            else
            {
                error.Clear();
            }
        }
        private void txtCVV_Leave(object sender, EventArgs e)
        {
            string cvv = txtCVV.Text.Trim();

            if (cvv.Length < 3)
            {
                txtCVV.Clear();
                error.SetError(txtCVV, "Se requieren 3 números");
            }
            else
            {
                error.Clear();
            }
        }
        private void txtNumero_Leave(object sender, EventArgs e)
        {
            string Numero = txtNumero.Text.Trim();

            if (Numero.Length < 16)
            {
                txtNumero.Clear();
                error.SetError(txtNumero, "Se requieren 16 números");
            }
            else
            {
                error.Clear();
            }
        }

      /*  private void btnRegistrar_Click_1(object sender, EventArgs e)
        {

        }*/

        private void pnlDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
