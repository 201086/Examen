using ControlEscolar.DA;
using ControlEscolar.Entidades;
using System.Collections.Generic;

namespace ControlEscolar.BO
{
    public class MateriaBO
    {
        public int CrudMateria(Materia materia)
        {
            int iResultado = 0;

            MateriaDA objMateriaDA = new MateriaDA();
            iResultado = objMateriaDA.CrudMateria(materia);

            return iResultado;
        }

        public List<Materia> Buscar(int idMateria, int tipoOperacion)
        {
            List<Materia> listaPeriodo = new List<Materia>();

            MateriaDA objMateriaDA = new MateriaDA();
            listaPeriodo = objMateriaDA.Consultar(idMateria, tipoOperacion);

            return listaPeriodo;
        }
    }
}
