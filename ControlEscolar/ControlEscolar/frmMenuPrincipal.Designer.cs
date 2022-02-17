namespace ControlEscolar
{
    partial class frmControlEscolar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaestro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlumnoClase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClase = new System.Windows.Forms.ToolStripMenuItem();
            this.materia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPeriodo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAlumno,
            this.mnuMaestro,
            this.mnuAlumnoClase,
            this.mnuClase,
            this.materia,
            this.mnuPeriodo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(691, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuAlumno
            // 
            this.mnuAlumno.Name = "mnuAlumno";
            this.mnuAlumno.Size = new System.Drawing.Size(87, 29);
            this.mnuAlumno.Text = "Alumno";
            this.mnuAlumno.Click += new System.EventHandler(this.mnuAlumno_Click);
            // 
            // mnuMaestro
            // 
            this.mnuMaestro.Name = "mnuMaestro";
            this.mnuMaestro.Size = new System.Drawing.Size(89, 29);
            this.mnuMaestro.Text = "Maestro";
            this.mnuMaestro.Click += new System.EventHandler(this.mnuMaestro_Click);
            // 
            // mnuAlumnoClase
            // 
            this.mnuAlumnoClase.Name = "mnuAlumnoClase";
            this.mnuAlumnoClase.Size = new System.Drawing.Size(128, 29);
            this.mnuAlumnoClase.Text = "AlumnoClase";
            this.mnuAlumnoClase.Click += new System.EventHandler(this.mnuAlumnoClase_Click);
            // 
            // mnuClase
            // 
            this.mnuClase.Name = "mnuClase";
            this.mnuClase.Size = new System.Drawing.Size(65, 29);
            this.mnuClase.Text = "Clase";
            this.mnuClase.Click += new System.EventHandler(this.mnuClase_Click);
            // 
            // materia
            // 
            this.materia.Name = "materia";
            this.materia.Size = new System.Drawing.Size(83, 29);
            this.materia.Text = "Materia";
            this.materia.Click += new System.EventHandler(this.materia_Click);
            // 
            // mnuPeriodo
            // 
            this.mnuPeriodo.Name = "mnuPeriodo";
            this.mnuPeriodo.Size = new System.Drawing.Size(86, 29);
            this.mnuPeriodo.Text = "Periodo";
            this.mnuPeriodo.Click += new System.EventHandler(this.mnuPeriodo_Click);
            // 
            // frmControlEscolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 519);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmControlEscolar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Escolar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAlumno;
        private System.Windows.Forms.ToolStripMenuItem mnuMaestro;
        private System.Windows.Forms.ToolStripMenuItem mnuAlumnoClase;
        private System.Windows.Forms.ToolStripMenuItem mnuClase;
        private System.Windows.Forms.ToolStripMenuItem materia;
        private System.Windows.Forms.ToolStripMenuItem mnuPeriodo;
    }
}

