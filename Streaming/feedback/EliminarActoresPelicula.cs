using Streaming.logica;
using Streaming.connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streaming.feedback
{
    public partial class EliminarActoresPelicula : Form
    {
        Datos misDatos = new Datos();
        public EliminarActoresPelicula()
        {
            InitializeComponent();
            misDatos.obtenerActores(cmbBoxActor);
            misDatos.obtenerPeliculas(cmbBoxPelicula);
            inicializarComboBox();
        }

        public void inicializarComboBox()
        {
            cmbBoxActor.SelectedIndex = 0;
            cmbBoxPelicula.SelectedIndex = 0;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //crear un objeto tipo actor y Datos para manipular la base de datos
            actor miActor = new actor();
            // Obtener el nombre completo del actor seleccionado en el ComboBox
            string nombreCompleto = cmbBoxActor.SelectedItem.ToString();
            // Dividir el nombre completo en primer nombre y primer apellido
            string[] nombreApellido = nombreCompleto.Split(' ');
            string primerNombre = nombreApellido[0];
            string primerApellido = nombreApellido[1];
            // Obtener el código del actor utilizando el primer nombre y primer apellido
            int codigoActor = misDatos.ObtenerCodigoActor(primerNombre, primerApellido);
            // Eliminar el actor utilizando el código obtenido
            int resultado = miActor.eliminarActor(codigoActor);
            //validacion
            if (resultado > 0)
            {
                MessageBox.Show("Actor eliminado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Actor No eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
