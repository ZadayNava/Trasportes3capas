﻿using BLL;
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

        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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