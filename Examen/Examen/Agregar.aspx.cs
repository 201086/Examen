using Examen.BO;
using Examen.Models;
using System;
using System.Web.Services;

namespace Examen
{
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        [WebMethod]
        public static string AgregarInfo(Clientes cliente)
        {
            ClientesBO.GuardarInfo(cliente);

            return "Lista.aspx";
        }
    }
}