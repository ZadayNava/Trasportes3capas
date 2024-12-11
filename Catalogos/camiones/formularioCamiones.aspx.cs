using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trasportes3capas.Utilidades;
using VO;

namespace Trasportes3capas.Catalogos.camiones
{
    public partial class formularioCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //valido si es postback
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar camion";
                    subTitulo.Text = "Registro de un nuevo camion";
                    lbldisponibiidad.Visible = false;
                    chkdisponibilidad.Visible = false;
                    imgfoto.Visible = false;
                    lblurlfoto.Visible = false;
                }
                else
                {
                    //Voy a actualizar
                    //Recupero el id que proviene de la url
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //obtengo el objeto original de la bd y coloco sus valores en los campos correspondientes
                    Camiones_VO _camion_origial = BLL_Camiones.GetCamionesxID(_id);
                    //valido que realmente obtenga el objeto y sus vlores, de lo contrario, me regreso al formulario
                    if (_camion_origial.Id_camion != 0)
                    {
                        //si encontre el camin y coloc sus valores
                        Titulo.Text = "Actualizar camion";
                        subTitulo.Text = $"Modificar los datos del camion #{_id}";
                        txtMatricula.Text = _camion_origial.Matricula.ToString();
                        txtCapacidad.Text = _camion_origial.Capacidad.ToString();
                        txtKilometraje.Text = _camion_origial.Kilometraje.ToString();
                        txtTipo.Text = _camion_origial.Tipo_camion;
                        txtMarca.Text = _camion_origial.Marca;
                        txtModelo.Text = _camion_origial.Modelo;
                        chkdisponibilidad.Checked = _camion_origial.Disponibilidad;
                        imgfoto.ImageUrl = _camion_origial.UrlFoto;

                    }
                    else
                    {
                        //no encontre el objeto y me voy pa' tras
                        Response.Redirect("ListadoCamiones.aspx");
                    }
                }
            }
        }

        protected void btnsubeimagen_Click(object sender, EventArgs e)
        {
            //este metodo para guardar y almacenar la imagen en el servidor y posteriormente recuperar la info desde la bd
            if (subeimagen.Value != "")
            {
                //recuepro el nombre del archvio
                string filename = Path.GetFileName(subeimagen.Value);
                //valido la extencion del archivo
                string fileExt = Path.GetExtension(filename).ToLower();
                if ((fileExt == ".jpg") && (fileExt == ".png"))
                {
                    //sweet alert
                }
                else
                {
                    //verifico que existe el directorio en el servidor, para poder almacenar la imagen, de lo contrario, procedo a crearlo
                    string pathdir = Server.MapPath("~/Imagenes/Camiones/");
                    //~ (virgulilla)hace referencia a la direccion completa del servidor, independientemente de donde este instaldo, permitiendo que la validacion funciones en diferentes entornos
                    //si no existe el directorio, lo creamos
                    if (!Directory.Exists(pathdir))
                    {
                        //creo el directorio
                        Directory.CreateDirectory(pathdir);
                    }
                    //subo la imagen a la carpeta del servidor
                    subeimagen.PostedFile.SaveAs(pathdir + filename);
                    //recuperamos la ruta de la url que almacearemos en la bd
                    string urlfoto = "/Imagenes/Camiones/" + filename;
                    //mostramos en pantalla la URL creada
                    this.urlfoto.Text = urlfoto;
                    //mostramos la imagen
                    imgcamion.ImageUrl = urlfoto;
                    //alert sweet
                }
            }
        }


        protected void btngurdar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                /*CReamos el objeto que enviaremos para actualizar o insertar a las BD
                 Existe 2 formas de instanciar y llenar un obeto
                forma 1 (por atributos)*/
                Camiones_VO _camion_aux = new Camiones_VO();
                _camion_aux.Matricula = txtMatricula.Text;
                _camion_aux.Marca = txtMarca.Text;
                _camion_aux.Tipo_camion = txtTipo.Text;
                _camion_aux.Modelo = txtModelo.Text;
                _camion_aux.Capacidad = Convert.ToInt32(txtCapacidad.Text);
                _camion_aux.Kilometraje = Convert.ToDouble(txtKilometraje.Text);
                _camion_aux.UrlFoto = imgcamion.ImageUrl;
                _camion_aux.Disponibilidad = chkdisponibilidad.Checked;

                //forma 2 (durante la propia instancia)
                //Camiones_VO _camion_aux_2 = new Camiones_VO();
                //{
                //    _camion_aux_2.Matricula = txtMatricula.Text;
                //    _camion_aux_2.Marca = txtMarca.Text;
                //    _camion_aux_2.Tipo_Camion = txtTipo.Text;
                //    _camion_aux_2.Modelo = txtModelo.Text,
                //        _camion_aux_2.Capaciad = Convert.ToInt32(txtCapacidad.Text);
                //    _camion_aux_2.kilometraje = Convert.ToDouble(txtKilometraje.Text);
                //    _camion_aux_2.UrlFoto = imgcamion.ImageUrl;
                //};

                //decido si voy a insertar o actualizar
                if (Request.QueryString["Id"] == null)
                {
                    //voy a insertar
                    _camion_aux.Disponibilidad = true;
                    salida = BLL_Camiones.Insert_Camion(_camion_aux);
                }
                else
                {
                    //Actualizar
                    _camion_aux.Id_camion = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Camiones.Update_Camiones(_camion_aux);
                }
                //preparamos la salida para cachar un error y mostra el sweet alert
                if (salida.ToUpper().Contains("ERROR"))
                {
                    titulo = "Opps ...";
                    respuesta = salida;
                    tipo = "warning";
                }
                else
                {
                    titulo = "Correcto!";
                    respuesta = salida;
                    tipo = "success";

                }
            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
            //sweet alert
            SweetAlert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "/Catalogos/camiones/ListadoCamiones.aspx");
        }
    }
}