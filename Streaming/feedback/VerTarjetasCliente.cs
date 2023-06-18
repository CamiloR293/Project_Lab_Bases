
using Streaming.connection;
using Streaming.logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Streaming.feedback
{
    public partial class VerTarjetasCliente : Form
    {

        private ArrayList list = new ArrayList();
        Datos dt = new Datos();
        Cliente cliente1 = new Cliente();
        public VerTarjetasCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente1 = cliente;
            llenarcmbBoxTarjeta();

        }

        private void llenarcmbBoxTarjeta()
        {

            list = dt.MostrarDatosVistaClienteTarjeta(cliente1.Codigo);
            cmbBoxTarjeta.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                cmbBoxTarjeta.Items.Add(list[i].ToString());
            }
        }
        private void cmbBoxTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //llenar todas las etiquetas correspondientes a la info de la tarjeta seleccionada
            VistaTarjeta vistaTarjeta = new VistaTarjeta();
            tarjeta target = new tarjeta();
            string numero = vistaTarjeta.devolverNumeroTarjeta(cmbBoxTarjeta.SelectedItem.ToString());
            target = target.BuscarTarjeta(cliente1.Codigo, numero);
            lblNumero.Text = target.NumeroTarjeta;
            lblNombre.Text = target.NombreTarjeta;
            lblFechaExpedicion.Text = target.FechaExpiracion.ToString();
            lblTipo.Text = target.TipoTarjeta;

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
