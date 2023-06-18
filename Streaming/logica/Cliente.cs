using Oracle.ManagedDataAccess.Client;
using Streaming.connection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Streaming.logica
{
    public class Cliente
    {
        // Atributos del cliente
        private int codigo;
        private string user;
        private string pName;
        private string sName;
        private string pApellido;
        private string sapellido;
        private string password;
        private string fNacimiento;
        private string telefono;
        private string correo;


        public Cliente(int codigo, string user, string pName, string sName, string pApellido, string sapellido, string password, string fNacimiento, string telefono, string correo)
        {
            this.codigo = codigo;
            this.user = user;
            this.pName = pName;
            this.sName = sName;
            this.pApellido = pApellido;
            this.sapellido = sapellido;
            this.password = password;
            this.fNacimiento = fNacimiento;
            this.telefono = telefono;
            this.correo = correo;
        }

        public Cliente()
        {
        }

        Datos dt = new Datos();

        public int ingresarRegistro(string usuario, string primernombre, string segundonombre, string primerapellido,
            string segundoapellido, string contrasenia, string fechanac, string telefono, string correo)
        {
            int resultado;
            string consulta;
            consulta = "insert into cliente (CODIGO, NOMBRE_USUARIO_CLIENTE, PRIMERNOMBRE, SEGUNDONOMBRE, PRIMERAPELLIDO, SEGUNDOAPELLIDO, FECHANACIMIENTO, CONTRASENIA, TELEFONO, CORREO)" +
                " values((select nvl(max(codigo) + 1, 1) as codigo from CLIENTE)," + "'" + usuario + "'" + ", '" + primernombre + "' , '" + segundonombre + "', '" +
                primerapellido + "','" + segundoapellido + "'," + "to_Date('" + fechanac + "','dd-mm-yyyy'), '" + contrasenia + "','" + telefono + "','" + correo + "')";
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int updateRegistro(Cliente cliente)
        {
            string consulta = "UPDATE CLIENTE SET NOMBRE_USUARIO_CLIENTE = '"+cliente.User+"', PRIMERNOMBRE = '"+cliente.PName+"', " +
                "SEGUNDONOMBRE = '"+ cliente.SName+"', PRIMERAPELLIDO = '"+ cliente.PApellido +"', SEGUNDOAPELLIDO ='"+cliente.SApellido+"', " +
                "FECHANACIMIENTO = to_Date('"+cliente.FNacimiento+"','dd-mm-yyyy'), CONTRASENIA = '"+ cliente.password+"', TELEFONO ='"+cliente.Telefono+"', " +
                "CORREO ='"+cliente.Correo+"' WHERE CODIGO= " + codigo;
            MessageBox.Show(consulta);
            int resultado = dt.ejecutarDML(consulta);
            return resultado;

        }
        public DataSet consultarRegistro()
        {
            string consulta;
            consulta = "select * from Registro";
            DataSet miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }


        public Cliente ObtenerClientePorUsuario(string usuario)
        {
            Cliente cliente = null;

            string consulta = "SELECT CODIGO, NOMBRE_USUARIO_CLIENTE, PRIMERNOMBRE, SEGUNDONOMBRE, PRIMERAPELLIDO, SEGUNDOAPELLIDO, FECHANACIMIENTO, CONTRASENIA, TELEFONO, CORREO FROM CLIENTE WHERE NOMBRE_USUARIO_CLIENTE = :Usuario";
            using (OracleConnection conexion = new OracleConnection(dt.getCadenaConexion()))
            {
                OracleCommand comando = new OracleCommand(consulta, conexion);
                comando.Parameters.Add(new OracleParameter(":Usuario", OracleDbType.Varchar2)).Value = usuario;
                conexion.Open();

                OracleDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    int codigo = Convert.ToInt32(reader["CODIGO"]);
                    string user = reader["NOMBRE_USUARIO_CLIENTE"].ToString();
                    string pName = reader["PRIMERNOMBRE"].ToString();
                    string sName = reader["SEGUNDONOMBRE"].ToString();
                    string pApellido = reader["PRIMERAPELLIDO"].ToString();
                    string sapellido = reader["SEGUNDOAPELLIDO"].ToString();
                    string password = reader["CONTRASENIA"].ToString();
                    string fNacimiento = reader["FECHANACIMIENTO"].ToString();
                    string telefono = reader["TELEFONO"].ToString();
                    string correo = reader["CORREO"].ToString();

                    cliente = new Cliente(codigo,user, pName, sName, pApellido, sapellido, password, fNacimiento, telefono, correo);
                }

                conexion.Close();
            }

            return cliente;
        }

        // ...


        // Getters y Setters
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
 
        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string PName
        {
            get { return pName; }
            set { pName = value; }
        }

        public string SName
        {
            get { return sName; }
            set { sName = value; }
        }

        public string PApellido
        {
            get { return pApellido; }
            set { pApellido = value; }
        }

        public string SApellido
        {
            get { return sapellido; }
            set { sapellido = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string FNacimiento
        {
            get { return fNacimiento; }
            set { fNacimiento = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
    }
}
