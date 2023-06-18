
using Oracle.ManagedDataAccess.Client;
using Streaming.connection;
using System;
using System.Data;

namespace Streaming.logica
{
    internal class producto
    {
        private int codigo;
        private string nombre;
        private string genero;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public producto(int codigo, string nombre, string genero)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.genero = genero;
        }
        

        public producto()
        {

        }
        Datos dt = new Datos();
        public int ingresarproducto(int codigo_admin, string nombre, string descripcion,
            string fechaestreno, string duracion, string genero, string tipo_producto, int estado, int vistas)
        {
            int resultado;
            string consulta;
            consulta = "insert into producto values((select max(codigo + 1) from PRODUCTO)," + codigo_admin + ", '" + nombre + "', '"
                + descripcion + "', " + "to_Date('" + fechaestreno + "','dd/mm/yyyy'), '" + duracion + "', '" + genero + "', '" + tipo_producto + "', " + estado + "," + vistas + ")";
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public DataSet obtenerProducto(int codigo)
        {
            DataSet miDs = new DataSet();
            string consulta;
            consulta = "select * from producto where codigo=" + codigo;
            miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }
        public int idPelicula(string nombreP)
        {
            return dt.idProducto(nombreP);
        }


        public void peliculasRecomendadas(int codigo)
        {
            OracleConnection connection = new OracleConnection(dt.getCadenaConexion());
            connection.Open();
            OracleCommand command = new OracleCommand("PQU_FUNCIONES.OBTENER_RECOMENDADOS", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("PRM_COD_CLIENTE", OracleDbType.Int32).Value = codigo;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            connection.Close();

        }
        public DataSet consultarProducto()
        {
            DataSet miDs = new DataSet();
            string consulta;
            consulta = "select * from producto";
            miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }
        public DataSet consultarProducto(string nombrePelicula)
        {
            DataSet miDs = new DataSet();
            string consulta = "select * from producto where nombre LIKE '%" + nombrePelicula + "%'";
            miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }
        public DataSet extraerPeliculasPorGenero(string genero)
        {
            DataSet miDs = new DataSet();
            string consulta = "select * from producto where genero = " + genero;
            miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }
    }
}