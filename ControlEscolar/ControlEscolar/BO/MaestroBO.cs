using ControlEscolar.DA;
using ControlEscolar.Entidades;
using System.Collections.Generic;

namespace ControlEscolar.BO
{
    public class MaestroBO
    {
        public int CrudMaestro(Maestro maestro)
        {
            int iResultado = 0;

            MaestroDA objMaestroDA = new MaestroDA();
            iResultado = objMaestroDA.CrudAlumno(maestro);

            return iResultado;
        }

        public List<Maestro> Buscar(int idMaestro, int tipoOperacion)
        {
            List<Maestro> listaMaestro = new List<Maestro>();

            MaestroDA objMaestroDA = new MaestroDA();
            listaMaestro = objMaestroDA.Consultar(idMaestro, tipoOperacion);

            return listaMaestro;
        }
    }
}
