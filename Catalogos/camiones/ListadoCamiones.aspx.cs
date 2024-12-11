using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trasportes3capas.Catalogos.camiones
{
    public partial class ListadoCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //utilizamos la variable "IsPostBack" para controlar la primera vez que carga la pagin
            if (!IsPostBack) {
                cargarGrid();
            }
        }
        public void cargarGrid()
        {
            //cargar la informacion desde la BLL al GV
            GVCamiones.DataSource = BLL_Camiones.GetCamiones();
            //mostramos los resultados resultados renderizado la informacion
            GVCamiones.DataBind();
        }
        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formularioCamiones.aspx");
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //recuero el id del renglon afectado 
            int id_camion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["Id_camion"].ToString());
            //invoco mi metodo para eliminar mi camion
            string respuesta = BLL_Camiones.Delete_Camion(id_camion);
            //preparamos el sweet alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo= "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto!";
                msg = respuesta;
                tipo = "success";

            }
        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el clic que se detecta) tiene la propiedad "select"
            if(e.CommandName == "Select")
            {
                //recupero el indice en funcin de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente, se encuentra en ListadoCamiones.aspx.cs
                string id = GVCamiones.DataKeys[varIndex].Values["Id_camion"].ToString();
                //redirecciono al formulario de edicion pasando como parametro el ID
                Response.Redirect($"formularioCamiones.aspx?Id={id}");
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}