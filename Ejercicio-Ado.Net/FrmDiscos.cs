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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DiscosNegocio negocio = new DiscosNegocio();
            //listaDiscos = negocio.listar();
            //dgvDiscos.DataSource = negocio.listar();
            //dgvDiscos.Columns["URLimagenTapa"].Visible = false;
            //pbxAlbum.Load(listaDiscos[0].URLimagenTapa);
            //cargarImagen(listaDiscos[0].URLimagenTapa);

            cargar();
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
            //pbxAlbum.Load(seleccionado.URLimagenTapa);
            cargarImagen(seleccionado.URLimagenTapa);
        }
        private void cargar()
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                listaDiscos = negocio.listar();
                dgvDiscos.DataSource = negocio.listar();
                dgvDiscos.Columns["URLimagenTapa"].Visible = false;
                pbxAlbum.Load(listaDiscos[0].URLimagenTapa);
                cargarImagen(listaDiscos[0].URLimagenTapa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
    }
}
