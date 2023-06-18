using Streaming.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.logica
{
    internal class clienteplan
    {
        Datos dt = new Datos();

        public int ingresarRelacionClientePlan(string fechaVencimiento)
        {
            int resultado;
            string consulta;
            consulta = "insert into cliente " +
                "values((select max(codigo + 1) from CLIENTE_PLAN),(select max(codigo) from CLIENTE), 4, to_Date(sysdate,'dd-mm-yyyy')), to_Date('" + fechaVencimiento + "','dd-mm-yyyy'))";
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public DataSet consultarRegistro()
        {
            string consulta;
            consulta = "select * from Registro";
            DataSet miDs = dt.ejecutarSELECT(consulta);
            return miDs;
        }
    }
}
