using ControlEscolar.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ControlEscolar.DA
{
    public class ClaseDA
    {
        public int CrudClase(Clase clase)
        {
            int iResultado = 0;
            Respuesta objRespuesta = new Respuesta();
            Dato dato = new Dato();

            try
            {
                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(clase);

                    var response = client.PostAsync("http://localhost:8084/WsControlEscolar/api/CrudClase/Guardar", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.Result.IsSuccessStatusCode)
                    {
                        string sRespuesta = response.Result.Content.ReadAsStringAsync().Result;
                        objRespuesta = JsonConvert.DeserializeObject<Respuesta>(sRespuesta);
                        dato = JsonConvert.DeserializeObject<Dato>(objRespuesta.Data.ToString());
                        iResultado = dato.Value;
                    }
                    else
                    {
                        iResultado = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                iResultado = 0;
                throw ex;
            }

            return iResultado;
        }

        public List<Clase> Consultar(int idClase, int tipoConsulta)
        {
            List<Clase> listaClase = new List<Clase>();
            try
            {
                using (var client = new HttpClient())
                {
                    string sRuta = string.Format("http://localhost:8084/WsControlEscolar/api/CrudClase/Consultar?idClase={0}&tipoConsulta={1}", idClase, tipoConsulta);
                    var response = client.GetAsync(sRuta);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        string sRespuesta = response.Result.Content.ReadAsStringAsync().Result;
                        listaClase = JsonConvert.DeserializeObject<List<Clase>>(sRespuesta);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaClase;
        }
    }
}
