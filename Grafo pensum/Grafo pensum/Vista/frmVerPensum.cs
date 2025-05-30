using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafo_pensum.Carrera.Infra;
using Grafo_pensum.Pensum.Infra;

namespace Grafo_pensum
{
    public partial class frmVerPensum : Form
    {
        PensumInfra pensumInfra;

        public frmVerPensum()
        {
            InitializeComponent();
            pensumInfra = new PensumInfra();
            obtenerPensum();
            tableLayoutPanel1.Padding = new Padding(10);
        }

        private string ajustarTexto(string texto, int maxCaracteresPorLinea)
        {
            if (texto.Length <= maxCaracteresPorLinea)
                return texto;

            string resultado = "";
            string[] palabras = texto.Split(' ');
            int contadorCaracteres = 0;

            foreach (string palabra in palabras)
            {
                if (contadorCaracteres + palabra.Length > maxCaracteresPorLinea)
                {
                    resultado += Environment.NewLine;
                    contadorCaracteres = 0;
                }
                else if (contadorCaracteres > 0)
                {
                    resultado += " ";
                    contadorCaracteres++;
                }

                resultado += palabra;
                contadorCaracteres += palabra.Length;
            }

            return resultado;
        }

        private Panel CrearCarta(Materia.Dominio.Materia objeto)
        {
            var panelCarta = new Panel
            {
                Width = 200,
                Height = 150,
                Margin = new Padding(10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblNombre = new Label
            {
                Text = ajustarTexto(objeto.Nombre, 20),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblNumero = new Label
            {
                Text = $"Numero: {objeto.Codigo}",
                Location = new Point(10, 40),
                AutoSize = true
            };

            var lblCodigo = new Label
            {
                Text = $"Uv: {objeto.uv}",
                Location = new Point(10, 70),
                AutoSize = true
            };

            panelCarta.Controls.Add(lblNombre);
            panelCarta.Controls.Add(lblNumero);
            panelCarta.Controls.Add(lblCodigo);

            return panelCarta;
        }

        private void obtenerPensum()
        {
            (Pensum.Dominio.Pensum[], Exception) data = pensumInfra.ObtenerPensums();

            if (data.Item2 != null)
            {
                MessageBox.Show(data.Item2.Message);
                return;
            }

            comboBox1.DataSource = data.Item1;
            comboBox1.DisplayMember = "Codigo";
            comboBox1.ValueMember = "Id";
        }

        private void obtenerPensum(Pensum.Dominio.Pensum p)
        {
            Pensum.Dominio.Pensum pensum = p;
            Materia.Dominio.Materia[] m = p.BFS();

            if(m == null)
            {
                MessageBox.Show("Este pensum no tiene datos");
                return;
            }

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            int elementosAMostrar = m.Length - 1;
            int filas = (int)Math.Ceiling(elementosAMostrar / 4.0);
            tableLayoutPanel1.RowCount = filas;

            for (int i = 0; i < filas; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            for (int i = 1; i < m.Length; i++)
            {
                int indiceMostrado = i - 1;
                int fila = indiceMostrado / 4;
                int columna = indiceMostrado % 4;

                var carta = CrearCarta(m[i]);
                tableLayoutPanel1.Controls.Add(carta, columna, fila);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Pensum.Dominio.Pensum p = (Pensum.Dominio.Pensum)comboBox1.SelectedItem;
            obtenerPensum(p);
        }
    }
}
