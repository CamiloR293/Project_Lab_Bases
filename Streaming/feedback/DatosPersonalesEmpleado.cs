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
    public partial class DatosPersonalesEmpleado : Form
    {
        administrador MiAdministrador= new administrador();
        public DatosPersonalesEmpleado(administrador admin)
        {
            InitializeComponent();
            this.MiAdministrador=admin;
            this.actualizarLabel(MiAdministrador);
          
        }
        private void actualizarLabel(administrador admin) {
            lblPrimerNombre.Text = MiAdministrador.PName;
            lblNombreUsuario.Text = MiAdministrador.User;
            lblSegundoNombre.Text = MiAdministrador.SName;
            lblPrimerApellido.Text = MiAdministrador.PApellido;
            lblSegundoApellido.Text = MiAdministrador.SApellido;
            lblFechaNacimiento.Text = MiAdministrador.FNacimiento;
            lblCorreo.Text = MiAdministrador.Correo;
            lblTelefono.Text = MiAdministrador.Telefono;
            lblCodigo.Text = MiAdministrador.Codigo.ToString();
            lblIdAdmin.Text = MiAdministrador.IdAdmin.ToString();
        }
        private void lblPrimerNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            
            Form actualizar = new ActualizarDatosCliente(MiAdministrador, "1");
            actualizar.ShowDialog();
            this.actualizarLabel(MiAdministrador);
            // hacer el reset de datos empleado
        }
    }
}
