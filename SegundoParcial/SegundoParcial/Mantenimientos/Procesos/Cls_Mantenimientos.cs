using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Mantenimientos.Procesos
{
    public class Cls_Mantenimientos
    {
        /*
         ID DE TABLAS:
            1 = 
            2 = 
            3 = 
            4 = 
            5 = 

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
                    string[] alias1 = { "", "", "", "", "" };
                    return (alias1, "1", "", "de ", "", 0);

                case 2:
                    string[] alias2 = { "", "", "" };
                    return (alias2, "1", "", "de ", "", 0);
                   
                case 3:
                    string[] alias3 = { "", "", "", "" };
                    return (alias3, "1", "", "de ", "", 0);
                    
                case 4:
                    string[] alias4 = { "", "", "", "" };
                    return (alias4, "1", "", "de ", "", 0);

                case 5:
                    string[] alias5 = { "", "", "" };
                    return (alias5, "1", "", "de ", "", 0);

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
                            return ("", "", 1);
                    }
                    break;

                //
                case 5:
                    switch (no)
                    {
                        case 1:
                            return ("", "", 0);
                    }
                    break;

                //
                case 7:
                    switch (no)
                    {
                        case 1:
                            return ("", "", 0);
                    }
                    break;

                default:
                    break;
            }
            return ("", "", 0);
        }

    }
}
