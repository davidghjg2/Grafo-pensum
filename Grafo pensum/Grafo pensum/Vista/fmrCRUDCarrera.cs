using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using Grafo_pensum.Carrera.Infra;
using DnsClient.Protocol;
using System.IO;

namespace Grafo_pensum.Infra.Vista
{
    public partial class fmrCRUDCarrera : Form
    {
        CarreraInfra carreraInfra;
        public fmrCRUDCarrera()
        {
            InitializeComponent();
            carreraInfra = new CarreraInfra();
            obtenerCarreras();
        }

        private void obtenerCarreras()
        {
            dataGridView1.Rows.Clear();

            (Carrera.Dominio.Carrera[], Exception) data = carreraInfra.ObtenerCarreras();

            if(data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            foreach (Carrera.Dominio.Carrera c in data.Item1)
            {
                dataGridView1.Rows.Add(c.Id, c.Nombre, c.Departamento); 
            }
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtDepartamento.Clear();
        }

        private Carrera.Dominio.Carrera llenarDatos()
        {
            Carrera.Dominio.Carrera carreras = new Carrera.Dominio.Carrera();
            carreras.Nombre = txtNombre.Text;
            carreras.Departamento = txtDepartamento.Text;
            carreras.Id = txtID.Text;
            return carreras;
        }

        private (Carrera.Dominio.Carrera[] , Exception) leerArchivo()
        {
            try
            {
                Carrera.Dominio.Carrera[] carreras = new Carrera.Dominio.Carrera[0];

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
                            Array.Resize(ref carreras, carreras.Length + 1);
                            carreras[carreras.Length - 1] = new Carrera.Dominio.Carrera
                            {
                                Nombre = partes[0],
                                Departamento = partes[1]
                            };
                        }
                    }
                }
                return (carreras, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }

        }

        private Exception insertarCarreras()
        {
            (Carrera.Dominio.Carrera[], Exception) data = leerArchivo();

            if (data.Item2 != null)
                return data.Item2;

            (bool, Exception) result = carreraInfra.InsertarCarrera(data.Item1);

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private Exception insertarCarrera()
        {
            (bool, Exception) result = carreraInfra.InsertarCarrera(llenarDatos());

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private Exception actualizarCarrera()
        {
            (bool, Exception) result = carreraInfra.ActualizarCarrera(llenarDatos());

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private Exception eliminarCarrera()
        {
            (bool, Exception) result = carreraInfra.EliminarCarrera(llenarDatos());

            if (!result.Item1)
                return result.Item2;
            else
                return null;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exception ex = insertarCarrera();

            if(ex != null) 
                MessageBox.Show(ex.Message);
            else
            {
                MessageBox.Show("Dato Incertado");
                limpiar();
            }

            obtenerCarreras();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDepartamento.Text = row.Cells["Departamento"].Value.ToString();
                button2.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exception ex = actualizarCarrera();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
            {
                MessageBox.Show("Dato Actualizado");
                limpiar();
            }

            obtenerCarreras();
            button2.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Exception ex = eliminarCarrera();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
            {
                MessageBox.Show("Dato Eliminado");
                limpiar();
            }

            obtenerCarreras();
            button2.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Exception ex = insertarCarreras();

            if (ex != null)
                MessageBox.Show(ex.Message);
            else
            {
                MessageBox.Show("Datos Incertados");
                limpiar();
            }

            obtenerCarreras();
        }
    }
}
