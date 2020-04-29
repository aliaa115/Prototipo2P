using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo2P.Mantenimientos.Procesos
{
    public class Cls_Mantenimientos
    {
        /*
         ID DE TABLAS:
            1 = productos
            2 = clientes
            3 = proveedores
            4 = lineas
            5 = marcas
            6 = vendedores

        ORDEN DE LOS DATOS EN RETURN PARA datos:
            1 = alias
            2 = ayuda
            3 = tabla
            4 = form
            5 = nombre
            6 = noForaneas
            
        ORDEN DE LOS DATOS EN RETURN PARA foraneas:
            1 = tabla
            2 = campo
            3 = modo
             */
        public (string[], string, string, string, string, int) datos(int tabla)
        {
            switch (tabla)
            {
                case 1:
                    string[] alias1 = { "Codigo", "Nombre", "Linea", "Marca", "Existencias", "Estado" };
                    return (alias1, "1", "productos", "de Productos", "PRODUCTO", 2);

                case 2:
                    string[] alias2 = { "Codigo", "Nombre", "Direccion", "Nit", "Telefono", "Vendedor", "Estado" };
                    return (alias2, "1", "clientes", "de Clientes", "CLIENTE", 1);
                   
                case 3:
                    string[] alias3 = { "Codigo", "Nombre", "Direccion", "Telefono", "Nit", "Estado" };
                    return (alias3, "1", "proveedores", "de Proveedores", "PROVEEDOR", 0);
                    
                case 4:
                    string[] alias4 = { "Codigo", "Nombre", "Estado" };
                    return (alias4, "1", "lineas", "de Lineas", "LINEA", 0);

                case 5:
                    string[] alias5 = { "Codigo", "Nombre", "Estado" };
                    return (alias5, "1", "marcas", "de Marcas", "MARCA", 0);

                case 6:
                    string[] alias6 = { "Codigo", "Nombre", "Direccion", "Telefono", "Nit", "Estado" };
                    return (alias6, "1", "vendedores", "de Vendedores", "VENDEDOR", 0);

                default:
                    break;
            }
            return (null, null, null, null, null, 0);
        }

        public (string, string, int) foraneas(int tabla, int no)
        {
            switch (tabla)
            {
                //
                case 1:
                    switch (no)
                    {
                        case 1:
                            return ("lineas", "nombre_linea", 1);
                        case 2:
                            return ("marcas", "nombre_marca", 1);
                    }
                    break;

                //
                case 2:
                    switch (no)
                    {
                        case 1:
                            return ("vendedores", "nombre_vendedor", 1);
                    }
                    break;

                default:
                    break;
            }
            return ("", "", 0);
        }

    }
}
