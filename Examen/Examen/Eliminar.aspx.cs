using Examen.BO;
using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen
{
    public partial class Eliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["iduCliente"].ToString()))
            {
                Response.Redirect("Lista.aspx");
            }
        }

        [WebMethod]
        public static List<Clientes> MostrarInfo()
        {
            int iduCliente = 0;
            List<Clientes> listaClientes = new List<Clientes>();

            iduCliente = int.Parse(System.Web.HttpContext.Current.Session["iduCliente"].ToString());
            listaClientes = ClientesBO.MostrarInfo(iduCliente);

            return listaClientes;
        }

        [WebMethod]
        public static string EliminarInfo(int iduCliente)
        {
            ClientesBO.EliminarInfo(iduCliente);

            return "Lista.aspx";
        }
    }
}