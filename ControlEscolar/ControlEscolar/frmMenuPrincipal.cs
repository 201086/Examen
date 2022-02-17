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
    public partial class frmControlEscolar : Form
    {
        public frmControlEscolar()
        {
            InitializeComponent();
        }

        private void mnuAlumno_Click(object sender, EventArgs e)
        {
            frmAlumno objAlumno = new frmAlumno();
            objAlumno.Show();
        }

        private void mnuMaestro_Click(object sender, EventArgs e)
        {
            frmMaestro objMaestro = new frmMaestro();
            objMaestro.Show();
        }

        private void mnuAlumnoClase_Click(object sender, EventArgs e)
        {
            frmAlumnoClase objAlumnoClase = new frmAlumnoClase();
            objAlumnoClase.Show();
        }

        private void mnuClase_Click(object sender, EventArgs e)
        {
            frmClase objClase = new frmClase();
            objClase.Show();
        }

        private void materia_Click(object sender, EventArgs e)
        {
            frmMateria objMateria = new frmMateria();
            objMateria.Show();
        }

        private void mnuPeriodo_Click(object sender, EventArgs e)
        {
            frmPeriodo objPeriodo = new frmPeriodo();
            objPeriodo.Show();
        }
    }
}
