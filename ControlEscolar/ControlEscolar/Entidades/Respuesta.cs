namespace ControlEscolar.Entidades
{
    public class Respuesta
    {
        private string response;
        private object data;

        public string Response
        {
            get
            {
                return response;
            }

            set
            {
                response = value;
            }
        }

        public object Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
    }

    public class Dato {
        private string type;
        private int value;

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
