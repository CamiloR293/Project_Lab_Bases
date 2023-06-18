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
    public partial class MenuPrincipalCliente : Form
    {
        String plan="Si hay";
        Cliente cliente;
        public MenuPrincipalCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            AgregarPeliculas();

        }
        public MenuPrincipalCliente(Cliente cliente, String plan)
        {
            InitializeComponent();
            this.plan=plan;
            this.cliente=cliente;
            AgregarPeliculas();
          

        }
        public MenuPrincipalCliente(string consulta)
        {
            InitializeComponent();
            AgregarPeliculas(consulta);
        }
        public MenuPrincipalCliente()
        {
            InitializeComponent();
            AgregarPeliculas();
        }
        private void AgregarPeliculas(string consulta) 
        {
            producto peliculas = new producto();
            DataSet dsResultado = new DataSet();
            dsResultado = peliculas.consultarProducto(consulta);
            crearBotones(dsResultado);
        }
        private void AgregarPeliculas()
        {
            producto peliculas = new producto();
            DataSet dsResultado = new DataSet();
            dsResultado = peliculas.consultarProducto();
            crearBotones(dsResultado);
            
        }
        private void crearBotones(DataSet dsResultado)
        {
            if (dsResultado.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsResultado.Tables[0].Rows.Count; i++)
                {
                    Button button = new Button();
                    Font myFont = new Font("Impact", 10);
                    button.Text = dsResultado.Tables[0].Rows[i]["nombre"].ToString() + "-" + dsResultado.Tables[0].Rows[i]["genero"].ToString();
                    button.Width = 150;
                    button.Height = 150;
                    button.BackgroundImageLayout = ImageLayout.Zoom;
                    button.ForeColor = Color.Red;
                    button.BackColor = Color.White;
                    button.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                    button.Font = myFont;
                    button.Name = dsResultado.Tables[0].Rows[i]["codigo"].ToString();
                    //Modificar esta direccion para que funcione, es la direccion de donde se toman las fotos
                    String direccion = "C:\\Users\\Usuario\\Documents\\GitHub\\Streaming\\CamiloR293\\Streaming\\Resources\\" + dsResultado.Tables[0].Rows[i]["nombre"].ToString() + ".png";
                    //String direccion = "D:\\GitHub\\Streaming\\Resources\\" + dsResultado.Tables[0].Rows[i]["nombre"].ToString() + ".png";
                    if (dsResultado.Tables[0].Rows[i]["nombre"].ToString().Contains(":"))
                    {

                        String[] linea = dsResultado.Tables[0].Rows[i]["nombre"].ToString().Split(':');
                        //Esta tambien favor comentarlas y no borrarlas
                        direccion = "C:\\Users\\Usuario\\Documents\\GitHub\\Streaming\\CamiloR293\\Streaming\\Resources\\" + linea[0] + ".png";
                        //direccion = "D:\\GitHub\\Streaming\\Resources\\" + linea[0] + ".png";

                    }
                    button.BackgroundImage = Image.FromFile(direccion);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    flowPanelCatalogo.Controls.Add(button);

                    button.Click += button_Click;
                }
            }
            else
            {
                MessageBox.Show("La pelicula no existe o tiene un nombre distinto.");
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            producto peliculas = new producto();
            DataSet dsResultado = new DataSet();
            dsResultado = peliculas.obtenerProducto(int.Parse(clickedButton.Name));

            VerPeliculaCliente form = new VerPeliculaCliente(dsResultado.Tables[0].Rows[0]["nombre"].ToString(), plan, cliente);
            form.informacion(dsResultado);
            form.ShowDialog();
            
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

            newForm.BringToFront();
            newForm.Show();
        }

        private void flowPanelCatalogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbBoxGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
