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

namespace Grafo_pensum.Infra.Vista
{
    public partial class fmrCRUDCarrera : Form
    {
        public fmrCRUDCarrera()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Carrera.Dominio.Carrera carreras = new Carrera.Dominio.Carrera();
            carreras.Nombre = txtNombre.Text;
            carreras.Departamento = txtDepartamento.Text;

            CarreraInfra carreraInfra = new CarreraInfra();
            (bool, Exception) result = carreraInfra.InsertarCarrera(carreras);

            if (!result.Item1)
                MessageBox.Show(result.Item2.Message);
            else
                MessageBox.Show("Dato Incertado");
        }
    }
}
