using ControlEscolar.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ControlEscolar.DA
{
    public class PeriodoDA
    {
        public int CrudPeriodo(Periodo periodo)
        {
            int iResultado = 0;
            Respuesta objRespuesta = new Respuesta();
            Dato dato = new Dato();

            try
            {
                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(periodo);

                    var response = client.PostAsync("http://localhost:8084/WsControlEscolar/api/CrudPeriodo/Guardar", new StringContent(json, Encoding.UTF8, "application/json"));

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

        public List<Periodo> Consultar(int idMateria, int tipoConsulta)
        {
            List<Periodo> listaPeriodo = new List<Periodo>();
            try
            {
                using (var client = new HttpClient())
                {
                    string sRuta = string.Format("http://localhost:8084/WsControlEscolar/api/CrudPeriodo/Consultar?idPeriodo={0}&tipoConsulta={1}", idMateria, tipoConsulta);
                    var response = client.GetAsync(sRuta);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        string sRespuesta = response.Result.Content.ReadAsStringAsync().Result;
                        listaPeriodo = JsonConvert.DeserializeObject<List<Periodo>>(sRespuesta);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaPeriodo;
        }
    }
}
