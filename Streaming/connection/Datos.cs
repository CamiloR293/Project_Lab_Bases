
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using System.Collections;
using Streaming.logica;
using System.Text;

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
                Console.WriteLine("Error al insertar datos: " + ex.Message);
                return false;
            }
        }
        //Creo la cadena de conexion 
        string cadenaConexion = "Data Source = localhost; User ID = parzivak; Password=oracle";
        public string getCadenaConexion()
        {
            return cadenaConexion;
        }

        //Metodo para ejecutar una sentencia insert , update o delete
        public int ejecutarDML(string consulta)
        {

            int filasAfectadas;
            //paso 1: creo una conexion
            OracleConnection miConexion = new OracleConnection(cadenaConexion);

            //paso 2: creo un comando
            OracleCommand comando = new OracleCommand(consulta, miConexion);

            //paso 3: abrir la conexion
            try
            {
                miConexion.Open();
            }
            catch (Exception E)
            {
                MessageBox.Show("Conexión fallida -->" + E.Message);

            }

            //Paso 4: ejecutar el comando, este me devuelve el 
            //Numero de filas que se afectaron ya sea con el insert,
            //update o delete que le llegaba a la consulta
            try
            {
                filasAfectadas = comando.ExecuteNonQuery();

                //cerrar la conexion
                miConexion.Close();
                return filasAfectadas;
            }
            catch (OracleException E)
            {
                //MessageBox.Show(E.Message);
                if (E.Number == 20001)
                {
                    return E.Number;
                }
                return -1;
            }
        }
        public bool VerificarClienteProductoExistente(int codigoCliente, int codigoProducto)
        {
            try
            {
                using (OracleConnection conexion = new OracleConnection(cadenaConexion))
                {
                    conexion.Open();

                    OracleCommand comando = new OracleCommand();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT COUNT(*) FROM CLIENTE_PRODUCTO_COMPRA WHERE CODIGO_CLIENTE = :p_codigoCliente AND CODIGO_PRODUCTO = :p_codigoProducto";
                    comando.Parameters.Add("p_codigoCliente", OracleDbType.Int32).Value = codigoCliente;
                    comando.Parameters.Add("p_codigoProducto", OracleDbType.Int32).Value = codigoProducto;

                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    conexion.Close();

                    return count > 0;
                }
            }
            catch (OracleException e)
            {
                MessageBox.Show("Error al verificar cliente y producto existente: " + e.Message);
                return false;
            }
        }


        public int idProducto(String nombreProducto)
        {
            string query = "SELECT CODIGO FROM PRODUCTO WHERE NOMBRE = :nombreProducto";

            using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("nombreProducto", nombreProducto));
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return -1; // Valor por defecto si no se encuentra el producto
                    }
                }
            }
        }
            
            public void procedureIdEstadoSuscripcion(int codigoC, int plan, String planDuracion)
        {
            using (OracleConnection connection = new OracleConnection(this.getCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    // Insertar registro
                    OracleCommand insertCommand = new OracleCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO CLIENTE_PLAN (CODIGO, CODIGO_CLIENTE, CODIGO_PLAN, FECHA_COMPRA, FECHA_VENCIMIENTO, ESTADO) VALUES ((select max(codigo)+1 FROM CLIENTE_PLAN), :codigoCliente, :codigoPlan, :fechaCompra, :fechaVencimiento, :estado)";
                    insertCommand.Parameters.Add(":codigoCliente", OracleDbType.Decimal).Value = codigoC; // Código de cliente
                    insertCommand.Parameters.Add(":codigoPlan", OracleDbType.Decimal).Value = plan; // Código de plan
                    insertCommand.Parameters.Add(":fechaCompra", OracleDbType.Date).Value = DateTime.Now; // Fecha de compra
                    if (planDuracion.Equals("Anual"))
                    {
                        insertCommand.Parameters.Add(":fechaVencimiento", OracleDbType.Date).Value = DateTime.Now.AddDays(366); // Fecha de vencimiento

                    }
                    else
                    {
                        insertCommand.Parameters.Add(":fechaVencimiento", OracleDbType.Date).Value = DateTime.Now.AddDays(31); // Fecha de vencimiento
                    }
                    insertCommand.Parameters.Add(":estado", OracleDbType.Varchar2).Value = "ACTIVO"; // Estado
                    insertCommand.ExecuteNonQuery();

                    // Ejecutar procedimiento
                    OracleCommand procedureCommand = new OracleCommand();
                    procedureCommand.Connection = connection;
                    procedureCommand.CommandText = "ACTUALIZAR_ESTADO_CLIENTE_PLAN";
                    procedureCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    procedureCommand.ExecuteNonQuery();

                    Console.WriteLine("Inserción y ejecución del procedimiento completadas correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al realizar la inserción y ejecutar el procedimiento: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public tarjeta BuscarTarjeta(int codigoCliente, string numeroTarjeta)
        {

            using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
            {
                connection.Open();

                string query = "SELECT CLIENTE, CODIGO, NUMEROTARJETA, FECHAEXP, NOMBRETARJETA, CVV, TIPOTARJETA FROM TARJETA WHERE CLIENTE = :cliente AND NUMEROTARJETA = :numeroTarjeta";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("cliente", codigoCliente));
                    command.Parameters.Add(new OracleParameter("numeroTarjeta", numeroTarjeta));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tarjeta tarjeta = new tarjeta()
                            {
                                Cliente = reader.GetInt32(0),
                                Codigo = reader.GetInt32(1),
                                NumeroTarjeta = reader.GetString(2),
                                FechaExpiracion = reader.GetDateTime(3),
                                NombreTarjeta = reader.GetString(4),
                                CVV = reader.GetString(5),
                                TipoTarjeta = reader.GetString(6)
                            };

                            return tarjeta;
                        }
                    }
                }
            }

            return null; // Si no se encuentra la tarjeta, se retorna null
        }
        public ArrayList MostrarDatosVistaClienteTarjeta(int codigoCliente)
        {
            VistaTarjeta relacionTarjetaCliente;
            ArrayList list = new ArrayList();

            using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
            {
                try
                {
                    connection.Open();

                    // Consulta para seleccionar los registros de la vista CLIENTE_TARJETA para un cliente específico
                    string query = $"SELECT CODIGO, PRIMERNOMBRE, PRIMERAPELLIDO, NUMEROTARJETA, NOMBRETARJETA FROM VISTA_CLIENTE_TARJETA WHERE CODIGO = {codigoCliente}";

                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Mostrar los datos en tu aplicación
                    // Puedes asignar los valores a controles de interfaz de usuario como etiquetas o cuadros de texto
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string codigo = row["CODIGO"].ToString();
                        string primerNombre = row["PRIMERNOMBRE"].ToString();
                        string primerApellido = row["PRIMERAPELLIDO"].ToString();
                        string numeroTarjeta = row["NUMEROTARJETA"].ToString();
                        string nombreTarjeta = row["NOMBRETARJETA"].ToString();
                        relacionTarjetaCliente = new VistaTarjeta(codigo, primerNombre, primerApellido, numeroTarjeta, nombreTarjeta);
                        list.Add(relacionTarjetaCliente);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos de la vista CLIENTE_TARJETA: " + ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public int procedureIdAdmin(string usuario)
        {
            int id = 0;
            OracleConnection miConexion = new OracleConnection(cadenaConexion);
            try
            {
                miConexion.Open();
            }
            catch (Exception E)
            {
                MessageBox.Show("Conexión fallida -->" + E.Message);

            }
            using (OracleCommand command = new OracleCommand("obtener_id_admin", miConexion))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = usuario;
                command.Parameters.Add("p_id", OracleDbType.Int32).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                OracleDecimal oracleDecimal = (OracleDecimal)command.Parameters["p_id"].Value;
                id = oracleDecimal.ToInt32();
            }

            return id;
        }
        public void ObtenerActoresProducto(int codigoProducto, OracleConnection connection)
        {
            try
            {
                using (OracleCommand command = new OracleCommand("lista_actores_producto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    command.Parameters.Add("v_idProducto", OracleDbType.Int32).Value = codigoProducto;

                    // Parámetros de salida
                    command.Parameters.Add("table_plan", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    command.Parameters.Add("v_genero", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    // Obtener los resultados
                    OracleDataReader reader = ((OracleRefCursor)command.Parameters["table_plan"].Value).GetDataReader();
                    string genero = command.Parameters["v_genero"].Value.ToString();

                    Console.WriteLine("ACTORES QUE PARTICIPAN EN LA PELÍCULA:");
                    Console.WriteLine("-------------------------------------");

                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                        int codigo = Convert.ToInt32(reader["CODIGO"]);
                        string primerNombre = reader["PRIMERNOMBRE"].ToString();
                        string segundoNombre = reader["SEGUNDONOMBRE"].ToString();
                        string primerApellido = reader["PRIMERAPELLIDO"].ToString();
                        string segundoApellido = reader["SEGUNDOAPELLIDO"].ToString();
                        DateTime fechaNacimiento = Convert.ToDateTime(reader["FECHANACIMIENTO"]);
                        string papel = reader["PAPEL"].ToString();

                        Console.WriteLine($"CÓDIGO: {codigo}");
                        Console.WriteLine($"NOMBRES: {primerNombre} {segundoNombre}");
                        Console.WriteLine($"APELLIDOS: {primerApellido} {segundoApellido}");
                        Console.WriteLine($"FECHA DE NACIMIENTO: {fechaNacimiento}");
                        Console.WriteLine($"PAPEL: {papel}");
                        Console.WriteLine("-------------------------------------");
                    }

                    Console.WriteLine($"En la película hay {count} actores");

                    if (count > 0)
                    {
                        Console.WriteLine("LOS ACTORES TAMBIÉN PARTICIPAN EN LAS SIGUIENTES PELÍCULAS:");
                        Console.WriteLine("-------------------------------------");

                        reader.NextResult();
                        while (reader.Read())
                        {
                            string nombrePelicula = reader["NOMBRE"].ToString();
                            Console.WriteLine($"NOMBRE: {nombrePelicula}");
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los actores del producto: " + ex.Message);
            }
        }

        //Metodo para ejecutar sentencias select
        public DataSet ejecutarSELECT(string consulta)
        {
            //Paso 1: Creo un dataset vacio
            DataSet ds = new DataSet();

            //Paso 2: Creo un adaptador 
            OracleDataAdapter adaptador = new OracleDataAdapter(consulta, cadenaConexion);

            //Paso 3: LLeno el dataset ds a traves del adaptador
            adaptador.Fill(ds, "ResultadoDatos");
            return ds;
        }
        public void obtenerPeliculas(ComboBox cmbBoxPelicula)
        {
            try
            {
                using (OracleConnection miConexion = new OracleConnection(cadenaConexion))
                {
                    miConexion.Open();
                    string consulta = "select nombre from producto";
                    OracleCommand comando = new OracleCommand(consulta, miConexion);
                    OracleDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        string nombrePelicula = reader.GetString(0);
                        cmbBoxPelicula.Items.Add(nombrePelicula);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void obtenerActores(ComboBox cmbBoxActores)
        {
            try
            {
                using (OracleConnection miConexion = new OracleConnection(cadenaConexion))
                {
                    miConexion.Open();
                    string consulta = "SELECT primernombre, primerapellido FROM actor";
                    OracleCommand comando = new OracleCommand(consulta, miConexion);
                    OracleDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        string nombreActor = reader.GetString(0);
                        string primerApellidoActor = reader.GetString(1);
                        cmbBoxActores.Items.Add(nombreActor + " " + primerApellidoActor);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void procedimientoObtenerActores(ComboBox cmbBoxActores, string nombrePelicula)
        {

            try
            {
                // Crear una instancia de OracleConnection y OracleCommand
                using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
                {
                    using (OracleCommand command = new OracleCommand("MostrarActoresPelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro de entrada
                        OracleParameter nombrePeliculaParam = new OracleParameter("p_nombre_pelicula", OracleDbType.Varchar2);
                        nombrePeliculaParam.Direction = ParameterDirection.Input;
                        nombrePeliculaParam.Value = nombrePelicula;
                        command.Parameters.Add(nombrePeliculaParam);

                        // Agregar parámetro de salida
                        OracleParameter actoresCursorParam = new OracleParameter();
                        actoresCursorParam.ParameterName = "p_cursor";
                        actoresCursorParam.Direction = ParameterDirection.Output;
                        actoresCursorParam.OracleDbType = OracleDbType.RefCursor;
                        command.Parameters.Add(actoresCursorParam);

                        // Abrir la conexión a la base de datos
                        connection.Open();

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();

                        // Obtener el cursor de salida con los resultados
                        OracleDataReader reader = ((OracleRefCursor)actoresCursorParam.Value).GetDataReader();

                        // Limpiar el ComboBox
                        cmbBoxActores.Items.Clear();

                        // Recorrer el cursor y agregar los nombres de los actores al ComboBox
                        while (reader.Read())
                        {
                            string nombreActor = reader.GetString(0);
                            cmbBoxActores.Items.Add(nombreActor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción ocurrida
                Console.WriteLine("Error al obtener los actores: " + ex.Message);
            }
        }

        public void obtenerCoincidenciasGeneroTodosActores(ComboBox cmbBoxProductos, int codigoProducto)
        {

            try
            {
                // Crear una instancia de OracleConnection y OracleCommand
                using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
                {
                    using (OracleCommand command = new OracleCommand("ObtenerCoincidenciasGeneroTodosActores", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro de entrada
                        OracleParameter codigoProductoParam = new OracleParameter("p_codigo_producto", OracleDbType.Decimal);
                        codigoProductoParam.Direction = ParameterDirection.Input;
                        codigoProductoParam.Value = codigoProducto;
                        command.Parameters.Add(codigoProductoParam);

                        // Agregar parámetro de salida
                        OracleParameter productosCursorParam = new OracleParameter();
                        productosCursorParam.ParameterName = "p_cursor";
                        productosCursorParam.Direction = ParameterDirection.Output;
                        productosCursorParam.OracleDbType = OracleDbType.RefCursor;
                        command.Parameters.Add(productosCursorParam);

                        // Abrir la conexión a la base de datos
                        connection.Open();

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();

                        // Obtener el cursor de salida con los resultados
                        OracleDataReader reader = ((OracleRefCursor)productosCursorParam.Value).GetDataReader();

                        // Limpiar el ComboBox
                        cmbBoxProductos.Items.Clear();

                        // Recorrer el cursor y agregar los nombres de los productos al ComboBox
                        while (reader.Read())
                        {
                            string nombreProducto = reader["NOMBRE"].ToString();
                            cmbBoxProductos.Items.Add(nombreProducto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción ocurrida
                MessageBox.Show("Error al obtener las coincidencias de productos: " + ex.Message);
            }
        }

        public ArrayList obtenerCoincidenciasGeneroTodosActores(int codigoProducto)
        {
            ArrayList listaProductos = new ArrayList();
            producto p;


            try
            {
                // Crear una instancia de OracleConnection y OracleCommand
                using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
                {
                    using (OracleCommand command = new OracleCommand("ObtenerCoincidenciasGeneroTodosActores", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro de entrada
                        OracleParameter codigoProductoParam = new OracleParameter("p_codigo_producto", OracleDbType.Decimal);
                        codigoProductoParam.Direction = ParameterDirection.Input;
                        codigoProductoParam.Value = codigoProducto;
                        command.Parameters.Add(codigoProductoParam);

                        // Agregar parámetro de salida
                        OracleParameter productosCursorParam = new OracleParameter();
                        productosCursorParam.ParameterName = "p_cursor";
                        productosCursorParam.Direction = ParameterDirection.Output;
                        productosCursorParam.OracleDbType = OracleDbType.RefCursor;
                        command.Parameters.Add(productosCursorParam);

                        // Abrir la conexión a la base de datos
                        connection.Open();

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();

                        // Obtener el cursor de salida con los resultados
                        OracleDataReader reader = ((OracleRefCursor)productosCursorParam.Value).GetDataReader();

                        // Recorrer el cursor y agregar los nombres de los productos al ArrayList
                        while (reader.Read())
                        {
                            int codigoproducto = int.Parse(reader.GetString(0));
                            string  nombre=reader.GetString(2);
                            string genero=reader.GetString(6);
                            p =  new producto(codigoproducto, nombre, genero);
                            listaProductos.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción ocurrida
                MessageBox.Show("Error al obtener las coincidencias de productos: " + ex.Message);
            }

            return listaProductos;
        }
        public int ObtenerCodigoActor(string primerNombre, string primerApellido)
        {
            int codigoActor = 0;

            try
            {
                using (OracleConnection miConexion = new OracleConnection(cadenaConexion))
                {
                    miConexion.Open();
                    string consulta = "SELECT codigo FROM actor WHERE primernombre = :primerNombre AND primerapellido = :primerApellido";
                    OracleCommand comando = new OracleCommand(consulta, miConexion);
                    comando.Parameters.Add(new OracleParameter("primerNombre", primerNombre));
                    comando.Parameters.Add(new OracleParameter("primerApellido", primerApellido));
                    OracleDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        string codigoActorStr = reader.GetString(0);
                        int.TryParse(codigoActorStr, out codigoActor);
                    }

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("error al actualizar ->" + e.Message);
            }
            return codigoActor;
        }
        public int EjecutarProcedimiento(string nombreProducto)
        {
            try
            {
                using (OracleConnection conexion = new OracleConnection(cadenaConexion))
                {
                    conexion.Open();

                    OracleCommand comando = new OracleCommand();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "calcularPrecioProducto";

                    comando.Parameters.Add("p_nombreProducto", OracleDbType.Varchar2).Value = nombreProducto;

                    // Parámetro de salida para capturar el resultado
                    comando.Parameters.Add("p_precioFinal", OracleDbType.Decimal).Direction = ParameterDirection.Output;

                    comando.ExecuteNonQuery();
                    OracleDecimal resultadoOracle = (OracleDecimal)comando.Parameters["p_precioFinal"].Value;
                    return resultadoOracle.ToInt32();
                    conexion.Close();
                    // MessageBox.Show("Precio Final: " + precioFinal);


                }
            }
            catch (OracleException e)
            {
                MessageBox.Show("Error en el procedimiento: " + e.Message);
                return -1;
            }
        }


        public ArrayList obtenerListaPorHistorial(int codigoCliente)
        {
            ArrayList listaPeliculas = new ArrayList();
            producto p;


            try
            {
                // Crear una instancia de OracleConnection y OracleCommand
                using (OracleConnection connection = new OracleConnection(this.cadenaConexion))
                {
                    using (OracleCommand command = new OracleCommand("PQU_FUNCIONES.obtener_recomendados", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro de entrada
                        OracleParameter codigoProductoParam = new OracleParameter("PRM_COD_CLIENTE", OracleDbType.Decimal);
                        codigoProductoParam.Direction = ParameterDirection.Input;
                        codigoProductoParam.Value = codigoCliente;
                        command.Parameters.Add(codigoProductoParam);

                        // Agregar parámetro de salida
                        OracleParameter prmCursorPeliculas = new OracleParameter();
                        prmCursorPeliculas.ParameterName = "PRM_PELICULAS";
                        prmCursorPeliculas.Direction = ParameterDirection.Output;
                        prmCursorPeliculas.OracleDbType = OracleDbType.RefCursor;
                        command.Parameters.Add(prmCursorPeliculas);

                        // Abrir la conexión a la base de datos
                        connection.Open();

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();

                        // Obtener el cursor de salida con los resultados
                        OracleDataReader reader = ((OracleRefCursor)prmCursorPeliculas.Value).GetDataReader();

                        // Recorrer el cursor y agregar los nombres de los productos al ArrayList
                        while (reader.Read())
                        {
                            int codigoproducto = int.Parse(reader.GetString(0));
                            string nombre = reader.GetString(2);
                            string genero = reader.GetString(6);
                            p = new producto(codigoproducto, nombre, genero);
                            listaPeliculas.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción ocurrida
                MessageBox.Show("Error al obtener las recomendaciones: " + ex.Message);
            }

            return listaPeliculas;
        }



    }
}
