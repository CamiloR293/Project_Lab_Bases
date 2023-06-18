using Streaming.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Streaming.logica
{
    internal class cliente_plan
    {
        Datos dt = new Datos();

        public void ingresarRelacionClientePlan(int codigoCliente,int codigoPlan, String plan)
        {
            dt.procedureIdEstadoSuscripcion(codigoCliente, codigoPlan,plan);
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

