using Examen.BO;
using Examen.Models;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace Examen
{
    public partial class Editar : System.Web.UI.Page
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
        public static string ActualizarInfo(Clientes cliente)
        {
            ClientesBO.GuardarInfo(cliente);

            return "Lista.aspx";
        }
    }
}