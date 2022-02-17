namespace ControlEscolar.Entidades
{
    public class Periodo
    {
        private int idPeriodo;
        private string nombre;
        private string fechaInicio;
        private string fechaFin;
        private int tipoOperacion;

        public Periodo()
        {
            idPeriodo = 0;
            nombre = "";
            fechaInicio = "";
            fechaFin = "";
        }

        public int IdPeriodo
        {
            get
            {
                return idPeriodo;
            }

            set
            {
                idPeriodo = value;
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

        public string FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public string FechaFin
        {
            get
            {
                return fechaFin;
            }

            set
            {
                fechaFin = value;
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
