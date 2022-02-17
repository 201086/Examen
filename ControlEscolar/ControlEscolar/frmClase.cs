using ControlEscolar.BO;
using ControlEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class frmClase : Form
    {
        public frmClase()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Clase clase = new Clase();
            clase.Materia = new Materia();
            clase.Maestro = new Maestro();
            clase.Periodo = new Periodo();
            ClaseBO objClaseBO = new ClaseBO();

            if (cmbMateria.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar una Materia");
                return;
            }

            if (cmbMaestro.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Maestro");
                return;
            }

            if (cmbPeriodo.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Maestro");
                return;
            }

            if (txtCapacidad.Text == "") {
                MessageBox.Show("Favor de ingresar una Capacidad");
                return;
            }

            clase.Materia.IdMateria = int.Parse(cmbMateria.SelectedValue.ToString());
            clase.Maestro.IdMaestro = int.Parse(cmbMaestro.SelectedValue.ToString());
            clase.Periodo.IdPeriodo = int.Parse(cmbPeriodo.SelectedValue.ToString());
            clase.Capacidad = int.Parse(txtCapacidad.Text);
            clase.TipoOperacion = 1;

            iResultado = objClaseBO.CrudClase(clase);

            if (iResultado == 1)
                MessageBox.Show("información Guardada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Clase clase = new Clase();
            ClaseBO objClaseBO = new ClaseBO();

            if (int.Parse(txtIdClase.Text) == 0)
            {
                MessageBox.Show("Favor de ingresar una Clase");
                return;
            }

            if (cmbMateria.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar una Materia");
                return;
            }

            if (cmbMaestro.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Maestro");
                return;
            }

            if (cmbPeriodo.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Maestro");
                return;
            }

            if (txtCapacidad.Text == "")
            {
                MessageBox.Show("Favor de ingresar una Capacidad");
                return;
            }

            clase.IdClase = int.Parse(txtIdClase.Text);
            clase.Periodo.IdPeriodo = int.Parse(cmbMateria.SelectedValue.ToString());
            clase.Maestro.IdMaestro = int.Parse(cmbMaestro.SelectedValue.ToString());
            clase.Periodo.IdPeriodo = int.Parse(cmbPeriodo.SelectedValue.ToString());
            clase.Capacidad = int.Parse(txtCapacidad.Text);
            clase.TipoOperacion = 2;
            iResultado = objClaseBO.CrudClase(clase);

            if (iResultado == 2)
                MessageBox.Show("información Guardada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Clase clase = new Clase();
            ClaseBO objClaseBO = new ClaseBO();

            if (int.Parse(txtIdClase.Text) == 0)
            {
                MessageBox.Show("Favor de ingresar una Clase");
                return;
            }

            if (cmbMateria.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar una Materia");
                return;
            }

            if (cmbMaestro.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Maestro");
                return;
            }

            if (cmbPeriodo.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Maestro");
                return;
            }

            clase.IdClase = int.Parse(txtIdClase.Text);
            clase.TipoOperacion = 3;
            iResultado = objClaseBO.CrudClase(clase);

            if (iResultado == 3)
                MessageBox.Show("información eliminada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idClase = 0;
            DataTable dt = new DataTable();
            Clase objAlumno = new Clase();
            ClaseBO objClaseBO = new ClaseBO();
            List<Clase> listaClase = new List<Clase>();

            idClase = int.Parse(txtIdClase.Text);
            listaClase = objClaseBO.Buscar(idClase, 2);

            if (listaClase != null && listaClase.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Materia", typeof(string)));
                dt.Columns.Add(new DataColumn("Maestro", typeof(string)));
                dt.Columns.Add(new DataColumn("Periodo", typeof(string)));
                dt.Columns.Add(new DataColumn("Capacidad", typeof(int)));

                DataRow dr = dt.NewRow();

                for (int i = 0; i < listaClase.Count; i++)
                {
                    dr["Materia"] = listaClase[i].Materia.Nombre;
                    dr["Maestro"] = listaClase[i].Maestro.Nombre;
                    dr["Periodo"] = listaClase[i].Materia.Nombre;
                    dr["Capacidad"] = listaClase[i].Capacidad;

                    dt.Rows.Add(dr);
                }

                dgvClase.DataSource = dt;
                dgvClase.Refresh();
            }
        }

        private void frmClase_Load(object sender, EventArgs e)
        {
            ClaseBO objClaseBO = new ClaseBO();
            DataTable dt = new DataTable();
            List<Materia> listaMateria = new List<Materia>();
            List<Maestro> listaMaestro = new List<Maestro>();
            List<Periodo> listaPeriodo = new List<Periodo>();
            List<Clase> listaClase = new List<Clase>();
            
            listaMateria = objClaseBO.MostrarMateria(1, 1);
            cmbMateria.DataSource = listaMateria;
            cmbMateria.DisplayMember = "nombre";
            cmbMateria.ValueMember = "idMateria";

            listaMaestro = objClaseBO.MostrarMaestro(1, 1);
            cmbMaestro.DataSource = listaMaestro;
            cmbMaestro.DisplayMember = "nombre";
            cmbMaestro.ValueMember = "idMaestro";

            listaPeriodo = objClaseBO.MostrarPeriodo(1, 1);
            cmbPeriodo.DataSource = listaPeriodo;
            cmbPeriodo.DisplayMember = "nombre";
            cmbPeriodo.ValueMember = "idPeriodo";

            listaClase = objClaseBO.Buscar(0, 1);

            if (listaClase != null || listaClase.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Materia", typeof(string)));
                dt.Columns.Add(new DataColumn("Maestro", typeof(string)));
                dt.Columns.Add(new DataColumn("Periodo", typeof(string)));
                dt.Columns.Add(new DataColumn("Capacidad", typeof(int)));

                DataRow dr = dt.NewRow();

                for (int i = 0; i < listaClase.Count; i++)
                {
                    dr["Materia"] = listaClase[i].Materia.Nombre;
                    dr["Maestro"] = listaClase[i].Maestro.Nombre;
                    dr["Periodo"] = listaClase[i].Materia.Nombre;
                    dr["Capacidad"] = listaClase[i].Capacidad;

                    dt.Rows.Add(dr);
                }

                dgvClase.DataSource = dt;
                dgvClase.Refresh();
            }
        }

        private void txtIdClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
