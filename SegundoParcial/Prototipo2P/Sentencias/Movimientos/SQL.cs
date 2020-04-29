using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototipo2P.Conexion;
using Prototipo2P.Objetos;

namespace Prototipo2P.Sentencias.Movimientos
{
    public class SQL
    {
        transaccion transaccion = new transaccion("sic");

        public List<MovimientoEncabezado> obtenerEncabezados()
        {
            List<MovimientoEncabezado> movimientoEncabezadoList = new List<MovimientoEncabezado>();

            try
            {
                string sComando = string.Format("SELECT codigo_movimiento, codigo_tipo_movimiento, fecha_movimiento, ESTADO " +
                    "FROM movimientos_inventario_enc;");

                OdbcDataReader reader = transaccion.ConsultarDatos(sComando);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MovimientoEncabezado movimientoEncabezadoTmp = new MovimientoEncabezado();
                        movimientoEncabezadoTmp.CODIGO = reader.GetInt32(0);
                        movimientoEncabezadoTmp.TIPO = obtenerTipoMovimiento(reader.GetInt32(1));
                        movimientoEncabezadoTmp.FECHA = reader.GetDate(2);
                        movimientoEncabezadoTmp.ESTADO = reader.GetInt32(3);
                        movimientoEncabezadoList.Add(movimientoEncabezadoTmp);
                    }
                }
                return movimientoEncabezadoList;
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error en la operacion con la Base de Datos: \n" + ex.Message);
                return null;
            }
        }

        public Tipomovimiento obtenerTipoMovimiento(int codigo)
        {
            Tipomovimiento tipomovimiento = new Tipomovimiento();

            try
            {
                string sComando = string.Format("SELECT tipo_movimiento, signo, ESTADO " +
                    "FROM tipo_movimiento;");

                OdbcDataReader reader = transaccion.ConsultarDatos(sComando);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tipomovimiento.NOMBRE = reader.GetString(0);
                        tipomovimiento.SIGNO = reader.GetString(1);
                        tipomovimiento.ESTADO = reader.GetInt32(2);
                    }
                }
                return tipomovimiento;
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error en la operacion con la Base de Datos: \n" + ex.Message);
                return null;
            }
        }

    }
}
