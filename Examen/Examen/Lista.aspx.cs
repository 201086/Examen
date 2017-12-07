using Examen.BO;
using Examen.Models;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace Examen
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static List<Clientes> MostrarInfo()
        {
            List<Clientes> listaClientes = new List<Clientes>();
            listaClientes = ClientesBO.MostrarInfo(0);

            return listaClientes;
        }

        [WebMethod]
        public static string ActualizarInfo(int iduCliente)
        {
            string sRespuesta = "";

            if (iduCliente > 0)
            {
                System.Web.HttpContext.Current.Session["iduCliente"] = iduCliente;
                sRespuesta = "Actualizar.aspx";
            }
            else
            {
                sRespuesta = "Lista.aspx";
            }

            return sRespuesta;
        }

        [WebMethod]
        public static string EliminarInfo(int iduCliente)
        {
            string sRespuesta = "";

            if (iduCliente > 0)
            {
                System.Web.HttpContext.Current.Session["iduCliente"] = iduCliente;
                sRespuesta = "Eliminar.aspx";
            }
            else
            {
                sRespuesta = "Lista.aspx";
            }

            return sRespuesta;
        }
    }
}