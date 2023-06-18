using Streaming.logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streaming
{
    public partial class RegistrarProductoEmpleado : Form
    {
        private string usuario;
        public RegistrarProductoEmpleado(String usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            bloquearBoton();
            inicializarComboBox();
        }

        public void inicializarComboBox()
        {
            cBoxEstado.SelectedIndex = 0;
            cBoxGenero.SelectedIndex = 0;
            cBoxTipo.SelectedIndex = 0;
        }

        public void bloquearBoton()
        {
            // Manejar el evento TextChanged para cada caja de texto
            txtNombre.TextChanged += VerificarCamposTexto;
            txtDescripcion.TextChanged += VerificarCamposTexto;
            txtDuracion.TextChanged += VerificarCamposTexto;
            txtEstreno.TextChanged += VerificarCamposTexto;

            btnRegistrar.Enabled = false;//inhabilitar boton
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Gestionar el registro de la pelicula
            administrador miAdmin = new administrador();
            producto miProducto= new producto();
            int idUser = miAdmin.retornarAdmin(usuario);
            int estado = 0;
            if (cBoxEstado.Text.ToString().Equals("Activo"))
            {
                estado = 1;
            }
         
            int resultado=miProducto.ingresarproducto(idUser, txtNombre.Text, txtDescripcion.Text, txtEstreno.Text
                , txtDuracion.Text, cBoxGenero.Text.ToString(), cBoxTipo.Text.ToString(), estado,0);
            if(resultado > 0) {
                MessageBox.Show("Pelicula insertada con exito");
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtEstreno.Text = "";
                txtDuracion.Text = "";
            }
            
        }
        /**
         * Validaciones
         */
        private void VerificarCamposTexto(object sender, EventArgs e)
        {
            // Verificar si todas las cajas de texto están vacías
            bool todasVacias = !string.IsNullOrEmpty(txtNombre.Text) &&
                               !string.IsNullOrEmpty(txtDuracion.Text) &&
                               !string.IsNullOrEmpty(txtDescripcion.Text) &&
                               !string.IsNullOrEmpty(txtEstreno.Text);

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
        private static bool ValidarFecha(TextBox textBoxFecha)
        {
            string dateString = textBoxFecha.Text.Trim();
            string format = "dd/MM/yyyy";

            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out _))
            {
                // La fecha es válida
                return true;
            }
            else
            {
                return false;
            }
        }

        static ErrorProvider error = new ErrorProvider();//para mostrar mensaje de advertencia o error en caja de texto
        /**
         * KeyPress
         */
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = NoEsNumero(e);
            if (!valida || txtNombre.Text.Contains("  "))
            {
                error.SetError(txtNombre, "NO se admiten números " + "o mas de dos espacios");
                txtNombre.Clear();
            }
            else
                error.Clear();
        }

        private void txtEstreno_Leave(object sender, EventArgs e)
        {
            bool valida = ValidarFecha(txtEstreno);

            if (!valida || txtEstreno.Text.Contains("  "))
            {
                error.SetError(txtEstreno, "La fecha está mal escrita");
                txtEstreno.Clear();
            }
            else
            {
                error.Clear();
            }
        }
    }
}
