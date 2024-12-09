using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CapaAccesoDatos
{
    internal class Metodos_Datos
    {
        /*metodo para ejecutar un dataset
         Utilizado para ejecutar una consulta sql que devuelve un conjunto de datos
        que puede contener una o varias tablas co filas y columnas de datos*/
        public static DataSet execute_DataSet(string sp, params object[] parametros)
        {
            //intancia un DS (DataSet) => Objet de ADO
            DataSet ds = new DataSet();
            //obtenemos la cadena de conexio
            string conn = Configuracion.CadenaConexion;
            //creamos ua conexio => SqlConnection Object de ADO
            SqlConnection SQLconn = new SqlConnection(conn);
            try
            {
                //verificamos si la conexion esta abierta
                if (SQLconn.State == ConnectionState.Open)
                {
                    //cerramos la conexion para cerrar antes de entrar
                    SQLconn.Close();
                }
                else
                {
                    //comando para SQL(sp, conexion) => SqlCommand objeto de ADO(access data object)
                    SqlCommand cmd = new SqlCommand(sp,SQLconn);
                    //defino que el comando sera ejecutado como una SP (StoreProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;//es mas seguro usar sp que text u otro
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y estan completos los parametros
                    //si es diferente de null y su residuo es diferente de 0
                    //parametros = {calve:valor}
                    if (parametros != null && parametros.Length % 2 != 0) 
                    {
                        throw new Exception("Los parametros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i++)
                        {
                            //sqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i+1].ToString());
                        }
                        //abrimos la conexion
                        SQLconn.Open();
                        /*ejecutamos el comando
                         * SqlDataAdapter => Objeto de ADO                        */
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llenamos el ds
                        adapter.Fill(ds);
                        //creamos la conexion
                        SQLconn.Close();
                    }
                }
                //Retorno el DS (DataSet)
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //verificamos si la conexion esta abierta
                if (SQLconn.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLconn.Close();
                }
            }
        }

        /*
         *Metodo que ejecuta un escalar
         *ejecuta una consulta sql que devuelve usolo valor o una sola columna de dats.
         *retorna el valor e la primera columna y a primera fila del conjunto de resultados
         */
        public static int execute_Scalar(string sp, params object[] parametros)
        {
            //intancia un entero
            int id = 0;
            //obtenemos la cadena de conexio
            string conn = Configuracion.CadenaConexion;
            //creamos ua conexio => SqlConnection Object de ADO
            SqlConnection SQLconn = new SqlConnection(conn);
            try
            {
                //verificamos si la conexion esta abierta
                if (SQLconn.State == ConnectionState.Open)
                {
                    //cerramos la conexion para cerrar antes de entrar
                    SQLconn.Close();
                }
                else
                {
                    //comando para SQL(sp, conexion) => SqlCommand objeto de ADO(access data object)
                    SqlCommand cmd = new SqlCommand(sp, SQLconn);
                    //defino que el comando sera ejecutado como una SP (StoreProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;//es mas seguro usar sp que text u otro
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    /*validamos si existen y estan completos los parametros
                    si es diferente de null y su residuo es diferente de 0
                    parametros = {calve:valor}*/
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i++)
                        {
                            //sqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        //abrimos la conexion
                        SQLconn.Open();
                        //ejecutar el comando de forma que reciba un scalar
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        //creamos la conexion
                        SQLconn.Close();
                    }
                }
                //Retorno el DS (DataSet)
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexion esta abierta
                if (SQLconn.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLconn.Close();
                }
            }
        }

        /*
         * Metodo que ejecuta un NonQuery
         * utilizado para ejecutar consultas sql que no devuelve un conjunto de resultados.
         * como setencias INSERT,UPDATE O DLETE
         * retorna un valor entero que representa el numero de filas afectadas por la operacion
         * (por ejemplo, el numoer de filas insertadas, actualizadas o eliminadas)
         */

        public static int execute_nonQuery(string sp, params object[] parametros)
        {
            //intancia un entero
            int id = 0;
            //obtenemos la cadena de conexio
            string conn = Configuracion.CadenaConexion;
            //creamos ua conexio => SqlConnection Object de ADO
            SqlConnection SQLconn = new SqlConnection(conn);
            try
            {
                //verificamos si la conexion esta abierta
                if (SQLconn.State == ConnectionState.Open)
                {
                    //cerramos la conexion para cerrar antes de entrar
                    SQLconn.Close();
                }
                else
                {
                    //comando para SQL(sp, conexion) => SqlCommand objeto de ADO(access data object)
                    SqlCommand cmd = new SqlCommand(sp, SQLconn);
                    //defino que el comando sera ejecutado como una SP (StoreProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;//es mas seguro usar sp que text u otro
                    //Pasamos el SP
                    cmd.CommandText = sp;

                    /*validamos si existen y estan completos los parametros
                    si es diferente de null y su residuo es diferente de 0
                    parametros = {calve:valor}*/
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i++)
                        {
                            //sqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        //abrimos la conexion
                        SQLconn.Open();
                        //ejecuto el comando sin esperar un return
                        cmd.ExecuteNonQuery();
                        id = 1;
                        //creamos la conexion
                        SQLconn.Close();
                    }
                }
                //Retorno el DS (DataSet)
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexion esta abierta
                if (SQLconn.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLconn.Close();
                }
            }
        }
    }
}
