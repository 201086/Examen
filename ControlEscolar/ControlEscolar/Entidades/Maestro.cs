namespace ControlEscolar.Entidades
{
    public class Maestro
    {
        private int idMaestro;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string correo;
        private string sexo;
        private int tipoOperacion;

        public Maestro()
        {
            idMaestro = 0;
            nombre = "";
            apellidos = "";
            telefono = "";
            correo = "";
            sexo = "";
            TipoOperacion = 0;
        }

        public int IdMaestro
        {
            get
            {
                return idMaestro;
            }

            set
            {
                idMaestro = value;
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
