namespace Grafo_pensum
{
    partial class frmNavbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNavbar));
            this.Inicio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNav = new System.Windows.Forms.ToolStrip();
            this.tsMantenimiento = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsCRUDMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCRUDPensum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCRUDCarrera = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tsVer = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPensum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLogOut = new System.Windows.Forms.ToolStripButton();
            this.tsCRUDUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // Inicio
            // 
            this.Inicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Inicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Inicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Inicio.Name = "Inicio";
            this.Inicio.Size = new System.Drawing.Size(29, 59);
            this.Inicio.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // tsNav
            // 
            this.tsNav.AutoSize = false;
            this.tsNav.BackColor = System.Drawing.Color.LightGreen;
            this.tsNav.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsNav.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Inicio,
            this.toolStripSeparator1,
            this.tsMantenimiento,
            this.toolStripButton3,
            this.tsVer,
            this.tsLogOut});
            this.tsNav.Location = new System.Drawing.Point(0, 0);
            this.tsNav.Name = "tsNav";
            this.tsNav.Size = new System.Drawing.Size(1732, 62);
            this.tsNav.TabIndex = 15;
            this.tsNav.Text = "toolStrip1";
            // 
            // tsMantenimiento
            // 
            this.tsMantenimiento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCRUDMateria,
            this.tsCRUDPensum,
            this.tsCRUDCarrera,
            this.tsCRUDUsuarios});
            this.tsMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsMantenimiento.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsMantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("tsMantenimiento.Image")));
            this.tsMantenimiento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMantenimiento.Name = "tsMantenimiento";
            this.tsMantenimiento.Size = new System.Drawing.Size(132, 59);
            this.tsMantenimiento.Text = "Mantenimiento";
            this.tsMantenimiento.Click += new System.EventHandler(this.tsMantenimiento_Click);
            // 
            // tsCRUDMateria
            // 
            this.tsCRUDMateria.BackColor = System.Drawing.Color.LightGreen;
            this.tsCRUDMateria.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsCRUDMateria.Name = "tsCRUDMateria";
            this.tsCRUDMateria.Size = new System.Drawing.Size(224, 26);
            this.tsCRUDMateria.Text = "Materia";
            this.tsCRUDMateria.Click += new System.EventHandler(this.tsCRUDMateria_Click);
            // 
            // tsCRUDPensum
            // 
            this.tsCRUDPensum.BackColor = System.Drawing.Color.LightGreen;
            this.tsCRUDPensum.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsCRUDPensum.Name = "tsCRUDPensum";
            this.tsCRUDPensum.Size = new System.Drawing.Size(224, 26);
            this.tsCRUDPensum.Text = "Pénsum";
            this.tsCRUDPensum.Click += new System.EventHandler(this.tsCRUDPensum_Click);
            // 
            // tsCRUDCarrera
            // 
            this.tsCRUDCarrera.BackColor = System.Drawing.Color.LightGreen;
            this.tsCRUDCarrera.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsCRUDCarrera.Name = "tsCRUDCarrera";
            this.tsCRUDCarrera.Size = new System.Drawing.Size(224, 26);
            this.tsCRUDCarrera.Text = "Carrera";
            this.tsCRUDCarrera.Click += new System.EventHandler(this.tsCRUDCarrera_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 59);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // tsVer
            // 
            this.tsVer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMateria,
            this.tsPensum});
            this.tsVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsVer.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsVer.Image = ((System.Drawing.Image)(resources.GetObject("tsVer.Image")));
            this.tsVer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVer.Name = "tsVer";
            this.tsVer.Size = new System.Drawing.Size(49, 59);
            this.tsVer.Text = "Ver";
            // 
            // tsMateria
            // 
            this.tsMateria.BackColor = System.Drawing.Color.LightGreen;
            this.tsMateria.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsMateria.Name = "tsMateria";
            this.tsMateria.Size = new System.Drawing.Size(153, 26);
            this.tsMateria.Text = "Materia";
            this.tsMateria.Click += new System.EventHandler(this.tsMateria_Click);
            // 
            // tsPensum
            // 
            this.tsPensum.BackColor = System.Drawing.Color.LightGreen;
            this.tsPensum.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsPensum.Name = "tsPensum";
            this.tsPensum.Size = new System.Drawing.Size(153, 26);
            this.tsPensum.Text = "Pénsum";
            this.tsPensum.Click += new System.EventHandler(this.tsPensum_Click);
            // 
            // tsLogOut
            // 
            this.tsLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogOut.BackColor = System.Drawing.Color.Green;
            this.tsLogOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsLogOut.ForeColor = System.Drawing.Color.White;
            this.tsLogOut.Image = ((System.Drawing.Image)(resources.GetObject("tsLogOut.Image")));
            this.tsLogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogOut.Name = "tsLogOut";
            this.tsLogOut.Size = new System.Drawing.Size(123, 59);
            this.tsLogOut.Text = "Cerrar Sesión";
            this.tsLogOut.Click += new System.EventHandler(this.tsLogOut_Click);
            // 
            // tsCRUDUsuarios
            // 
            this.tsCRUDUsuarios.BackColor = System.Drawing.Color.LightGreen;
            this.tsCRUDUsuarios.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsCRUDUsuarios.Name = "tsCRUDUsuarios";
            this.tsCRUDUsuarios.Size = new System.Drawing.Size(224, 26);
            this.tsCRUDUsuarios.Text = "Usuarios";
            this.tsCRUDUsuarios.Click += new System.EventHandler(this.tsCRUDUsuarios_Click);
            // 
            // frmNavbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1732, 697);
            this.Controls.Add(this.tsNav);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNavbar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNavbar";
            this.tsNav.ResumeLayout(false);
            this.tsNav.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton Inicio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tsMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem tsCRUDMateria;
        private System.Windows.Forms.ToolStripMenuItem tsCRUDPensum;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripDropDownButton tsVer;
        private System.Windows.Forms.ToolStripMenuItem tsMateria;
        private System.Windows.Forms.ToolStripMenuItem tsPensum;
        private System.Windows.Forms.ToolStripButton tsLogOut;
        private System.Windows.Forms.ToolStrip tsNav;
        private System.Windows.Forms.ToolStripMenuItem tsCRUDCarrera;
        private System.Windows.Forms.ToolStripMenuItem tsCRUDUsuarios;
    }
}