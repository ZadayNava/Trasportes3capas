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

        //Read
        public static List<Camiones_VO> GetCamiones(params object[] parametros)
        {
            return DAL_Camiones.GetCamiones(parametros);
        }
        //Update

        //Delete
    }
}
