using ControlEscolar.DA;
using ControlEscolar.Entidades;
using System.Collections.Generic;

namespace ControlEscolar.BO
{
    public class PeriodoBO
    {
        public int CrudPeriodo(Periodo periodo)
        {
            int iResultado = 0;

            PeriodoDA objPeriodoDA = new PeriodoDA();
            iResultado = objPeriodoDA.CrudPeriodo(periodo);

            return iResultado;
        }

        public List<Periodo> Buscar(int idPeriodo, int tipoOperacion)
        {
            List<Periodo> listaPeriodo = new List<Periodo>();

            PeriodoDA objPeriodoDA = new PeriodoDA();
            listaPeriodo = objPeriodoDA.Consultar(idPeriodo, tipoOperacion);

            return listaPeriodo;
        }
    }
}