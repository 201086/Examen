namespace ControlEscolar.Entidades
{
    public class Alumno
    {
        private int idAlumno;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string correo;
        private string sexo;
        private int tipoOperacion;

        public Alumno()
        {
            idAlumno = 0;
            nombre = "";
            apellidos = "";
            telefono = "";
            correo = "";
            sexo = "";
            TipoOperacion = 0;
        }

        public int IdAlumno
        {
            get
            {
                return idAlumno;
            }

            set
            {
                idAlumno = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
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
