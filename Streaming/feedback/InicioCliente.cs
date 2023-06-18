using Streaming.logica;
using System.Data;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using Streaming.feedback;

namespace Streaming
{
    public partial class InicioCliente : Form
    {
        public Cliente cliente = new Cliente();
        private Color colorNaranjaPredeterminado = Color.FromArgb(255, 144, 76);
        private Color colorNaranjaSeleccionado = Color.FromArgb(192, 108, 56);


        public InicioCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            openForms(new MenuPrincipalCliente(cliente));
        }

        public InicioCliente()
        {
            InitializeComponent();
            openForms(new MenuPrincipalCliente(cliente));
        }

        public void InicioCliente_Load(object sender, System.EventArgs e)
        {
            btnMenuPrincipal_Click(sender, e);
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

        private void btnMenuPrincipal_Click(object sender, System.EventArgs e)
        {
            btnMenuPrincipal.BackColor = colorNaranjaSeleccionado;
            btnAddMetodosPago.BackColor = colorNaranjaPredeterminado;
            btnDatosPersonales.BackColor = colorNaranjaPredeterminado;
            btnRecomendados.BackColor = colorNaranjaPredeterminado;
            openForms(new MenuPrincipalCliente(cliente));
        }

        private void btnDatosPersonales_Click(object sender, System.EventArgs e)
        {
            cliente = cliente.ObtenerClientePorUsuario(cliente.User);
            btnMenuPrincipal.BackColor = colorNaranjaPredeterminado;
            btnAddMetodosPago.BackColor = colorNaranjaPredeterminado;
            btnDatosPersonales.BackColor = colorNaranjaSeleccionado;
            btnRecomendados.BackColor = colorNaranjaPredeterminado;
            openForms(new DatosPersonalesCliente(cliente));
        }

        private void btnAddMetodosPago_Click(object sender, System.EventArgs e)
        {
            btnMenuPrincipal.BackColor = colorNaranjaPredeterminado;
            btnAddMetodosPago.BackColor = colorNaranjaSeleccionado;
            btnDatosPersonales.BackColor = colorNaranjaPredeterminado;
            btnRecomendados.BackColor = colorNaranjaPredeterminado;
            openForms(new AgregarTarjeta(cliente));
        }
        private void btnCerrarSesion_Click(object sender, System.EventArgs e)
        {
            //Poner una notificacion
            DialogResult result = MessageBox.Show("¿Desea cerrar sesion?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(result))
            {
                openForms(new Main());
                this.Close();

            }



        }
        private void txtBuscar_Click(object sender, System.EventArgs e)
        {
            if (txtBuscar.Text.Equals("Buscar")) txtBuscar.Clear();
        }
        private void txtBuscar_Leave(object sender, System.EventArgs e)
        {
            if (txtBuscar.Text.Equals("")) txtBuscar.Text = "Buscar";
        }

        private void picBoxBuscar_Click(object sender, System.EventArgs e)
        {
            //buscar segun txtBuscar
            openForms(new MenuPrincipalCliente(txtBuscar.Text));
        }

        public void hideControls()
        {
            pnlDesktop.Visible = false;
            banner.Visible = false;
            pnlLateral.Visible = false;
        }

        private void btnRecomendados_Click(object sender, EventArgs e)
        {
            btnMenuPrincipal.BackColor = colorNaranjaPredeterminado;
            btnAddMetodosPago.BackColor = colorNaranjaPredeterminado;
            btnDatosPersonales.BackColor = colorNaranjaPredeterminado;
            btnRecomendados.BackColor = colorNaranjaSeleccionado;
            openForms(new Recomendaciones(cliente));
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals("")) btnMenuPrincipal_Click(sender,e);
            else picBoxBuscar_Click(sender,e);
        }

        private void pnlDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}