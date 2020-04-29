using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo2P.Objetos
{
    public class Objetos { }

    public class MovimientoEncabezado
    {
        public int CODIGO { get; set; }
        public Tipomovimiento TIPO { get; set; }
        public DateTime FECHA { get; set; }
        public int ESTADO { get; set; }
    }

    public class MovimientoDetalle
    {
        public MovimientoEncabezado MOVIMEINTO { get; set; }
        public Producto PRODUCTO { get; set; }
        public int CANTIDAD { get; set; }
    }

    public class Producto
    {
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public int EXISTENCIAS { get; set; }
        public int ESTADO { get; set; }
    }

    public class Tipomovimiento
    {
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string SIGNO { get; set; }
        public int ESTADO { get; set; }
    }
}
