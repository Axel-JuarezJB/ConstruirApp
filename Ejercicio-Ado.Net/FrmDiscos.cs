using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocios;

namespace Ejercicio_Ado.Net
{
    public partial class FrmDiscos : Form
    {
        private List<Discos> listaDiscos;
        public FrmDiscos()
        {
            InitializeComponent();
            Text = "Los Discos";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Canciones");
            cboCampo.Items.Add("Titulo");
            cboCampo.Items.Add("Genero");
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiscos.CurrentRow != null)
            {
                Discos seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.URLimagenTapa);
            }
        }
        private void cargar()
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                listaDiscos = negocio.listar();
                dgvDiscos.DataSource = negocio.listar();
                ocultarColumnas();
                //pbxAlbum.Load(listaDiscos[0].URLimagenTapa);
                cargarImagen(listaDiscos[0].URLimagenTapa);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnas()
        {
            dgvDiscos.Columns["URLimagenTapa"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAlbum.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxAlbum.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaDiscos alta = new FrmAltaDiscos();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Discos seleccionado;
            seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
            FrmAltaDiscos Modificacion = new FrmAltaDiscos(seleccionado);
            Modificacion.ShowDialog();
            cargar();
        }

        private void dgvDiscos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogica_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }
        private void eliminar(bool logico = false)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            Discos seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;

                    if (logico)
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminar(seleccionado.Id);

                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private bool validarFiltros()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Ingrese un campo para filtrar por favor");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("ingrese un criterio para filtraro por favor");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Canciones")
            {
                if (string.IsNullOrEmpty(tbxFiltroAvanzado.Text))
                {
                    MessageBox.Show("caja vacia, ingrese un numero");
                    return true;
                }
                if (!(soloNumeros(tbxFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Ingrese un campo numerico");
                    return true;
                }
            }

                return false;
        }
        private bool soloNumeros(string cadena)
        {
            foreach (char item in cadena)
            {
                if (!(char.IsNumber(item)))
                    return false;
            }
            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                if (validarFiltros())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = tbxFiltroAvanzado.Text;
                 
                dgvDiscos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void tbxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Discos> listaFiltrada;
            string filtrado = tbxFiltro.Text;

            //if (filtrado != "")
            if (filtrado.Length >= 3)
            {
                listaFiltrada = listaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(filtrado.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtrado.ToUpper()));
            }
            else
            {
                listaFiltrada = listaDiscos;
            }

            dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elegido = cboCampo.SelectedItem.ToString();
            if(elegido == "Canciones")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mas de");
                cboCriterio.Items.Add("Menos de");
                cboCriterio.Items.Add("Exacto");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Empieza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }

        }
    }
}
