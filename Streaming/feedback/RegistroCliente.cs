using Streaming.logica;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Streaming
{
    public partial class RegistroCliente : Form
    {
        Panel panelContainer = new Panel();
        public RegistroCliente(Panel panelContainer)
        {
            InitializeComponent();
            this.panelContainer = panelContainer;
            bloquearBoton();
        }

        public void bloquearBoton()
        {
            // Manejar el evento TextChanged para cada caja de texto
            txtPNombre.TextChanged += VerificarCamposTexto;
            txtPApellido.TextChanged += VerificarCamposTexto;
            txtSNombre.TextChanged += VerificarCamposTexto;
            txtSApellido.TextChanged += VerificarCamposTexto;
            txtFechaNacimiento.TextChanged += VerificarCamposTexto;
            txtTelefono.TextChanged += VerificarCamposTexto;
            txtCorreo.TextChanged += VerificarCamposTexto;
            txtPassword.TextChanged += VerificarCamposTexto;
            txtUsuario.TextChanged += VerificarCamposTexto;
            btnAgregarTarjeta.Enabled = false;//inhabilitar boton
        }

        private void picBoxReturnTo_Click(object sender, EventArgs e)
        {
            openForms(new Main());
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
        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            if(!txtPassword.Text.Equals(txtRepPassword.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                openForms(new AgregarTarjeta(panelContainer, this, txtUsuario.Text, txtPNombre.Text, txtSNombre.Text, txtPApellido.Text
                    , txtSApellido.Text, txtPassword.Text, txtFechaNacimiento.Text, txtTelefono.Text
                    , txtCorreo.Text));
            }
        }
        /**
         *validaciones
         */
        private bool ValidarCorreo(string correo)
        {
            // Expresión regular para validar el formato de correo electrónico
            string patron = @"^[\w\.-]+@[\w\.-]+\.\w+$";

            // Verificar si el correo cumple con el formato utilizando la expresión regular
            return Regex.IsMatch(correo, patron);
        }
        private void VerificarCamposTexto(object sender, EventArgs e)
        {
            // Verificar si todas las cajas de texto están vacías
            bool todasVacias = !string.IsNullOrEmpty(txtPNombre.Text) &&
                               !string.IsNullOrEmpty(txtPApellido.Text) &&
                               !string.IsNullOrEmpty(txtSNombre.Text) &&
                               !string.IsNullOrEmpty(txtSApellido.Text) &&
                               !string.IsNullOrEmpty(txtFechaNacimiento.Text)&&
                               !string.IsNullOrEmpty(txtTelefono.Text)&&
                               !string.IsNullOrEmpty(txtCorreo.Text)&&
                               !string.IsNullOrEmpty(txtPassword.Text)&&
                               !string.IsNullOrEmpty(txtCorreo.Text)&&
                               !string.IsNullOrEmpty(txtUsuario.Text);

            // Habilitar el boton si todas las cajas de texto estan llenas  
            btnAgregarTarjeta.Enabled = todasVacias;
        }
        static ErrorProvider error = new ErrorProvider();//para mostrar mensaje de advertencia o error en caja de texto
        private static bool EsNumero(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return true;
            }
            else
            {
                e.Handled = true;
                return false;
            }
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
        private static bool ValidarFecha(TextBox textBoxFecha)
        {
            string dateString = textBoxFecha.Text;
            string format = "dd/MM/yyyy";
            DateTime dateTime;

            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime))
            {
                if (dateTime.Date <= DateTime.Today)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(textBoxFecha, "La fecha ingresada es mayor que la fecha actual");
                    return false;
                }
            }
            else
            {
                //error.SetError(textBoxFecha, "Fecha no válida");
                return false;
            }
        }
        /**
         * keyPress
         */
        private void txtPNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = NoEsNumero(e);
            if (!valida || txtPNombre.Text.Contains("  "))
            {
                error.SetError(txtPNombre, "NO se admiten números " + "o mas de dos espacios");
                txtPNombre.Clear();
            }
            else
                error.Clear();
        }

        private void txtSNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = NoEsNumero(e);
            if (!valida || txtSNombre.Text.Contains("  "))
            {
                error.SetError(txtSNombre, "NO se admiten números " + "o mas de dos espacios");
                txtSNombre.Clear();
            }
            else
                error.Clear();
        }

        private void txtPApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = NoEsNumero(e);
            if (!valida || txtPApellido.Text.Contains("  "))
            {
                error.SetError(txtPApellido, "NO se admiten números " + "o mas de dos espacios");
                txtPApellido.Clear();
            }
            else
                error.Clear();
        }

        private void txtSApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = NoEsNumero(e);
            if (!valida || txtSApellido.Text.Contains("  "))
            {
                error.SetError(txtSApellido, "NO se admiten números " + "o mas de dos espacios");
                txtSApellido.Clear();
            }
            else
                error.Clear();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = EsNumero(e);
            if (!valida)
                error.SetError(txtTelefono, "Sólo se admiten números");
            else
                error.Clear();
        }
        /**
         * TextChanged
         */
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            bool esCorreoValido = ValidarCorreo(correo);

            if (!esCorreoValido && !string.IsNullOrEmpty(correo))
            {
                error.SetError(txtCorreo, "Correo electrónico inválido");
            }
            else
            {
                error.Clear();
            }
        }
        /**
         *Leave
         */
        private void txtFechaNacimiento_Leave(object sender, EventArgs e)
        {
            bool valida = ValidarFecha(txtFechaNacimiento);

            if (!valida || txtFechaNacimiento.Text.Contains("  "))
            {
                error.SetError(txtFechaNacimiento, "La fecha está mal escrita");
                txtFechaNacimiento.Clear();
            }
            else
            {
                error.Clear();
            }
        }

        private void pnlDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
