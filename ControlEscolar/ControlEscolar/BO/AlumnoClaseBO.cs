using ControlEscolar.DA;
using ControlEscolar.Entidades;
using System.Collections.Generic;

namespace ControlEscolar.BO
{
    public class AlumnoClaseBO
    {
        public List<Alumno> MostrarAlumno(int idAlumno, int tipoOperacion)
        {
            List<Alumno> listaAlumno = new List<Alumno>();

            AlumnoDA objMateriaDA = new AlumnoDA();
            listaAlumno = objMateriaDA.Consultar(idAlumno, tipoOperacion);

            return listaAlumno;
        }

        public List<Periodo> MostrarPeriodo(int idPeriodo, int tipoOperacion)
        {
            List<Periodo> listaMaestro = new List<Periodo>();

            PeriodoDA objPeriodoDA = new PeriodoDA();
            listaMaestro = objPeriodoDA.Consultar(idPeriodo, tipoOperacion);

            return listaMaestro;
        }

        public List<Clase> MostrarClase(int idClase, int tipoOperacion)
        {
            List<Clase> listaClase = new List<Clase>();

            ClaseDA objMaestroDA = new ClaseDA();
            listaClase = objMaestroDA.Consultar(idClase, tipoOperacion);

            return listaClase;
        }

        public int CrudAlumnoClase(AlumnoClase alumnoClase)
        {
            int iResultado = 0;

            AlumnoClaseDA objAlumnoClaseDA = new AlumnoClaseDA();
            iResultado = objAlumnoClaseDA.CrudAlumnoClase(alumnoClase);

            return iResultado;
        }

        public List<AlumnoClase> Buscar(int idAlumnoClase, int tipoOperacion)
        {
            List<AlumnoClase> listaAlumno = new List<AlumnoClase>();

            AlumnoClaseDA objAlumnoClaseDA = new AlumnoClaseDA();
            listaAlumno = objAlumnoClaseDA.Consultar(idAlumnoClase, tipoOperacion);

            return listaAlumno;
        }
    }
}
