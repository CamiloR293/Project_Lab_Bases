using Streaming.feedback;
using Streaming.logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streaming
{
    public partial class DatosPersonalesCliente : Form
    {

        private Cliente cliente = new Cliente();
        Main iniciosesion = new Main();
        public DatosPersonalesCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.setInfoClient(cliente);

        }
        private void setInfoClient(Cliente cliente)
        {
            lblSegundoApellido.Text = cliente.SApellido;
            lblPrimerNombre.Text = cliente.PName;
            lblNombreUsuario.Text = cliente.User;
            lblSegundoNombre.Text = cliente.SName;
            lblPrimerApellido.Text = cliente.PApellido;
            lblFechaNacimiento.Text = cliente.FNacimiento;
            lblCorreo.Text = cliente.Correo;
            lblTelefono.Text = cliente.Telefono;
            lblCodigo.Text = cliente.Codigo.ToString();
        }

        private void btnVerTarjetas_Click(object sender, EventArgs e)
        {
            Form form = new VerTarjetasCliente(cliente);
            form.ShowDialog();
        }

        private void btnActualizarDatosPersonales_Click(object sender, EventArgs e)
        {
            Form actualizar = new ActualizarDatosCliente(cliente,"2");
            actualizar.ShowDialog();
            //volver a hacer el set de la informacion, no se como funciona el cliente aqui
            //pero es volver a resetear las etiquetas con la info nueva
            setInfoClient(cliente);
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar su cuenta?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            //if (DialogResult.Yes.Equals(result)) //eliminar la cuenta

        }

        private void pnlDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}