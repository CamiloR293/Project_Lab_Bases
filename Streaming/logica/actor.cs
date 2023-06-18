using Streaming.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streaming.logica
{
    internal class actor
    {
        Datos dt = new Datos();

        public int ingresarActor(string primernombre, string segundonombre,
            string primerapellido, string segundoapellido, string fechanacimiento)
        {
            int resultado;
            string consulta = "insert into actor values((select nvl(max(codigo) + 1, 1) from actor), '" + primernombre + "', '" + segundonombre + "', '"
                + primerapellido + "', '" + segundoapellido + "', " + "to_Date('" + fechanacimiento + "','dd/mm/yyyy'))";
            //MessageBox.Show(consulta);
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultaActor()
        {
            DataSet miDs = new DataSet();
            string consulta;
            consulta = "select * from actor";
            miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }
        public int registrarProductoActor(string papel)
        {
            string consulta = "insert into actor_producto values (select max(codigo) from actor, select max(codigo) from producto, '" + 
                                papel + "');";
            int resultado;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public int registrarProductoActor(string producto, string papel)
        {
            string consulta = "insert into actor_producto values ((select max(codigo) from actor), (select codigo from producto where nombre = '" + producto
                                + "'),'" + papel + "')";
            int resultado;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public int actualizarActor(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string fechaNacimiento, int codigo)
        {
            string consulta = "update actor set primernombre = '" + primerNombre + "', segundonombre = '" + 
                                segundoNombre + "', primerapellido = '" + primerApellido + "', segundoapellido = '" +
                                segundoApellido + "', fechanacimiento = '" + fechaNacimiento + "' where codigo = " + codigo;
            int resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public int eliminarActor(int codigo)
        {
            string consulta = "delete from actor where codigo = " + codigo;
            int resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
    }
}

