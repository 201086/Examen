namespace ControlEscolar.Entidades
{
    public class Materia
    {
        private int idMateria;
        private string nombre;
        private int tipoOperacion;

        public Materia()
        {
            idMateria = 0;
            nombre = "";
        }

        public int IdMateria
        {
            get
            {
                return idMateria;
            }

            set
            {
                idMateria = value;
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
