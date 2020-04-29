using System;
using System.Data.Odbc;

namespace Prototipo2P.Conexion
{
    public class Conexion
    {
        OdbcConnection conn;
        public string nombreBd { get; set; }

        public Conexion(string nombreBd)
        {
            this.nombreBd = nombreBd;
        }

        public Tuple<OdbcConnection, OdbcTransaction> conexion()
        {
            conn = new OdbcConnection("Dsn="+nombreBd);// creacion de la conexion via ODBC
            OdbcTransaction transaccion = null;
            try
            {
                conn.Open();
                transaccion = conn.BeginTransaction();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }

            return Tuple.Create(conn, transaccion);
        }

        public void desconexion()
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }

        }
    }
}
