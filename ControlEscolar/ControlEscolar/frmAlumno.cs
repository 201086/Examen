using ControlEscolar.BO;
using ControlEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Alumno objAlumno = new Alumno();
            AlumnoBO objAlumnoBo = new AlumnoBO();

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Favor de ingresar el Nombre");
                return;
            }

            if (txtApellidos.Text == "")
            {
                MessageBox.Show("Favor de ingresar los Apellidos");
                return;
            }

            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Favor de ingresar el Teléfono");
                return;
            }

            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Favor de ingresar el Correo");
                return;
            }

            if (rbMasculino.Checked == false && rbFemenino.Checked == false)
            {
                MessageBox.Show("Favor de seleccionar tipo de sexo");
                return;
            };

            objAlumno.Nombre = txtNombre.Text;
            objAlumno.Apellidos = txtApellidos.Text;
            objAlumno.Telefono = txtTelefono.Text;
            objAlumno.Correo = txtCorreo.Text;
            objAlumno.Sexo = (rbMasculino.Checked == true) ? "Masculino" : "Femenino"; //1 para masculino y 2 para femenino
            objAlumno.TipoOperacion = 1;
            iResultado = objAlumnoBo.CrudAlumno(objAlumno);

            if(iResultado == 1)
                MessageBox.Show("información Guardada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Alumno objAlumno = new Alumno();
            AlumnoBO objAlumnoBO = new AlumnoBO();

            if (int.Parse(txtIdAlumno.Text) <= 0) {
                MessageBox.Show("Favor de ingresar una Matricula");
                return;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Favor de ingresar el Nombre");
                return;
            }

            if (txtApellidos.Text == "")
            {
                MessageBox.Show("Favor de ingresar los Apellidos");
                return;
            }

            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Favor de ingresar el Teléfono");
                return;
            }

            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Favor de ingresar el Correo");
                return;
            }

            if (rbMasculino.Checked == false && rbFemenino.Checked == false)
            {
                MessageBox.Show("Favor de seleccionar tipo de sexo");
                return;
            }

            objAlumno.IdAlumno = int.Parse(txtIdAlumno.Text);
            objAlumno.Nombre = txtNombre.Text;
            objAlumno.Apellidos = txtApellidos.Text;
            objAlumno.Telefono = txtTelefono.Text;
            objAlumno.Correo = txtCorreo.Text;
            objAlumno.Sexo = (rbMasculino.Checked == true) ? "Masculino" : "Femenino"; //1 para masculino y 2 para femenino
            objAlumno.TipoOperacion = 2;
            iResultado = objAlumnoBO.CrudAlumno(objAlumno);

            if (iResultado == 2)
                MessageBox.Show("información Actualizada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Alumno objAlumno = new Alumno();
            AlumnoBO objAlumnoBO = new AlumnoBO();

            if (int.Parse(txtIdAlumno.Text) <= 0)
            {
                MessageBox.Show("Favor de ingresar una Matricula");
                return;
            }

            objAlumno.IdAlumno = int.Parse(txtIdAlumno.Text);
            objAlumno.TipoOperacion = 3;
            iResultado = objAlumnoBO.CrudAlumno(objAlumno);

            if (iResultado == 1)
                MessageBox.Show("información Eliminada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idAlumno = 0;
            Alumno objAlumno = new Alumno();
            AlumnoBO objAlumnoBO = new AlumnoBO();
            List<Alumno> listaAlumno = new List<Alumno>();

            idAlumno = int.Parse(txtIdAlumno.Text);
            listaAlumno = objAlumnoBO.Buscar(idAlumno, 2);

            if (listaAlumno != null && listaAlumno.Count > 0)
            {
                txtNombre.Text = listaAlumno[0].Nombre;
                txtApellidos.Text = listaAlumno[0].Apellidos;
                txtTelefono.Text = listaAlumno[0].Telefono;
                txtCorreo.Text = listaAlumno[0].Correo;
                rbMasculino.Checked = (listaAlumno[0].Sexo == "Masculino") ? true : false;
                rbFemenino.Checked = (listaAlumno[0].Sexo == "Femenino") ? true : false;

                dgvAlumno.DataSource = listaAlumno;
                dgvAlumno.Columns["IdAlumno"].Visible = false;
                dgvAlumno.Columns["TipoOperacion"].Visible = false;
                dgvAlumno.Refresh();
            }
        }

        private void LimpiarCampos()
        {
            txtIdAlumno.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            rbMasculino.Checked = false;
            rbMasculino.Checked = false;
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            Alumno objAlumno = new Alumno();
            AlumnoBO objAlumnoBO = new AlumnoBO();
            List<Alumno> listaAlumno = new List<Alumno>();

            listaAlumno = objAlumnoBO.Buscar(0, 1);

            if (listaAlumno != null || listaAlumno.Count > 0)
            {
                dgvAlumno.DataSource = listaAlumno;
                dgvAlumno.Columns["IdAlumno"].Visible = false;
                dgvAlumno.Columns["TipoOperacion"].Visible = false;
                dgvAlumno.Refresh();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtIdAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
