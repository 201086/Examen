using ControlEscolar.DA;
using ControlEscolar.Entidades;
using System.Collections.Generic;

namespace ControlEscolar.BO
{
    public class ClaseBO
    {
        public int CrudClase(Clase clase)
        {
            int iResultado = 0;

            ClaseDA objClaseDA = new ClaseDA();
            iResultado = objClaseDA.CrudClase(clase);

            return iResultado;
        }

        public List<Materia> MostrarMateria(int idMateria, int tipoOperacion)
        {
            List<Materia> listaMateria = new List<Materia>();

            MateriaDA objMateriaDA = new MateriaDA();
            listaMateria = objMateriaDA.Consultar(idMateria, tipoOperacion);

            return listaMateria;
        }

        public List<Maestro> MostrarMaestro(int idMaestro, int tipoOperacion)
        {
            List<Maestro> listaMaestro = new List<Maestro>();

            MaestroDA objMaestroDA = new MaestroDA();
            listaMaestro = objMaestroDA.Consultar(idMaestro, tipoOperacion);

            return listaMaestro;
        }

        public List<Periodo> MostrarPeriodo(int idMaestro, int tipoOperacion)
        {
            List<Periodo> listaPeriodo = new List<Periodo>();

            PeriodoDA objMaestroDA = new PeriodoDA();
            listaPeriodo = objMaestroDA.Consultar(idMaestro, tipoOperacion);

            return listaPeriodo;
        }

        public List<Clase> Buscar(int idClase, int tipoOperacion)
        {
            List<Clase> listaClase = new List<Clase>();

            ClaseDA objAlumnoDA = new ClaseDA();
            listaClase = objAlumnoDA.Consultar(idClase, tipoOperacion);

            return listaClase;
        }
    }
}
