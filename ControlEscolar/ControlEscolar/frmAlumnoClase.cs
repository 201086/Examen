using ControlEscolar.BO;
using ControlEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class frmAlumnoClase : Form
    {
        public frmAlumnoClase()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            AlumnoClase alumnoClase = new AlumnoClase();
            alumnoClase.Alumno = new Alumno();
            alumnoClase.Periodo = new Periodo();
            alumnoClase.Clase = new Clase();
            AlumnoClaseBO objAlumnoClaseBO = new AlumnoClaseBO();

            if (cmbMatricula.Text == "") {
                MessageBox.Show("Favor de ingresar un Alumno");
                return;
            }

            if (cmbPeriodo.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Periodo");
                return;
            }

            if (cmbClase.DataSource == null)
            {
                MessageBox.Show("Favor de ingresar un Clase");
                return;
            }

            alumnoClase.Alumno.IdAlumno = int.Parse(cmbMatricula.SelectedValue.ToString());
            alumnoClase.Periodo.IdPeriodo = int.Parse(cmbPeriodo.SelectedValue.ToString());
            alumnoClase.Clase.IdClase = int.Parse(cmbClase.SelectedValue.ToString());
            alumnoClase.Calificacion = int.Parse(txtCalificacion.Text);
            alumnoClase.TipoOperacion = 1;

            iResultado = objAlumnoClaseBO.CrudAlumnoClase(alumnoClase);

            if (iResultado == 1)
                MessageBox.Show("información Guardada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            AlumnoClase alumnoClase = new AlumnoClase();
            alumnoClase.Alumno = new Alumno();
            alumnoClase.Periodo = new Periodo();
            alumnoClase.Clase = new Clase();
            AlumnoClaseBO objAlumnoClaseBO = new AlumnoClaseBO();

            if (int.Parse(txtIdAlumnoClase.Text) <= 0)
            {
                MessageBox.Show("Favor de ingresar un Alumno");
                return;
            }

            if (cmbMatricula.Text == "")
            {
                MessageBox.Show("Favor de ingresar un Alumno");
                return;
            }

            if (cmbPeriodo.Text == "")
            {
                MessageBox.Show("Favor de ingresar un Periodo");
                return;
            }

            if (cmbClase.Text == "")
            {
                MessageBox.Show("Favor de ingresar un Clase");
                return;
            }

            alumnoClase.IdAlumnoClase = int.Parse(txtIdAlumnoClase.Text);
            alumnoClase.Alumno.IdAlumno = int.Parse(cmbMatricula.SelectedValue.ToString());
            alumnoClase.Periodo.IdPeriodo = int.Parse(cmbPeriodo.SelectedValue.ToString());
            alumnoClase.Clase.IdClase = int.Parse(cmbClase.SelectedValue.ToString());
            alumnoClase.Calificacion = int.Parse(txtCalificacion.Text);
            alumnoClase.TipoOperacion = 2;

            iResultado = objAlumnoClaseBO.CrudAlumnoClase(alumnoClase);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            AlumnoClase alumnoClase = new AlumnoClase();
            AlumnoClaseBO objAlumnoClaseBO = new AlumnoClaseBO();

            if (cmbMatricula.Text == "")
            {
                MessageBox.Show("Favor de ingresar un Alumno");
                return;
            }

            if (cmbPeriodo.Text == "")
            {
                MessageBox.Show("Favor de ingresar un Periodo");
                return;
            }

            if (cmbClase.Text == "")
            {
                MessageBox.Show("Favor de ingresar un Clase");
                return;
            }

            alumnoClase.IdAlumnoClase = int.Parse(txtIdAlumnoClase.Text);
            alumnoClase.TipoOperacion = 3;
            iResultado = objAlumnoClaseBO.CrudAlumnoClase(alumnoClase);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idAlumnoClase = 0;
            DataTable dt = new DataTable();
            AlumnoClase objAlumno = new AlumnoClase();
            AlumnoClaseBO objAlumnoBO = new AlumnoClaseBO();
            List<AlumnoClase> listaAlumnoClase = new List<AlumnoClase>();

            idAlumnoClase = int.Parse(txtIdAlumnoClase.Text);
            listaAlumnoClase = objAlumnoBO.Buscar(idAlumnoClase, 2);

            if (listaAlumnoClase != null || listaAlumnoClase.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Alumno", typeof(string)));
                dt.Columns.Add(new DataColumn("Periodo", typeof(string)));
                dt.Columns.Add(new DataColumn("Periodo", typeof(string)));

                DataRow dr = dt.NewRow();

                for (int i = 0; i < listaAlumnoClase.Count; i++)
                {
                    dr["Alumno"] = listaAlumnoClase[i].Alumno.Nombre;
                    dr["Periodo"] = listaAlumnoClase[i].Periodo.Nombre;
                    dr["Calificacion"] = listaAlumnoClase[i].Calificacion;
                }

                dt.Rows.Add(dr);

                dgvAlumnoClase.DataSource = dt;
                dgvAlumnoClase.Refresh();
            }
        }

        private void frmAlumnoClase_Load(object sender, EventArgs e)
        {
            AlumnoClaseBO objAlumnoClaseBO = new AlumnoClaseBO();
            DataTable dt = new DataTable();
            List<Alumno> listaAlumno = new List<Alumno>();
            List<Periodo> listaPeriodo = new List<Periodo>();
            List<Clase> listaClase = new List<Clase>();
            List<AlumnoClase> listaAlumnoClase = new List<AlumnoClase>();

            listaAlumno = objAlumnoClaseBO.MostrarAlumno(1, 1);
            cmbMatricula.DataSource = listaAlumno;
            cmbMatricula.DisplayMember = "nombre";
            cmbMatricula.ValueMember = "idAlumno";

            listaPeriodo = objAlumnoClaseBO.MostrarPeriodo(1, 1);
            cmbPeriodo.DataSource = listaPeriodo;
            cmbPeriodo.DisplayMember = "nombre";
            cmbPeriodo.ValueMember = "idPeriodo";

            listaClase = objAlumnoClaseBO.MostrarClase(1, 1);
            cmbClase.DataSource = listaClase;
            cmbClase.DisplayMember = "nombre";
            cmbClase.ValueMember = "idClase";

            listaAlumnoClase = objAlumnoClaseBO.Buscar(0, 1);

            if (listaAlumnoClase != null || listaAlumnoClase.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Materia", typeof(string)));
                dt.Columns.Add(new DataColumn("Maestro", typeof(string)));
                dt.Columns.Add(new DataColumn("Capacidad", typeof(int)));

                DataRow dr = dt.NewRow();

                for (int i = 0; i < listaAlumnoClase.Count; i++)
                {
                    dr["Alumno"] = listaAlumnoClase[i].Alumno.Nombre;
                    dr["Periodo"] = listaAlumnoClase[i].Periodo.Nombre;
                    dr["Calificacion"] = listaAlumnoClase[i].Calificacion;
                }

                dt.Rows.Add(dr);

                dgvAlumnoClase.DataSource = dt;
                dgvAlumnoClase.Refresh();
            }
        }

        private void txtIdAlumnoClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCalificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
