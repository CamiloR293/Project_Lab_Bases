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
    public partial class Visualizacion : Form
    {

        Datos dt = new Datos();
        public Visualizacion()
        {
            InitializeComponent();
            //dt.MostrarInformacionTablas(miControlDataGridView);
            /*Datos dt = new Datos();
            DataGridView dgvTabla = new DataGridView();
            dgvTabla.Name = "miTabla";

            // Configurar las columnas de la tabla DataGridView según los datos que deseas mostrar
            dgvTabla.Columns.Add("NombreTabla", "Nombre de la Tabla");
            dgvTabla.Columns.Add("NombreColumna", "Nombre de la Columna");
            dgvTabla.Columns.Add("TipoDato", "Tipo de Dato");
            dgvTabla.Columns.Add("AceptaNulos", "Acepta Nulos");

            // Llamar al método para mostrar la información de tablas y columnas en la tabla de Visual Studio
            dt.MostrarInformacionTablas(dgvTabla);

            // Agregar la tabla a un formulario o control en Visual Studio para visualizarla
            // Ejemplo: agregar dgvTabla a un control DataGridView existente en el formulario
            miControlDataGridView.Controls.Add(dgvTabla);*/
        }

        private void Visualizacion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dt.VisualizarTablasNombre(comboBox1);
            dt.VisualizarFuncionesNombre(comboBox2);
            dt.VisualizarProcedimientosNombre(comboBox3);   
            dt.VisualizarTriggersNombre(comboBox4);
            dt.VisualizarVistasNombre(comboBox5);
            dt.FillComboBoxWithFilteredTables(comboBox6);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
