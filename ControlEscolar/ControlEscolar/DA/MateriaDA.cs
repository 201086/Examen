using ControlEscolar.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolar.DA
{
    public class MateriaDA
    {
        public int CrudMateria(Materia materia)
        {
            int iResultado = 0;
            Respuesta objRespuesta = new Respuesta();
            Dato dato = new Dato();

            try
            {
                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(materia);

                    var response = client.PostAsync("http://localhost:8084/WsControlEscolar/api/CrudMateria/Guardar", new StringContent(json, Encoding.UTF8, "application/json"));

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

        public List<Materia> Consultar(int idMateria, int tipoConsulta)
        {
            List<Materia> listaMateria = new List<Materia>();
            try
            {
                using (var client = new HttpClient())
                {
                    string sRuta = string.Format("http://localhost:8084/WsControlEscolar/api/CrudMateria/Consultar?idMateria={0}&tipoConsulta={1}", idMateria, tipoConsulta);
                    var response = client.GetAsync(sRuta);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        string sRespuesta = response.Result.Content.ReadAsStringAsync().Result;
                        listaMateria = JsonConvert.DeserializeObject<List<Materia>>(sRespuesta);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaMateria;
        }
    }
}
