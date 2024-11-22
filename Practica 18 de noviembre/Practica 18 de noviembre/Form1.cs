using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_18_de_noviembre
{
    public partial class Form1 : Form
    {
        private List<Ciudad> ciudades;
        private Ciudad ciudadSel = new Ciudad();

        public Form1()
        {
            InitializeComponent();
            ciudades = new List<Ciudad>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = new Ciudad();
            ciudad.ID = int.Parse(txtCodigo.Text);
            ciudad.Nombre = txtNombre.Text;

            int index = ciudades.FindIndex(item => item.ID == ciudad.ID);

            if (index != -1) 
            {
                ciudades[index] = ciudad;
            }
            else
            {
                ciudades.Add(ciudad);
            }

            MostrarDatos();
            LimpiarCodigo();
        
        }
        private void MostrarDatos()
        {
            dgvRegistros.DataSource = null;
            dgvRegistros.DataSource = ciudades;
        }

        private void LimpiarCodigo()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Archivos DAT (*.dat)|*.dat";
                saveFileDialog1.Title = "Guardar Archivos";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    CiudadArchivo archivo = new CiudadArchivo();

                    archivo.GuardarArchivo(ciudades, saveFileDialog1.FileName);
                    MessageBox.Show("Se ha guardado el archivo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
