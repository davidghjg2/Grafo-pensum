using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafo_pensum.Materia.Infra;
using System.IO;

namespace Grafo_pensum
{
    public partial class frmCRUDMateria : Form
    {
        MateriaInfra materiaInfra;
        public frmCRUDMateria()
        {
            InitializeComponent();
            materiaInfra = new MateriaInfra();
            cargarDatos();
        }

        private void cargarDatos()
        {
            obtenerMaterias();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
            limpiar();
        }

        private void limpiar()
        {
            txtID.Clear();
            txtAnio.Clear();
            txtSerie.Clear();
            textBox1.Clear();
            txtSerie.Focus();
        }

        private Materia.Dominio.Materia llenarDatos()
        {
            Materia.Dominio.Materia materia = new Materia.Dominio.Materia();
            materia.Id = txtID.Text;
            materia.Nombre = txtSerie.Text;
            materia.Descripcion = textBox1.Text;
            materia.uv = (int) numericUpDown1.Value;
            materia.Codigo = txtAnio.Text;

            return materia;
        }

        private void obtenerMaterias()
        {
            dataGridView1.Rows.Clear();

            (Materia.Dominio.Materia[], Exception) data = materiaInfra.ObtenerMaterias();

            if (data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            foreach (Materia.Dominio.Materia c in data.Item1)
            {
                dataGridView1.Rows.Add(c.Id, c.Codigo, c.Nombre, c.uv, c.Descripcion);
            }
        }

        private (Materia.Dominio.Materia[], Exception) leerArchivo()
        {
            try
            {
                Materia.Dominio.Materia[] materias = new Materia.Dominio.Materia[0];

                using(OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Archivos delimitado por comas (*.csv)|*.csv";
                    dlg.FilterIndex = 1;

                    if(dlg.ShowDialog() == DialogResult.OK)
                    {
                        string ruta = dlg.FileName;
                        string[] lineas = File.ReadAllLines(ruta);

                        for(int i = 0; i < lineas.Length; i++)
                        {
                            string[] partes = lineas[i].Split(';');
                            Array.Resize(ref materias, materias.Length + 1);
                            materias[materias.Length - 1] = new Materia.Dominio.Materia
                            {
                                Codigo = partes[0],
                                Nombre = partes[1],
                                uv = int.Parse(partes[2]),
                                Descripcion = partes[3]
                            };
                        }
                    }
                }

                return (materias, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }
        }

        private Exception insertarMaterias()
        {
            (Materia.Dominio.Materia[], Exception) data = leerArchivo();

            if(data.Item2 != null)
                return data.Item2;

            (bool, Exception) result = materiaInfra.InsertarMateria(data.Item1);

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private Exception insertarMateria()
        {
            (bool, Exception) result = materiaInfra.InsertarMateria(llenarDatos());

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private Exception actualizarMateria()
        {
            (bool, Exception) result = materiaInfra.ActualizarMateria(llenarDatos());

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private Exception eliminarMateria()
        {
            (bool, Exception) result = materiaInfra.EliminarMateria(llenarDatos());

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            Exception ex = insertarMateria();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
                MessageBox.Show("Materia insertada");

            cargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            Exception ex = actualizarMateria();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
                MessageBox.Show("Materia actualizada");

            cargarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;

            Exception ex = eliminarMateria();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
                MessageBox.Show("Materia actualizada");

            cargarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;

            Exception ex = insertarMaterias();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
                MessageBox.Show("Materias insertadas");

            cargarDatos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                button2.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = false;
                button3.Enabled = false;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["Id"].Value.ToString();
                txtSerie.Text = row.Cells["Nombre"].Value.ToString();
                txtAnio.Text = row.Cells["Codigo"].Value.ToString();
                textBox1.Text = row.Cells["Descripcion"].Value.ToString();
                numericUpDown1.Value = (int)row.Cells["Uv"].Value;
            }
        }
    }
}
