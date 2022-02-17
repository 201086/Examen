using System.Collections.Generic;

namespace ControlEscolar.Entidades
{
    public class Clase
    {
        private int idClase;
        private Materia materia;
        private Maestro maestro;
        private Periodo periodo;
        private int capacidad;
        private int tipoOperacion;

        public Clase()
        {
            idClase = 0;
            capacidad = 0;
        }

        public int IdClase
        {
            get
            {
                return idClase;
            }

            set
            {
                idClase = value;
            }
        }

        public Materia Materia
        {
            get
            {
                return materia;
            }

            set
            {
                materia = value;
            }
        }

        public Maestro Maestro
        {
            get
            {
                return maestro;
            }

            set
            {
                maestro = value;
            }
        }

        public Periodo Periodo
        {
            get
            {
                return periodo;
            }

            set
            {
                periodo = value;
            }
        }

        public int Capacidad
        {
            get
            {
                return capacidad;
            }

            set
            {
                capacidad = value;
            }
        }

        public int TipoOperacion
        {
            get
            {
                return tipoOperacion;
            }

            set
            {
                tipoOperacion = value;
            }
        }
    }
}
