using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CapaAccesoDatos
{
    public class Configuracion
    {
        /*Cadena de conexion
        Data source = nombre del servidor de BD
        localhost
        .
        nombre de mi instancia
         initial Catalog = nombre de la bd
        integrated security = true (credenciales de la maquina)
        = false (credenciales de acceso)
        Se habilitan los campos de 
            user = ;
            password = ;*/
                                                        //este es el nombre de tu conexio de la BD
        static string _cadenaConexion = @"Data Source = SADAY\SQLEXPRESS
                                          Initial Catalog = Transportes
                                          Integrated Security = true;";
        
        //Encapsulamietos
        public static string CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }
    }
}
