using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Streaming.connection;
using Streaming.feedback;

namespace Streaming
{
    public partial class Main : Form
    {

        private string cadenaConexion = "Data Source=localhost;User ID=admin;Password=admin123";
        public Main()
        {
            InitializeComponent();
        }

      

    

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Datos dt = new Datos();
            bool v=dt.VerificarConexion();
            if(v)
            {
                MessageBox.Show("Conectado");
                Visualizacion visualizacion = new Visualizacion();
                visualizacion.Visible = true;
            }
        }


        private bool VerificarCredenciales(string username, string password)
        {
            using (OracleConnection miConexion = new OracleConnection(cadenaConexion))
            {
                miConexion.Open();

                string consulta = "SELECT COUNT(*) FROM CLIENTE WHERE NOMBRE_USUARIO_CLIENTE = :username AND CONTRASENIA = :password";

                using (OracleCommand comando = new OracleCommand(consulta, miConexion))
                {
                    comando.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                    comando.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;

                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        private void ValidarSuscripcion(int codigoCliente, out bool resultado)
        {
            using (OracleConnection miConexion = new OracleConnection(cadenaConexion))
            {
                miConexion.Open();

                using (OracleCommand comando = new OracleCommand("validar_suscripcion", miConexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("p_codigo_cliente", OracleDbType.Int32).Value = codigoCliente;
                    comando.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataReader reader = comando.ExecuteReader())
                    {
                        resultado = reader.HasRows;
                    }
                }
            }
        }

        private void lblInicioSesion_Click(object sender, EventArgs e)
        {

        }
    }
}
