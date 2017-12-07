using Npgsql;
using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Examen.Models
{
    public class Conexion
    {
        public static string PostgresSQL
        {
            get
            {
                return "Server=127.0.0.1;User Id=postgres;Password=pwd;Database=Examen;";
            }
        }

        public static string SQLServer
        {
            get
            {
                return @"Data Source=PC\SQLEXPRESS;Initial Catalog=Examen;Integrated Security=True;";
            }
        }

        public static NpgsqlCommand CrearComandoPostgres(string sCadenaConexion)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(sCadenaConexion);
            NpgsqlCommand comando = new NpgsqlCommand();

            try
            {
                comando = conexion.CreateCommand();
                comando.CommandType = CommandType.Text;
            }
            catch
            {
                throw;
            }

            return comando;
        }

        public static SqlCommand CrearComandoSqlServer(string sCadenaConexion)
        {
            SqlConnection conexion = new SqlConnection(sCadenaConexion);
            SqlCommand comando = new SqlCommand();

            try
            {
                comando = conexion.CreateCommand();
                comando.CommandType = CommandType.Text;
            }
            catch
            {
                throw;
            }

            return comando;
        }

        public static NpgsqlCommand CrearComandoProcPostgres(string sProcedimiento, string sCadenaConexion)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(sCadenaConexion);
            NpgsqlCommand comando = new NpgsqlCommand(sProcedimiento, conexion);

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return comando;
        }

        public static SqlCommand CrearComandoProcSqlServer(string sProcedimiento, string sCadenaConexion)
        {
            SqlConnection conexion = new SqlConnection(sCadenaConexion);
            SqlCommand comando = new SqlCommand(sProcedimiento, conexion);

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return comando;
        }

        public static DataTable EjecutarComando(NpgsqlCommand comando)
        {
            DataTable tabla = new DataTable();
            NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter();

            try
            {
                comando.Connection.Open();
                comando.CommandType = CommandType.StoredProcedure;

                adaptador.SelectCommand = comando;
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }

            return tabla;
        }

        public static DataTable EjecutarComando(SqlCommand comando)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();

            try
            {
                comando.Connection.Open();
                comando.CommandType = CommandType.StoredProcedure;

                adaptador.SelectCommand = comando;
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }

            return tabla;
        }

        public static string EjecutarEscalar(NpgsqlCommand comando)
        {
            string sEscalar = "";

            try
            {
                comando.Connection.Open();
                sEscalar = comando.ExecuteScalar().ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }

            return sEscalar;
        }

        public static string EjecutarEscalar(SqlCommand comando)
        {
            string sEscalar = "";

            try
            {
                comando.Connection.Open();
                sEscalar = comando.ExecuteScalar().ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }

            return sEscalar;
        }
    }
}