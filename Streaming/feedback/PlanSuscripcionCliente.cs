using Streaming.connection;
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

    public partial class PlanSuscripcionCliente : Form
    {
        private Form activeForm = null;
        Cliente cliente = new Cliente();
        Panel panelContainer = new Panel();
        public PlanSuscripcionCliente(Panel panelContainer, Form activeForm, Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.panelContainer = panelContainer;
            this.activeForm = activeForm;
        }
        public PlanSuscripcionCliente(Panel panelContainer, Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.panelContainer = panelContainer;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cliente = cliente.ObtenerClientePorUsuario(cliente.User);
            cliente_plan miRelacionClientePlan = new cliente_plan();
            MessageBox.Show("¡Haz hecho clic en Plan mensual!");
            miRelacionClientePlan.ingresarRelacionClientePlan(cliente.Codigo, 1, "Mensual");
            MessageBox.Show("¡Compra exitosa!");
            openForms(new InicioCliente(cliente));

        }
        
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

        private void button2_Click(object sender, EventArgs e)
        {
            cliente = cliente.ObtenerClientePorUsuario(cliente.User);
            cliente_plan miRelacionClientePlan = new cliente_plan();
            MessageBox.Show("¡Haz hecho clic en Plan anual!");
            miRelacionClientePlan.ingresarRelacionClientePlan(cliente.Codigo,4,"Anual");
            MessageBox.Show("¡Compra exitosa!");
            openForms(new InicioCliente(cliente));


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Datos dt = new Datos();
            openForms(new MenuPrincipalCliente(cliente, "Sin plan"));
            //dt.EjecutarProcedimiento("El Padrino");

        }
    }
}
