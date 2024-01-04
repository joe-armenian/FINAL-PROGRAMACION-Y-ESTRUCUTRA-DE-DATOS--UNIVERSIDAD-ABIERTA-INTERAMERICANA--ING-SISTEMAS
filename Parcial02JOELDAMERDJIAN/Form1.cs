using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial02JOELDAMERDJIAN
{
    public partial class Form1 : Form
    {
        GestorArticulo gestorArticulo;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    gestorArticulo = new GestorArticulo(openFileDialog.FileName);
                    lblArchivo.Text = openFileDialog.FileName;
                    MostrarLista();
                    btnCargar.Enabled = false;
                    btnAlta.Enabled = true;
                    btnBaja.Enabled = true;
                    btnModificar.Enabled = true;

                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error al cargar archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarLetras(txtNombre.Text) &&  ValidarLetras(txtDescripcion.Text) && ValidarNumeros(txtCodigo.Text) && ValidarNumeros(txtCodigoBarras.Text))
                {
                    Articulo articulo = new Articulo();
                    articulo.Nombre = txtNombre.Text;
                    articulo.Codigo = Convert.ToInt32(txtCodigo.Text);
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.CodigoBarras = Convert.ToInt32(txtCodigoBarras.Text);
                    gestorArticulo.RegistrarArticulo(articulo);
                    MostrarLista();

                }

                else
                {
                    MessageBox.Show("Error  en la entrada de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error en el flujo de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public static bool ValidarNumeros(string linea)
        {
            return Regex.IsMatch(linea,@"^[0-9]+$");
        }

        public static bool ValidarLetras(string linea)
        {
            return Regex.IsMatch(linea,@"^[a-zA-Z ]+$");
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

            if (dgvArticulos.SelectedRows.Count > 0)

            {
                Articulo articulo = (Articulo)dgvArticulos.SelectedRows[0].DataBoundItem;
                gestorArticulo.EliminarArticulo(articulo.Codigo);
                MostrarLista();

            }
            else
            {
                MessageBox.Show("No hay elementos o no ha seleccioando ninguno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (dgvArticulos.SelectedRows.Count > 0)

            {
                Articulo articuloModificado = new Articulo();
                articuloModificado.Nombre = txtNombre.Text;
                articuloModificado.Codigo = Convert.ToInt32(txtCodigo.Text);
                articuloModificado.Descripcion = txtDescripcion.Text;
                articuloModificado.CodigoBarras = Convert.ToInt32(txtCodigoBarras.Text);
                Articulo articulo = (Articulo)dgvArticulos.SelectedRows[0].DataBoundItem;
                gestorArticulo.ModificarArticulo(articulo.Codigo, articuloModificado);
                MostrarLista();

            }
            else
            {
                MessageBox.Show("No hay elementos o no ha seleccioando ninguno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public void MostrarLista()
        {
            dgvArticulos.DataSource=gestorArticulo.ListarArticulos();
        }

        private void noVeoMiPaqueteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerda que los articulos tardan entre 24 y 48 horas en habilitarse", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void errorEnLaEntradaDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Nombres solamente texto y numeros solo en enteros.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void diasHabilesLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Los dias habiles laborales son de Lunes a Miercoles", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Red;  
        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Green;
        }

        private void azulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor=Color.Blue;
        }

        private void amarilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
        }

        private void negroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;


        }

    }
}
