using Streaming.connection;
using Streaming.logica;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Streaming.feedback
{
    public partial class ActualizarActoresPelicula : Form
    {
        Datos misDatos = new Datos();
        public ActualizarActoresPelicula()
        {
            InitializeComponent();
            llenarCmbBoxPeliculas();
            bloquearBoton();
            inicializarComboBox();
        }

        public void bloquearBoton()
        {
            // Manejar el evento TextChanged para cada caja de texto
            txtFechaNacimiento.TextChanged += VerificarCamposTexto;
            txtPrimerApellido.TextChanged += VerificarCamposTexto;
            txtPrimerNombre.TextChanged += VerificarCamposTexto;
            txtSegundoApellido.TextChanged += VerificarCamposTexto;
            txtSegundoNombre.TextChanged += VerificarCamposTexto;
            btnActualizar.Enabled = false;//inhabilitar boton
        }

        public void inicializarComboBox()
        {
            //cmbBoxActor.SelectedIndex = 0; /*@TODO: marcar si no se inicializa el combobox de Actor o causa errores*/
            cmbBoxPapel.SelectedIndex = 0;
            cmbBoxPelicula.SelectedIndex = 0;
        }

        private void VerificarCamposTexto(object sender, EventArgs e)
        {
            // Verificar si todas las cajas de texto están vacías
            bool todasVacias = !string.IsNullOrEmpty(txtFechaNacimiento.Text) &&
                               !string.IsNullOrEmpty(txtPrimerApellido.Text) &&
                               !string.IsNullOrEmpty(txtPrimerNombre.Text) &&
                               !string.IsNullOrEmpty(txtSegundoApellido.Text) &&
                               !string.IsNullOrEmpty(txtSegundoNombre.Text);

            // Habilitar el boton si todas las cajas de texto estan llenas  
            btnActualizar.Enabled = todasVacias;
        }

        private void llenarCmbBoxPeliculas()
        {
            misDatos.obtenerPeliculas(cmbBoxPelicula);
            //cmbBoxPelicula.Items.Add(); //Ciclo que llene todas las peliculas para seleccionar
        }

        private void llenarCmbBoxActores(String nPelicula)
        {
            //MessageBox.Show(nPelicula);
            misDatos.procedimientoObtenerActores(cmbBoxActor, nPelicula);
            //cmbBoxActor.Items.Add(); //Ciclo que llene todos los actores de una pelicula seleccionada
        }

        private void cmbBoxPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {

            llenarCmbBoxActores(cmbBoxPelicula.SelectedItem.ToString());
            //llenarCmbBoxActores(0); //Cuando se seleccione una pelicula llenar el combo box de actores
        }

        private void cmbBoxActor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se ejecuta cuando se seleccione un actor, los campos de texto se llenan automaticamente para
            //ser actualizados
            //txtPrimerNombre.Text = "NombreActor";
            //txtPrimerApellido.Text = "ApellidoActor";
            //txtSegundoNombre.Text = "NombreActor";
            //txtSegundoApellido.Text = "ApellidoActor";
            //txtFechaNacimiento.Text = "fech";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Actualiza la informacion en la base de datos
            actor miActor = new actor();
            Datos misDatos = new Datos();
            int resultado = miActor.actualizarActor(txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text,
                                                    txtSegundoApellido.Text, txtFechaNacimiento.Text, misDatos.ObtenerCodigoActor(txtPrimerNombre.Text, txtPrimerApellido.Text));
            if (resultado > 0)
            {
                MessageBox.Show("Actor actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrimerNombre.Clear();
                txtPrimerNombre.Clear();
                txtSegundoNombre.Clear();
                txtFechaNacimiento.Clear();
                txtPrimerApellido.Clear();
            }
            else
            {
                MessageBox.Show("actor no se ha actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**
        * validaciones de textBox
        */
        ErrorProvider error = new ErrorProvider();//para mostrar mensaje de advertencia o error en caja de texto
       
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
                //MessageBox.Show(textBoxFecha, "La fecha no es válida");
                return false;
            }
        }
        /*
         * Eventos KeyPress
         */
        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarActoresPelicula.NoEsNumero(e);
            if (!valida || txtPrimerNombre.Text.Contains("  "))
            {
                error.SetError(txtPrimerNombre, "NO se admiten números " + "o mas de dos espacios");
                txtPrimerNombre.Clear();
            }
            else
                error.Clear();
        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarActoresPelicula.NoEsNumero(e);
            if (!valida || txtPrimerApellido.Text.Contains("  "))
            {
                error.SetError(txtPrimerApellido, "NO se admiten números " + "o mas de dos espacios");
                txtPrimerApellido.Clear();
            }
            else
                error.Clear();
        }

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarActoresPelicula.NoEsNumero(e);
            if (!valida || txtSegundoNombre.Text.Contains("  "))
            {
                error.SetError(txtSegundoNombre, "NO se admiten números " + "o mas de dos espacios");
                txtSegundoNombre.Clear();
            }
            else
                error.Clear();
        }

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = ActualizarActoresPelicula.NoEsNumero(e);
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
            bool valida = ValidarFecha(txtFechaNacimiento);
            if (!valida || txtFechaNacimiento.Text.Contains(" "))
            {
                error.SetError(txtFechaNacimiento, "La fecha esta mal escrita");
                txtFechaNacimiento.Clear();
            }
            else
            {
                error.Clear();
            }               
        }
    }
}
