using Streaming.connection;
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

namespace Streaming.feedback
{
    public partial class AgregarActoresPelicula : Form
    {
        Datos misDatos = new Datos();

        public AgregarActoresPelicula()
        {
            InitializeComponent();
            misDatos.obtenerPeliculas(cmbBoxPelicula);
            bloquearBoton();
            inicializarComboBox();
        }
        public void inicializarComboBox()
        {
            cmbBoxPapel.SelectedIndex = 0;
            cmbBoxPelicula.SelectedIndex = 0;
        }

        public void bloquearBoton()
        {
            // Manejar el evento TextChanged para cada caja de texto
            txtPrimerNombre.TextChanged += VerificarCamposTexto;
            txtSegundoNombre.TextChanged += VerificarCamposTexto;
            txtPrimerApellido.TextChanged += VerificarCamposTexto;
            txtSegundoApellido.TextChanged += VerificarCamposTexto;
            txtFechaNacimiento.TextChanged += VerificarCamposTexto;
            btnRegistrar.Enabled = false;//inhabilitar boton
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //crear un objeto tipo actor
            actor miActor = new actor();
            //
            string primerNombre = txtPrimerNombre.Text;
            string segundoNombre = txtSegundoNombre.Text;
            string primerApellido = txtPrimerApellido.Text;
            string segundoApellido = txtSegundoApellido.Text;
            string fechaNacimiento = txtFechaNacimiento.Text;
            string papel = cmbBoxPapel.SelectedItem.ToString();
            //rellenar peliculas
            string nombrePelicula = cmbBoxPelicula.SelectedItem.ToString(); // guardar en una variable
            //Ejecutar la insercion de un actor a la pelicula
            int resultado = miActor.ingresarActor(primerNombre, segundoNombre, primerApellido, segundoApellido, fechaNacimiento);
            int resultado2 = miActor.registrarProductoActor(nombrePelicula, papel);
            if (resultado > 0 && resultado2 > 0)
            {
                if (resultado2 == 20001)
                {
                    MessageBox.Show("Trigger Ejecutado: No se pueden añadir más de 5 actores en la misma pelicuala");
                }
                else
                {
                    MessageBox.Show("Actor y productos registrados con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //limpiar text box
                    txtFechaNacimiento.Clear();
                    txtPrimerApellido.Clear();
                    txtPrimerNombre.Clear();
                    txtSegundoApellido.Clear();
                    txtSegundoNombre.Clear();
                }
            }
            else
            {
                MessageBox.Show("Actor y productos registrados No se registraron", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**
         * Validaciones
         * */
        private void VerificarCamposTexto(object sender, EventArgs e)
        {
            // Verificar si todas las cajas de texto están vacías
            bool todasVacias = !string.IsNullOrEmpty(txtPrimerNombre.Text) &&
                               !string.IsNullOrEmpty(txtSegundoNombre.Text) &&
                               !string.IsNullOrEmpty(txtPrimerApellido.Text) &&
                               !string.IsNullOrEmpty(txtSegundoApellido.Text) &&
                               !string.IsNullOrEmpty(txtFechaNacimiento.Text);

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
        static ErrorProvider error = new ErrorProvider();//para mostrar mensaje de advertencia o error en caja de texto
        /**
         * Keypress 
         **/
        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = AgregarActoresPelicula.NoEsNumero(e);
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
            bool valida = AgregarActoresPelicula.NoEsNumero(e);
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
            bool valida = AgregarActoresPelicula.NoEsNumero(e);
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
            bool valida = AgregarActoresPelicula.NoEsNumero(e);
            if (!valida || txtSegundoApellido.Text.Contains("  "))
            {
                error.SetError(txtSegundoApellido, "NO se admiten números " + "o mas de dos espacios");
                txtSegundoApellido.Clear();
            }
            else
                error.Clear();
        }

        private void txtFechaNacimiento_Leave(object sender, EventArgs e)
        {
            bool valida = AgregarActoresPelicula.ValidarFecha(txtFechaNacimiento);

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
