using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafo_pensum.Carrera.Infra;
using Grafo_pensum.Materia.Infra;
using Grafo_pensum.Pensum.Infra;

namespace Grafo_pensum
{
    public partial class frmCRUDPensum : Form
    {
        CarreraInfra carreraInfra;
        MateriaInfra materiaInfra;
        PensumInfra pensumInfra;
        Pensum.Dominio.Pensum pensum;

        public frmCRUDPensum()
        {
            InitializeComponent();
            carreraInfra = new CarreraInfra();
            materiaInfra = new MateriaInfra();
            pensumInfra = new PensumInfra();
            pensum = new Pensum.Dominio.Pensum();
            obtenerCarreras();
            obtenerPensums();
        }

        private void obtenerCarreras()
        {
            (Carrera.Dominio.Carrera[], Exception) data = carreraInfra.ObtenerCarreras();

            if (data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            comboBox1.DataSource = data.Item1;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }

        private void obtenerMaterias()
        {
            (Materia.Dominio.Materia[], Exception) data = materiaInfra.ObtenerMaterias();

            if (data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            comboBox2.DataSource = data.Item1;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id";
        }

        private void obtenerMateriass()
        {
            (Materia.Dominio.Materia[], Exception) data = materiaInfra.ObtenerMaterias();

            if (data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            comboBox3.DataSource = data.Item1;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "Id";
        }

        private void obtenerPensums()
        {
            dataGridView1.Rows.Clear();

            (Pensum.Dominio.Pensum[], Exception) data = pensumInfra.ObtenerPensums();

            if (data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            foreach (Pensum.Dominio.Pensum p in data.Item1)
            {
                dataGridView1.Rows.Add(p.Id, p.Codigo, p.carrera.Nombre, p.nodos?.Length ?? 0, p.carrera.Departamento);
            }
        }

        private void obtenerPensum()
        {
            (Pensum.Dominio.Pensum, Exception) data = pensumInfra.ObtenerPensum(txtAnio.Text);

            if (data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            pensum.Id = data.Item1.Id;
            pensum.carrera = data.Item1.carrera;
            pensum.Codigo = data.Item1.Codigo;
            pensum.nodos = data.Item1.nodos ?? new Materia.Dominio.Materia[0];
        }

        private Exception agregarNodo()
        {
            (Pensum.Dominio.Pensum, Exception) data = pensumInfra.ObtenerPensum(txtAnio.Text);

            Pensum.Dominio.Pensum p = data.Item1;

            Materia.Dominio.Materia materia = (Materia.Dominio.Materia) comboBox3.SelectedItem;

            p.AgregarNodo(materia);

            if(comboBox2.Visible == true)
            {
                Materia.Dominio.Materia req = (Materia.Dominio.Materia)comboBox2.SelectedItem;

                if(req == materia)
                {
                    errorProvider1.SetError(comboBox2, "Una materia no puede ser requsito de si misma");
                }

                p.EnlazarNodo(materia, req.Codigo);
            }

            (bool, Exception) result = pensumInfra.ActualizarPensum(p);

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private void controlesInsertar()
        {
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            label4.Visible = true;
            label5.Visible = false;
            label7.Visible = true;
            label3.Visible = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Visible = false;
            txtAnio.Visible = true;
        }

        private void controlesActualizar()
        {
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = true;
            label4.Visible = false;
            label5.Visible = true;
            label7.Visible = false;
            label3.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Visible = true;
            txtAnio.Visible = false;
        }

        private Exception insertarPensum()
        {
            Pensum.Dominio.Pensum data = new Pensum.Dominio.Pensum();
            data.carrera = (Carrera.Dominio.Carrera) comboBox1.SelectedItem;
            data.Codigo = txtAnio.Text;

            (bool, Exception) result = pensumInfra.InsertarPensum(data);

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private void limpiar()
        {
            txtAnio.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox1.Focus();
            controlesInsertar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exception ex = insertarPensum();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
            {
                MessageBox.Show("Dato Incertado");
                limpiar();
            }

            obtenerCarreras();
            obtenerPensums();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                controlesActualizar();
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtAnio.Text = row.Cells["Id"].Value.ToString();
                obtenerMateriass();
                obtenerPensum();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            label3.Visible = true;
            obtenerMaterias();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exception ex = agregarNodo();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
            {
                MessageBox.Show("Matria Agregada al Pensum");
                limpiar();
            }

            obtenerPensums();
        }
    }
}
