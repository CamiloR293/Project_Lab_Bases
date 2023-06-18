using Streaming.connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streaming.logica
{
    internal class clienteProducto
    {
        Datos dt=new Datos();
        public int ingresarproducto(int codigoC, int codigoP)
        {
            int resultado;
            string consulta;
            consulta = "insert into cliente_producto_compra (CODIGO_CLIENTE, CODIGO_PRODUCTO, FECHA_COMPRA,CODIGO_CLIENTE_PRODUCTO)  values(" + codigoC+"," + codigoP +", sysdate,(select NVL(max(codigo_cliente_producto) +1,1) from cliente_producto_compra))" ;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public int ingresarAlHistorialVistas(int codigoC, int codigoP)
        {
            int resultado;
            string consulta;
            consulta = "insert into cliente_producto(codigo_cliente,codigo_producto,codigo_reproduccion,fecha_reproduccion)values(" + codigoC + "," + codigoP + ",(select max(codigo_reproduccion)+1 from cliente_producto),sysdate)";
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
    }
}
