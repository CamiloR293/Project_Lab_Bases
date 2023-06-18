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
    public partial class InicioEmpleado : Form
    {
        private String username;
        private Color colorBlancoPredeterminado = Color.FromArgb(254, 250, 251);
        private Color colorBlancoSeleccionado = Color.FromArgb(231, 230, 230);
        public InicioEmpleado(String username)
        {
            InitializeComponent();
            this.username = username;
        }
        public void InicioEmpleado_Load(object sender, System.EventArgs e)
        {
            btnDatosPersonales_Click(sender, e);
        }

        private void btnDatosPersonales_Click(object sender, EventArgs e)
        {
            btnDatosPersonales.BackColor = colorBlancoSeleccionado;
            btnRegistrarProducto.BackColor = colorBlancoPredeterminado;
            btnAdministrarActores.BackColor = colorBlancoPredeterminado;
            pnlAdministrarActores.Visible = false;
            administrador cliente = new administrador();
            cliente=cliente.ObtenerAdministradorPorUsuario(username);
            openForms(new DatosPersonalesEmpleado(cliente));
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            btnDatosPersonales.BackColor = colorBlancoPredeterminado;
            btnRegistrarProducto.BackColor = colorBlancoSeleccionado;
            btnAdministrarActores.BackColor = colorBlancoPredeterminado;
            pnlAdministrarActores.Visible = false;
            openForms(new RegistrarProductoEmpleado(username));
        }
        #region OpenForm

        private Form activeForm = null;
        public void openForms(Form newForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = newForm;

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;

            pnlDesktop.Controls.Add(newForm);
            pnlDesktop.Tag = newForm;

            newForm.BringToFront();
            newForm.Show();
        }
        #endregion

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesion?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(result)) 
                this.Close();
            
        }

        private void btnAdministrarActores_Click(object sender, EventArgs e)
        {
            btnDatosPersonales.BackColor = colorBlancoPredeterminado;
            btnRegistrarProducto.BackColor = colorBlancoPredeterminado;
            btnAdministrarActores.BackColor = colorBlancoSeleccionado;
            pnlAdministrarActores.Visible = true;
            btnAgregarActores_Click(sender,e);
        }

        private void btnAgregarActores_Click(object sender, EventArgs e)
        {
            openForms(new AgregarActoresPelicula());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            openForms(new ActualizarActoresPelicula());
        }

        private void btnEliminarActores_Click(object sender, EventArgs e)
        {
            openForms(new EliminarActoresPelicula());
        }

        private void picBoxAdminIcon_Click(object sender, EventArgs e)
        {

        }
    }
}
