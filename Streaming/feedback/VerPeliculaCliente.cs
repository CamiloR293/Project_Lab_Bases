using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Streaming.logica;
using Streaming.connection;
using System.Collections;

namespace Streaming
{
    public partial class VerPeliculaCliente : Form
    {
        Cliente cliente= new Cliente();
        String nPelicula;
        string plan="Con plan";
        Panel main = new Panel();
        public VerPeliculaCliente(String nPelicula, Cliente cliente)
        {
            InitializeComponent();
            this.nPelicula = nPelicula;

            btnComprar.Visible = false;
            AgregarPeliculas(nPelicula);
        }
        public VerPeliculaCliente(String nPelicula, string plan, Cliente cliente)
        {
            InitializeComponent();
            this.nPelicula = nPelicula;
            this.plan = plan;
            this.cliente = cliente;
            if(plan.Equals("Sin plan"))
            {
                btnComprar.Visible = true;

            }
            AgregarPeliculas(nPelicula);
        }

        private void btnVerAhora_Click(object sender, EventArgs e)
        {
            clienteProducto historial = new clienteProducto();
            Datos dt = new Datos();
            producto p = new producto();
            if (plan.Equals("Sin plan"))
            {
                
                if (dt.VerificarClienteProductoExistente(cliente.Codigo, p.idPelicula(nPelicula)))
                {
                    ViendoPelicula pelicula = new ViendoPelicula();
                    pelicula.ShowDialog();
                    historial.ingresarAlHistorialVistas(cliente.Codigo, p.idPelicula(nPelicula));
                    //openForms(new ViendoPelicula());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No has comprado la pelicula, comprala para verla");
                }
            }
            else
            {
                historial.ingresarAlHistorialVistas(cliente.Codigo, p.idPelicula(nPelicula));
                ViendoPelicula pelicula = new ViendoPelicula();
                pelicula.ShowDialog();
            }
        }
        
        public void informacion(DataSet dsResultado)
        {
            lblTituloPelicula.Text = dsResultado.Tables[0].Rows[0]["nombre"].ToString();
            lblDescripcion.Text = dsResultado.Tables[0].Rows[0]["descripcion"].ToString();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarPeliculas(String nombreP) //Lo llamo en el constructor, se necesita pasar el genero de la pelicula
                                        // se hace otro select? o se usa el texto del boton presionado
        {

            Datos dt = new Datos();
            producto pr=new producto();
            ArrayList lista= new ArrayList();
            lista = dt.obtenerCoincidenciasGeneroTodosActores(pr.idPelicula(nombreP));
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
            string nombre=dsResultado.Tables[0].Rows[0]["nombre"].ToString();
            VerPeliculaCliente form = new VerPeliculaCliente(nombre, cliente);
            form.informacion(dsResultado);
            form.ShowDialog();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            
            clienteProducto cp = new clienteProducto();
            producto p=new producto();
            Datos dt = new Datos();
            int precio=dt.EjecutarProcedimiento(nPelicula);
            DialogResult result = MessageBox.Show("¿Desea comprarla? El valor es de: "+ precio, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(result))
            {
                if(!dt.VerificarClienteProductoExistente(cliente.Codigo, p.idPelicula(nPelicula))){

                    if(cp.ingresarproducto(cliente.Codigo, p.idPelicula(nPelicula)) > 0){

                        MessageBox.Show("Pelicula agregada con exito"); 
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }


                }

                
                else
                {
                    MessageBox.Show("Ya has comprado la pelicula!!");
                }
            }
        }
    }
}