using ControlEscolar.BO;
using ControlEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class frmMateria : Form
    {
        public frmMateria()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Favor de ingresar el Nombre");
                return;
            }

            Materia objMateria = new Materia();
            MateriaBO objMateriBo = new MateriaBO();

            objMateria.Nombre = txtNombre.Text;
            objMateria.TipoOperacion = 1;
            iResultado = objMateriBo.CrudMateria(objMateria);

            if (iResultado == 1)
                MessageBox.Show("información Guardada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (txtIdMateria.Text == "") {
                MessageBox.Show("Favor de ingresar idMateria");
            }

            Materia objMateria = new Materia();
            MateriaBO objMateriBo = new MateriaBO();

            objMateria.IdMateria = int.Parse(txtIdMateria.Text);
            objMateria.Nombre = txtNombre.Text;
            objMateria.TipoOperacion = 2;
            iResultado = objMateriBo.CrudMateria(objMateria);

            if (iResultado == 2)
                MessageBox.Show("información Actualizada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (txtIdMateria.Text == "")
            {
                MessageBox.Show("Favor de ingresar idMateria");
            }

            Materia objMateria = new Materia();
            MateriaBO objMateriBo = new MateriaBO();

            objMateria.IdMateria = int.Parse(txtIdMateria.Text);
            objMateria.Nombre = txtNombre.Text;
            objMateria.TipoOperacion = 3;

            iResultado = objMateriBo.CrudMateria(objMateria);

            if (iResultado == 3)
                MessageBox.Show("información Eliminada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idMateria = 0;
            Materia objMateria = new Materia();
            MateriaBO objMateriaBO = new MateriaBO();
            List<Materia> listaMateria = new List<Materia>();

            if (txtIdMateria.Text == "")
            {
                MessageBox.Show("Favor de ingresar idMateria");
                return;
            }

            idMateria = int.Parse(txtIdMateria.Text);
            listaMateria = objMateriaBO.Buscar(idMateria, 2);

            if (listaMateria != null && listaMateria.Count > 0)
            {
                txtNombre.Text = listaMateria[0].Nombre;

                dgvMateria.DataSource = listaMateria;
                dgvMateria.Columns["IdMateria"].Visible = false;
                dgvMateria.Columns["TipoOperacion"].Visible = false;
                dgvMateria.Refresh();
            }
        }

        private void frmMateria_Load(object sender, EventArgs e)
        {
            List<Materia> listaAlumno = new List<Materia>();
            Materia objMateria = new Materia();
            MateriaBO objMateriaBO = new MateriaBO();

            listaAlumno = objMateriaBO.Buscar(0, 1);

            if (listaAlumno != null || listaAlumno.Count > 0)
            {
                dgvMateria.DataSource = listaAlumno;
                dgvMateria.Columns["IdMateria"].Visible = false;
                dgvMateria.Columns["TipoOperacion"].Visible = false;
                dgvMateria.Refresh();
            }
        }

        private void txtIdMateria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void LimpiarCampos()
        {
            txtIdMateria.Text = "";
            txtNombre.Text = "";
        }
    }
}
