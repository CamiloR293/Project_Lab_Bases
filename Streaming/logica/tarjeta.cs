using Oracle.ManagedDataAccess.Client;
using Streaming.connection;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Streaming.logica
{
    internal class tarjeta
    {
        public int Cliente { get; set; }
        public int Codigo { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTarjeta { get; set; }
        public string CVV { get; set; }
        public string TipoTarjeta { get; set; }


        Datos dt = new Datos();
        public tarjeta BuscarTarjeta(int codigoCliente, string numeroTarjeta)
        {
            return dt.BuscarTarjeta(codigoCliente, numeroTarjeta);
        }
        public int ingresartarjeta(string numerotarjeta,
         string fechaexp, string nombretarjeta, string cvv, string tipotarjeta)
        {
            int resultado;
            string consulta;
            consulta = "insert into tarjeta values((select max(codigo) from CLIENTE)," +
                        "(select nvl(max(codigo) + 1, 1) from TARJETA), '" + numerotarjeta + "', '" + fechaexp + "', '" + 
                        nombretarjeta + "', '" + cvv + "', '" + tipotarjeta + "')";
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public int ingresartarjetaLogin(int idCliente, string numerotarjeta,
            string fechaexp, string nombretarjeta, string cvv, string tipotarjeta)
        {
            int resultado;
            string consulta;
            consulta = "insert into tarjeta values(" + idCliente + ",(select max(codigo + 1) from TARJETA), '" + numerotarjeta + "', '" + fechaexp + "', '" + nombretarjeta + "', '" + cvv + "', '" + tipotarjeta + "')";
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public DataSet consultarTarjeta()
        {
            DataSet miDs = new DataSet();
            string consulta;
            consulta = "select * from tarjeta";
            miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }

        /*      public  void implementacionTriggerTarjetaVencida(int verificador, Cliente cliente)
              {
                  using (Oracle.ManagedDataAccess.Client.OracleConnection connection = new Oracle.ManagedDataAccess.Client.OracleConnection(dt.getCadenaConexion()))
                  {
                      connection.Open();
                      Oracle.ManagedDataAccess.Client.OracleTransaction transaction = connection.BeginTransaction();


                      if (verificador > 0)
                      {
                          Oracle.ManagedDataAccess.Client.OracleCommand command = new Oracle.ManagedDataAccess.Client.OracleCommand();
                          command.Connection = connection;
                          command.CommandText = "SELECT FECHA_VENCIMIENTO FROM CLIENTE_PLAN WHERE CODIGO_CLIENTE = :CodigoCliente";
                          command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter(":CodigoCliente", OracleDbType.Int32)).Value = cliente.Codigo;

                          Oracle.ManagedDataAccess.Client.OracleDataReader reader = command.ExecuteReader();
                          if (reader.Read())
                          {
                              DateTime fechaVencimiento = reader.GetDateTime(0);

                              // Verificar si la suscripción ha vencido
                              if (fechaVencimiento < DateTime.Now)
                              {
                                  // Si ha vencido, mostrar el mensaje de vencimiento y abortar la transacción
                                  MessageBox.Show("La suscripción del cliente ha vencido. Por favor renovar para disfrutar del contenido :)", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                  transaction.Rollback();
                                  return;
                              }
                          }
                          reader.Close();

                          // Si la suscripción no ha vencido, confirmar la transacción
                          transaction.Commit();
                          MessageBox.Show("Tarjeta registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                      }
                      else
                      {
                          // Si no se ha completado el proceso satisfactoriamente, abortar la transacción
                          MessageBox.Show("No se ha completado el proceso satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          transaction.Rollback();
                      }

                  }
              }*/
    }
}