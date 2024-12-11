using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VO;

namespace DAL_CapaAccesoDatos
{
    public class DAL_Camiones
    {
        //Create
        public static string Insert_Camion(Camiones_VO camiones)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_ADD_Camiones",
                    "@matricula", camiones.Matricula,
                    "@tipo_camion", camiones.Tipo_camion,
                    "@marca", camiones.Marca,
                    "@modelo",camiones.Modelo,
                    "@capacidad", camiones.Capacidad,
                    "@kilometraje", camiones.Kilometraje,
                    "@urlFoto", camiones.UrlFoto,
                    "@Disponibilidad", camiones.Disponibilidad
                    );
                if (respuesta != 0)
                {
                    salida = "Camion registrado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: { e.Message}";
            }
            return salida;
        }
        //Read
        public static List<Camiones_VO> GetCamiones(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_camiones = Metodos_Datos.execute_DataSet("SP_ListarCamiones", parametros);
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

        //Read
        public static Camiones_VO GetCamionesxID(int id)
        {
            //creo una lista de objetos vo
            Camiones_VO list = new Camiones_VO();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_camiones = Metodos_Datos.execute_DataSet("SP_ListarCamiones", "@Id_camion", id);
                //recorro cada renglon existente de nuestro ds creando obetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list = new Camiones_VO(dr);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Update
        public static string Update_Camiones(Camiones_VO camiones)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_UpdateCamion",
                    "@matricula", camiones.Matricula,
                    "@tipo_camion", camiones.Tipo_camion,
                    "@marca", camiones.Marca,
                    "@modelo", camiones.Modelo,
                    "@capacidad", camiones.Capacidad,
                    "@kilometraje", camiones.Kilometraje,
                    "@urlFoto", camiones.UrlFoto,
                    "@Disponibilidad", camiones.Disponibilidad
                    );

                if (respuesta != 0)
                {
                    salida = "Camion actualizado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }
        //Delete
        public static string Delete_Camion(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_DelateCamion",
                    "@Id_camion", id
                    );
                if (respuesta != 0)
                {
                    salida = "Camion elimiado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }
    }
}
