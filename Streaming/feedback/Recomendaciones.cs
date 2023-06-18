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

namespace Streaming.feedback
{
    public partial class Recomendaciones : Form
    {
        public Cliente cliente = new Cliente();
        private Color colorNaranjaPredeterminado = Color.FromArgb(255, 144, 76);
        private Color colorNaranjaSeleccionado = Color.FromArgb(192, 108, 56);
        public Recomendaciones(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            listaPeliculas();        
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            InicioCliente form = new InicioCliente(this.cliente);
            form.ShowDialog();
        }
        private void listaPeliculas() 
        {

            Datos dt = new Datos();
            producto pr = new producto();
            ArrayList lista = new ArrayList();


            lista = dt.obtenerListaPorHistorial(cliente.Codigo);
            if (lista.Count > 0)
            {

                for (int i = 0; i < lista.Count; i++)
                {
                    Button button = new Button();
                    Font myFont = new Font("Impact", 10);
                    producto p = (producto)lista[i];
                    button.Text = p.Nombre + "-" + p.Genero;
                    button.Width = 150;
                    button.Height = 150;
                    button.BackgroundImageLayout = ImageLayout.Zoom;
                    button.ForeColor = Color.Red;
                    button.BackColor = Color.White;
                    button.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                    button.Font = myFont;
                    button.Name = p.Codigo.ToString();
                    //Modificar esta direccion para que funcione, es la direccion de donde se toman las fotos
                    String direccion = "C:\\Users\\Usuario\\Documents\\GitHub\\Streaming\\CamiloR293\\Streaming\\Resources\\" + p.Nombre + ".png";
                    //String direccion = "D:\\GitHub\\Streaming\\Resources\\" + p.Nombre + ".png";
                    if (p.Nombre.Contains(":"))
                    {

                        String[] linea = p.Nombre.Split(':');
                        //Esta tambien favor comentarlas y no borrarlas
                        direccion = "C:\\Users\\Usuario\\Documents\\GitHub\\Streaming\\CamiloR293\\Streaming\\Resources\\" + linea[0] + ".png";
                        //direccion = "D:\\GitHub\\Streaming\\Resources\\" + linea[0] + ".png";

                    }
                    button.BackgroundImage = Image.FromFile(direccion);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    flowPanelPeliculasRelacionadas.Controls.Add(button);


                    button.Click += button_Click;


                }



            }
            else
            {
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            producto peliculas = new producto();
            DataSet dsResultado = new DataSet();
            dsResultado = peliculas.obtenerProducto(int.Parse(clickedButton.Name));
            string nombre = dsResultado.Tables[0].Rows[0]["nombre"].ToString();
            VerPeliculaCliente form = new VerPeliculaCliente(nombre, cliente);
            form.informacion(dsResultado);
            form.ShowDialog();



        }

        private void flowPanelPeliculasRelacionadas_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
