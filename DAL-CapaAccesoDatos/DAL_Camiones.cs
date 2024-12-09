using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL_CapaAccesoDatos
{
    public class DAL_Camiones
    {
        //Create

        //Read
        public static List<Camiones_VO> GetCamiones(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_camiones = Metodos_Datos.execute_DataSet("Sp_Listar_camiones", parametros);
                //recorro cada renglon existente de nuestro ds creando obetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list.Add(new Camiones_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Update

        //Delete
    }
}
