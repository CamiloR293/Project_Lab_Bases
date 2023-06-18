using Streaming.logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streaming.feedback
{
    public partial class ActualizarDatosCliente : Form
    {
        Cliente cliente = new Cliente();
        administrador admin = new administrador();
        String estado;
        public ActualizarDatosCliente(Cliente cliente, string estado)
        {
            InitializeComponent();
            this.cliente = cliente;
            meterInformacionCliente(cliente);
            this.estado= estado;
            bloquearBoton();
        }
        public ActualizarDatosCliente(administrador admin, string estado)
        {
            InitializeComponent();
            this.admin = admin;
            meterInformacionAdmin(admin);
            this.estado = estado;
            bloquearBoton();           
        }
        public void bloquearBoton()
        {
            // Manejar el evento TextChanged para cada caja de texto
            txtPrimerNombre.TextChanged += VerificarCamposTexto;
            txtPrimerApellido.TextChanged += VerificarCamposTexto;
            txtSegundoNombre.TextChanged += VerificarCamposTexto;
            txtSegundoApellido.TextChanged += VerificarCamposTexto;
            txtFechaNacimiento.TextChanged += VerificarCamposTexto;
            txtTelefono.TextChanged += VerificarCamposTexto;
            txtCorreo.TextChanged += VerificarCamposTexto;
            txtPassword.TextChanged += VerificarCamposTexto;
            txtNombreUsuario.TextChanged += VerificarCamposTexto;
            btnActualizar.Enabled = false;//inhabilitar boton
        }
        private void meterInformacionCliente(Cliente cliente)
        {
            txtPrimerNombre.Text = cliente.PName;
            txtSegundoNombre.Text = cliente.SName;
            txtPrimerApellido.Text = cliente.PApellido;
            txtSegundoApellido.Text = cliente.SApellido;
            txtNombreUsuario.Text = cliente.User;
            txtPassword.Text = cliente.Password;
            txtCorreo.Text = cliente.Correo;
            txtFechaNacimiento.Text = cliente.FNacimiento;
            txtTelefono.Text = cliente.Telefono;
        }
        private void meterInformacionAdmin(administrador cliente)
        {
            txtPrimerNombre.Text = cliente.PName;
            txtSegundoNombre.Text = cliente.SName;
            txtPrimerApellido.Text = cliente.PApellido;
            txtSegundoApellido.Text = cliente.SApellido;
            txtNombreUsuario.Text = cliente.User;
            txtPassword.Text = cliente.Password;
            txtCorreo.Text = cliente.Correo;
            txtFechaNacimiento.Text = cliente.FNacimiento;
            txtTelefono.Text = cliente.Telefono;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Actualziar datos en la BD
            DateTime fecha = DateTime.Parse(txtFechaNacimiento.Text);
            DateTime fechaTruncada = fecha.Date;
            DateTime fechaActual = DateTime.Now;
            if (estado.Equals("2")){
                cliente.PName = txtPrimerNombre.Text;
                cliente.SName = txtSegundoNombre.Text;
                cliente.PApellido = txtPrimerApellido.Text;
                cliente.SApellido = txtSegundoApellido.Text;
                cliente.User = txtNombreUsuario.Text;
                cliente.Password = txtPassword.Text;
                cliente.Correo = txtCorreo.Text;
                if (fecha < fechaActual) 
                {
                    cliente.FNacimiento = fechaTruncada.ToString("dd-MM-yyyy");
                }
                else
                {
                    MessageBox.Show("la fecha no puede ser mayor a la actual");
                }
                cliente.Telefono = txtTelefono.Text;
                cliente.updateRegistro(cliente);
            }
            else
            {
                admin.PName = txtPrimerNombre.Text;
                admin.SName = txtSegundoNombre.Text;
                admin.PApellido = txtPrimerApellido.Text;
                admin.SApellido = txtSegundoApellido.Text;
                admin.User = txtNombreUsuario.Text;
                admin.Password = txtPassword.Text;
                admin.Correo = txtCorreo.Text;
                admin.FNacimiento = fechaTruncada.ToString("dd-MM-yyyy");
                admin.Telefono = txtTelefono.Text;
                admin.updateRegistro(admin);
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
            bool todasVacias = !string.IsNullOrEmpty(txtPrimerNombre.Text) &&
                               !string.IsNullOrEmpty(txtPrimerApellido.Text) &&
                               !string.IsNullOrEmpty(txtSegundoNombre.Text) &&
                               !string.IsNullOrEmpty(txtSegundoApellido.Text) &&
                               !string.IsNullOrEmpty(txtFechaNacimiento.Text) &&
                               !string.IsNullOrEmpty(txtTelefono.Text) &&
                               !string.IsNullOrEmpty(txtCorreo.Text) &&
                               !string.IsNullOrEmpty(txtPassword.Text) &&
                               !string.IsNullOrEmpty(txtCorreo.Text) &&
                               !string.IsNullOrEmpty(txtNombreUsuario.Text);

            // Habilitar el boton si todas las cajas de texto estan llenas  
            btnActualizar.Enabled = todasVacias;
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
                if (dateTime > DateTime.Now)
                {
                    MessageBox.Show(textBoxFecha, "La fecha ingresada es mayor que la fecha actual");
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
        /**
         * keyPress
         */
        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarDatosCliente.NoEsNumero(e);
            if (!valida || txtPrimerNombre.Text.Contains("  "))
            {
                error.SetError(txtPrimerNombre, "NO se admiten números " + "o mas de dos espacios");
                txtPrimerNombre.Clear();
            }
            else
                error.Clear();
        }

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarDatosCliente.NoEsNumero(e);
            if (!valida || txtSegundoNombre.Text.Contains("  "))
            {
                error.SetError(txtSegundoNombre, "NO se admiten números " + "o mas de dos espacios");
                txtSegundoNombre.Clear();
            }
            else
                error.Clear();
        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarDatosCliente.NoEsNumero(e);
            if (!valida || txtPrimerApellido.Text.Contains("  "))
            {
                error.SetError(txtPrimerApellido, "NO se admiten números " + "o mas de dos espacios");
                txtPrimerApellido.Clear();
            }
            else
                error.Clear();
        }

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarDatosCliente.NoEsNumero(e);
            if (!valida || txtSegundoApellido.Text.Contains("  "))
            {
                error.SetError(txtSegundoApellido, "NO se admiten números " + "o mas de dos espacios");
                txtSegundoApellido.Clear();
            }
            else
                error.Clear();
        }

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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarDatosCliente.EsNumero(e);
            if (!valida)
                error.SetError(txtTelefono, "Sólo se admiten números");
            else
                error.Clear();
        }

        private void txtFechaNacimiento_Leave(object sender, EventArgs e)
        {
            bool valida = ActualizarDatosCliente.ValidarFecha(txtFechaNacimiento);

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
    }
}
