using ControlEscolar.BO;
using ControlEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class frmMaestro : Form
    {
        public frmMaestro()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Maestro objMaestro = new Maestro();
            MaestroBO objMaestroBO = new MaestroBO();

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

            objMaestro.Nombre = txtNombre.Text;
            objMaestro.Apellidos = txtApellidos.Text;
            objMaestro.Telefono = txtTelefono.Text;
            objMaestro.Correo = txtCorreo.Text;
            objMaestro.Sexo = (rbMasculino.Checked == true) ? "Masculino" : "Femenino"; //1 para masculino y 2 para femenino
            objMaestro.TipoOperacion = 1;
            iResultado = objMaestroBO.CrudMaestro(objMaestro);

            if (iResultado == 1)
                MessageBox.Show("información Guardada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Maestro objMaestro = new Maestro();
            MaestroBO objMaestroBO = new MaestroBO();

            if (int.Parse(txtIdMaestro.Text) <= 0)
            {
                MessageBox.Show("Favor de ingresar una idMaestro");
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

            objMaestro.IdMaestro = int.Parse(txtIdMaestro.Text);
            objMaestro.Nombre = txtNombre.Text;
            objMaestro.Apellidos = txtApellidos.Text;
            objMaestro.Telefono = txtTelefono.Text;
            objMaestro.Correo = txtCorreo.Text;
            objMaestro.Sexo = (rbMasculino.Checked == true) ? "Masculino" : "Femenino"; //1 para masculino y 2 para femenino
            objMaestro.TipoOperacion = 2;
            iResultado = objMaestroBO.CrudMaestro(objMaestro);

            if (iResultado == 2)
                MessageBox.Show("información Actualizada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");


            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            Maestro objMaestro = new Maestro();
            MaestroBO objMaestroBO = new MaestroBO();

            if (int.Parse(txtIdMaestro.Text) <= 0)
            {
                MessageBox.Show("Favor de ingresar una Matricula");
                return;
            }

            objMaestro.IdMaestro = int.Parse(txtIdMaestro.Text);
            objMaestro.TipoOperacion = 3;
            iResultado = objMaestroBO.CrudMaestro(objMaestro);

            if (iResultado == 1)
                MessageBox.Show("información Eliminada correctamente");
            else
                MessageBox.Show("información no se guardo correctamente favor de intentar de nuevo");

            LimpiarCampos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int idMaestro = 0;
            Maestro objMaestro = new Maestro();
            MaestroBO objMaestroBO = new MaestroBO();
            List<Maestro> listaMaestro = new List<Maestro>();

            idMaestro = int.Parse(txtIdMaestro.Text);
            listaMaestro = objMaestroBO.Buscar(idMaestro, 2);

            if (listaMaestro != null && listaMaestro.Count > 0)
            {
                txtNombre.Text = listaMaestro[0].Nombre;
                txtApellidos.Text = listaMaestro[0].Apellidos;
                txtTelefono.Text = listaMaestro[0].Telefono;
                txtCorreo.Text = listaMaestro[0].Correo;
                rbMasculino.Checked = (listaMaestro[0].Sexo == "Masculino") ? true : false;
                rbFemenino.Checked = (listaMaestro[0].Sexo == "Femenino") ? true : false;

                dgvMaestro.DataSource = listaMaestro;
                dgvMaestro.Columns["IdMaestro"].Visible = false;
                dgvMaestro.Columns["TipoOperacion"].Visible = false;
                dgvMaestro.Refresh();
            }
        }

        private void LimpiarCampos()
        {
            txtIdMaestro.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            rbMasculino.Checked = false;
            rbMasculino.Checked = false;
        }

        private void frmMaestro_Load(object sender, EventArgs e)
        {
            Maestro objMaestro = new Maestro();
            MaestroBO objMaestroBO = new MaestroBO();
            List<Maestro> listaMaestro = new List<Maestro>();

            listaMaestro = objMaestroBO.Buscar(0, 1);

            if (listaMaestro != null && listaMaestro.Count > 0)
            {
                dgvMaestro.DataSource = listaMaestro;
                dgvMaestro.Columns["IdMaestro"].Visible = false;
                dgvMaestro.Columns["TipoOperacion"].Visible = false;
                dgvMaestro.Refresh();
            }
        }

        private void txtIdMaestro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
