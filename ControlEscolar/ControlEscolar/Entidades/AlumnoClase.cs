namespace ControlEscolar.Entidades
{
    public class AlumnoClase
    {
        private int idAlumnoClase;
        private Alumno alumno;
        private Periodo periodo;
        private Clase clase;
        private int calificacion;
        private int tipoOperacion;

        public int IdAlumnoClase
        {
            get
            {
                return idAlumnoClase;
            }

            set
            {
                idAlumnoClase = value;
            }
        }

        public Alumno Alumno
        {
            get
            {
                return alumno;
            }

            set
            {
                alumno = value;
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

        public Clase Clase
        {
            get
            {
                return clase;
            }

            set
            {
                clase = value;
            }
        }

        public int Calificacion
        {
            get
            {
                return calificacion;
            }

            set
            {
                calificacion = value;
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
