using ControlEscolar.DA;
using ControlEscolar.Entidades;
using System.Collections.Generic;

namespace ControlEscolar.BO
{
    public class AlumnoBO
    {
        public int CrudAlumno(Alumno alumno)
        {
            int iResultado = 0;

            AlumnoDA objAlumnoDA = new AlumnoDA();
            iResultado = objAlumnoDA.CrudAlumno(alumno);

            return iResultado;
        }

        public List<Alumno> Buscar(int idAlumno, int tipoOperacion)
        {
            List<Alumno> listaAlumno = new List<Alumno>();

            AlumnoDA objAlumnoDA = new AlumnoDA();
            listaAlumno = objAlumnoDA.Consultar(idAlumno, tipoOperacion);

            return listaAlumno;
        }
    }
}
