
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using System.Collections;
using System.Text;
using System.Data.Common;

namespace Streaming.connection
{
    class Datos
    {
        public bool VerificarConexion()
        {
            try
            {
                using (OracleConnection conexion = new OracleConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Verificar si la conexión está abierta
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        // Cerrar la conexión
                        conexion.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error de excepción
                Console.WriteLine("Error al verificar la conexión: " + ex.Message);
                return false;
            }
        }

        public bool InsertarDatos(string consulta)
        {
            try
            {
                using (OracleConnection conexion = new OracleConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL
                    using (OracleCommand comando = new OracleCommand(consulta, conexion))
                    {
                        // Ejecutar la consulta
                        comando.ExecuteNonQuery();
                    }

                    // Cerrar la conexión
                    conexion.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error de excepción
                MessageBox.Show("Error al insertar datos: " + ex.Message);
                return false;
            }
        }
        //Creo la cadena de conexion 
        string cadenaConexion = "Data Source = localhost; User ID = cami; Password=oracle";
        public string getCadenaConexion()
        {
            return cadenaConexion;
        }

        //Metodo para ejecutar una sentencia insert , update o delete



        // Método para crear la conexión a la base de datos
        private DbConnection CreateDbConnection()
        {
            // Aquí debes usar el proveedor de datos específico para Oracle (por ejemplo, OracleConnection)
            DbConnection conexion = new OracleConnection(cadenaConexion);
            return conexion;
        }

        // Método para insertar la información en la tabla de Visual Studio
        private void InsertarInformacionEnTabla(DataGridView tablaVisualStudio, string nombreTabla, string nombreColumna, string tipoDato, bool aceptaNulos)
        {
            tablaVisualStudio.Rows.Add(nombreTabla, nombreColumna, tipoDato, aceptaNulos ? "Sí" : "No");
        }
        public void VisualizarTablasNombre( ComboBox comboBoxVisualStudio)
        {
            using (DbConnection conexion = CreateDbConnection())
            {
                // Abrir la conexión
                conexion.Open();

                // Obtener el esquema de las tablas del usuario
                DataTable tablas = conexion.GetSchema("Tables", new[] {  "PARZIVAK" });

                // Limpiar el ComboBox de Visual Studio
                comboBoxVisualStudio.Items.Clear();

                // Recorrer las filas de la tabla de esquema
                for (int i = 0; i < tablas.Rows.Count; i++)
                {
                    // Obtener el nombre de la tabla
                    string nombreTabla = tablas.Rows[i]["TABLE_NAME"].ToString();
                    Console.WriteLine("Tabla: " + nombreTabla);

                    // Obtener la información de columnas para la tabla actual
                    DataTable columnas = conexion.GetSchema("Columns", new[] {"PARZIVAK", nombreTabla });

                    // Crear una cadena de texto para almacenar la información de columnas
                    StringBuilder sb = new StringBuilder();

                    // Recorrer las filas de la tabla de columnas
                    for (int j = 0; j < columnas.Rows.Count; j++)
                    {
                        // Obtener la información de la columna
                        string nombreColumna = columnas.Rows[j]["COLUMN_NAME"].ToString();
                        string tipoDato = columnas.Rows[j]["DATATYPE"].ToString();
                        bool aceptaNulos = columnas.Rows[j]["NULLABLE"].ToString().Equals("YES", StringComparison.OrdinalIgnoreCase);

                        // Agregar la información de la columna a la cadena de texto
                        sb.AppendLine(nombreColumna + " (" + tipoDato + ")" + (aceptaNulos ? " - Acepta nulos" : " - No acepta nulos"));
                    }

                    // Agregar el nombre de la tabla y la información de columnas al ComboBox
                    comboBoxVisualStudio.Items.Add(nombreTabla + ": " + sb.ToString());
                }

                // Cerrar la conexión
                conexion.Close();
            }
        }

        public void VisualizarFuncionesNombre(ComboBox comboBoxVisualStudio)
        {

            using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para obtener las funciones del usuario
                string sql = "SELECT object_name FROM all_objects WHERE object_type = 'FUNCTION' AND owner = 'PARZIVAK'";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar el ComboBox de Visual Studio
                        comboBoxVisualStudio.Items.Clear();

                        while (reader.Read())
                        {
                            string functionName = reader.GetString(0);
                            Console.WriteLine("Función: " + functionName);

                            // Insertar el nombre de la función en el ComboBox
                            comboBoxVisualStudio.Items.Add(functionName);
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();
            }
        }
        public void VisualizarTriggersNombre(ComboBox comboBoxVisualStudio)
        {

            using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para obtener los triggers del usuario específico
                string sql = "SELECT trigger_name FROM all_triggers WHERE owner = 'PARZIVAK'";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar el ComboBox de Visual Studio
                        comboBoxVisualStudio.Items.Clear();

                        while (reader.Read())
                        {
                            string triggerName = reader.GetString(0);
                            Console.WriteLine("Trigger: " + triggerName);

                            // Insertar el nombre del trigger en el ComboBox
                            comboBoxVisualStudio.Items.Add(triggerName);
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();
            }
        }

        public void VisualizarProcedimientosNombre(ComboBox comboBoxVisualStudio)
        {
            using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para obtener los procedimientos del usuario específico
                string sql = "SELECT object_name FROM all_objects WHERE object_type = 'PROCEDURE' AND owner = 'PARZIVAK'";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar el ComboBox de Visual Studio
                        comboBoxVisualStudio.Items.Clear();

                        while (reader.Read())
                        {
                            string procedureName = reader.GetString(0);
                            Console.WriteLine("Procedimiento: " + procedureName);

                            // Insertar el nombre del procedimiento en el ComboBox
                            comboBoxVisualStudio.Items.Add(procedureName);
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();
            }
        }

        public void VisualizarVistasNombre(ComboBox comboBoxVisualStudio )
        {
            using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para obtener las vistas del usuario específico
                string sql = "SELECT view_name FROM all_views WHERE owner = 'PARZIVAK'";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar el ComboBox de Visual Studio
                        comboBoxVisualStudio.Items.Clear();

                        while (reader.Read())
                        {
                            string viewName = reader.GetString(0);
                            Console.WriteLine("Vista: " + viewName);

                            // Insertar el nombre de la vista en el ComboBox
                            comboBoxVisualStudio.Items.Add(viewName);
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();
            }
        }


        public void FillComboBoxWithFilteredTables(ComboBox comboBox)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(cadenaConexion))
                {
                    connection.Open();

                    // Obtener el nombre de todas las tablas del usuario
                    DataTable tables = connection.GetSchema("Tables", new[] { "PARZIVAK" });

                    foreach (DataRow tableRow in tables.Rows)
                    {
                        string tableName = tableRow["TABLE_NAME"].ToString();

                        // Obtener la información de las columnas de la tabla actual
                        DataTable columns = connection.GetSchema("Columns", new[] { "PARZIVAK", tableName });

                        if (columns.Rows.Count > 5)
                        {
                            comboBox.Items.Add(tableName);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}

