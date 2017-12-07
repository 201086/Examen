using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Examen.Models
{
    public class ClientesDA
    {
        public static List<Clientes> MostrarInfo(int iduCliente)
        {
            List<Clientes> listaClientes = new List<Clientes>();
            DataTable dtClientes = new DataTable();

            try
            {
                using (SqlCommand comando = Conexion.CrearComandoProcSqlServer("procConsultarClientes", Conexion.SQLServer))
                {
                    comando.Parameters.AddWithValue("@iduCliente", iduCliente);

                    dtClientes = Conexion.EjecutarComando(comando);
                }

                for (int i = 0; i < dtClientes.Rows.Count; i++)
                {
                    Clientes cliente = new Clientes();
                    cliente.IduCliente = int.Parse(dtClientes.Rows[i]["iduCliente"].ToString());
                    cliente.Nombre = dtClientes.Rows[i]["nombre"].ToString();
                    cliente.ApellidoPaterno = dtClientes.Rows[i]["apellidoPaterno"].ToString();
                    cliente.ApellidoMaterno = dtClientes.Rows[i]["apellidoMaterno"].ToString();
                    cliente.Correo = dtClientes.Rows[i]["correo"].ToString();

                    listaClientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dtClientes.Clear();
                dtClientes.Dispose();
            }

            return listaClientes;
        }

        public static int GuardarInfo(Clientes cliente)
        {
            int iResultado = 0;

            try
            {
                using (SqlCommand comando = Conexion.CrearComandoProcSqlServer("procGuardarCliente", Conexion.SQLServer))
                {
                    comando.Parameters.AddWithValue("@iduCliente", cliente.IduCliente);
                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@apellidoPaterno", cliente.ApellidoPaterno);
                    comando.Parameters.AddWithValue("@apellidoMaterno", cliente.ApellidoMaterno);
                    comando.Parameters.AddWithValue("@correo", cliente.Correo);

                    iResultado = int.Parse(Conexion.EjecutarEscalar(comando));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iResultado;
        }

        public static int EliminarInfo(int iduCliente)
        {
            int iResultado = 0;

            try
            {
                using (SqlCommand comando = Conexion.CrearComandoProcSqlServer("procEliminarCliente", Conexion.SQLServer))
                {
                    comando.Parameters.AddWithValue("@iduCliente", iduCliente);

                    iResultado = int.Parse(Conexion.EjecutarEscalar(comando));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iResultado;
        }
    }
}