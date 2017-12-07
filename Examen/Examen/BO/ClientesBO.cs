using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.BO
{
    public class ClientesBO
    {
        public static List<Clientes> MostrarInfo(int iduCliente) 
        {
            List<Clientes> listaClientes = new List<Clientes>();
            listaClientes = ClientesDA.MostrarInfo(iduCliente);

            return listaClientes;
        }

        public static int GuardarInfo(Clientes cliente)
        {
            int iResultado = 0;

            iResultado = ClientesDA.GuardarInfo(cliente);

            return iResultado;
        }

        public static int EliminarInfo(int iduCliente)
        { 
            int iResultado = 0;

            iResultado = ClientesDA.EliminarInfo(iduCliente);

            return iResultado;
        }
    }
}