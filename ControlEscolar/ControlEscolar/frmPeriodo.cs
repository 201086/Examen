using ControlEscolar.BO;
using ControlEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class frmPeriodo : Form
    {
        public frmPeriodo()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (txtNombre.Text == "") {
                MessageBox.Show("Favor de ingresar un nombre");
                return;
            }

            Periodo objPeriodo = new Periodo();
            PeriodoBO objPeriodoBO = new PeriodoBO();

            objPeriodo.Nombre = txtNombre.Text;
            objPeriodo.FechaInicio = dtFechaInicio.Text;
            objPeriodo.FechaFin = dtFechaFin.Text;
            objPeriodo.TipoOperacion = 1;

            iResultado = objPeriodoBO.CrudPeriodo(objPeriodo);

            if (iResultado == 1)
                MessageBox.Show("información Guardada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (txtIdPeriodo.Text == "") {
                MessageBox.Show("Favor de ingresar un idPeriodo");
                return;
            }

            Periodo objPeriodo = new Periodo();
            PeriodoBO objPeriodoBO = new PeriodoBO();

            objPeriodo.IdPeriodo = int.Parse(txtIdPeriodo.Text);
            objPeriodo.Nombre = txtNombre.Text;
            objPeriodo.FechaInicio = dtFechaInicio.Text;
            objPeriodo.FechaFin = dtFechaFin.Text;
            objPeriodo.TipoOperacion = 2;

            iResultado = objPeriodoBO.CrudPeriodo(objPeriodo);

            if (iResultado == 2)
                MessageBox.Show("información Actualizada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (txtIdPeriodo.Text == "")
            {
                MessageBox.Show("Favor de ingresar un idPeriodo");
                return;
            }

            Periodo objPeriodo = new Periodo();
            PeriodoBO objPeriodoBO = new PeriodoBO();

            objPeriodo.IdPeriodo = int.Parse(txtIdPeriodo.Text);
            objPeriodo.Nombre = txtNombre.Text;
            objPeriodo.FechaInicio = dtFechaInicio.Text;
            objPeriodo.FechaFin = dtFechaFin.Text;
            objPeriodo.TipoOperacion = 3;

            iResultado = objPeriodoBO.CrudPeriodo(objPeriodo);

            if (iResultado == 3)
                MessageBox.Show("información Eliminada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idPeriodo = 0;
            Periodo objPeriodo = new Periodo();
            PeriodoBO objPeriodoBo = new PeriodoBO();
            List<Periodo> listaPeriodo = new List<Periodo>();

            if (txtIdPeriodo.Text == "")
            {
                MessageBox.Show("Favor de ingresar un idPeriodo");
                return;
            }

            idPeriodo = int.Parse(txtIdPeriodo.Text);
            listaPeriodo = objPeriodoBo.Buscar(idPeriodo, 2);

            if (listaPeriodo != null && listaPeriodo.Count > 0)
            {
                txtNombre.Text = listaPeriodo[0].Nombre;
                dtFechaInicio.Text = listaPeriodo[0].FechaInicio;
                dtFechaFin.Text = listaPeriodo[0].FechaFin;

                dgvPeriodo.DataSource = listaPeriodo;
                dgvPeriodo.Columns["IdPeriodo"].Visible = false;
                dgvPeriodo.Columns["TipoOperacion"].Visible = false;
                dgvPeriodo.Refresh();
            }
        }

        private void frmPeriodo_Load(object sender, EventArgs e)
        {
            Periodo objPeriodo = new Periodo();
            PeriodoBO objPeriodoBO = new PeriodoBO();
            List<Periodo> listaPeriodo = new List<Periodo>();

            listaPeriodo = objPeriodoBO.Buscar(0, 1);

            if (listaPeriodo != null || listaPeriodo.Count > 0)
            {
                dgvPeriodo.DataSource = listaPeriodo;
                dgvPeriodo.Columns["IdPeriodo"].Visible = false;
                dgvPeriodo.Columns["TipoOperacion"].Visible = false;
                dgvPeriodo.Refresh();
            }
        }

        private void txtIdPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void LimpiarCampos()
        {
            txtIdPeriodo.Text = "";
            txtNombre.Text = "";
        }
    }
}
