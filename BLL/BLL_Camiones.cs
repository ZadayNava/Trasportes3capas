using DAL_CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Camiones
    {
        //Create
        public static string Insert_Camion(Camiones_VO camiones)
        {
            return DAL_Camiones.Insert_Camion(camiones);
        }

        //Read
        public static List<Camiones_VO> GetCamiones(params object[] parametros)
        {
            return DAL_Camiones.GetCamiones(parametros);
        }

        //ReadxID
        public static Camiones_VO GetCamionesxID(int id)
        {
            return DAL_Camiones.GetCamionesxID(id);
        }
        //Update
        public static string Update_Camiones(Camiones_VO camiones)
        {
            return DAL_Camiones.Update_Camiones(camiones);
        }
        //Delete
        public static string Delete_Camion(int id)
        {
            return DAL_Camiones.Delete_Camion(id);
        }
    }
}
